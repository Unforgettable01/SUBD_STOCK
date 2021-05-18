using StockBusinessLogic.BindingModels;
using StockBusinessLogic.Interfaces;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using (var context = new stockContext())
            {
                return context.Покупатель
                .Select(CreateModel).ToList();
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new stockContext())
            {
                return context.Покупатель
                    .Where(rec => rec.Фио.Contains(model.FIO))
                    .Select(CreateModel).ToList();
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new stockContext())
            {
                var client = context.Покупатель
                    .FirstOrDefault(rec => rec.Телефон.Equals(model.Telephone) || rec.Id == model.Id);
                return client != null ? CreateModel(client) : null;
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var context = new stockContext())
            {
                context.Покупатель.Add(CreateModel(model, new Покупатель()));
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (var context = new stockContext())
            {
                var element = context.Покупатель.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Покупатель не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new stockContext())
            {
                Покупатель element = context.Покупатель.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Покупатель.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Покупатель не найден");
                }
            }
        }

        private Покупатель CreateModel(ClientBindingModel model, Покупатель client)
        {
            client.Фио = model.FIO;
            client.Телефон = model.Telephone;
            return client;
        }

        private ClientViewModel CreateModel(Покупатель client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                FIO = client.Фио,
                Telephone = client.Телефон,

            };
        }
    }
}

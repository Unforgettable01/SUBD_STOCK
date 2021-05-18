using StockBusinessLogic.BindingModels;
using StockBusinessLogic.Interfaces;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDatabaseImplement.Implements
{
    //public class WorkerStorage : IWorkerStorage
    //{
    //    public List<WorkerViewModel> GetFullList()
    //    {
    //        using (var context = new stockContext())
    //        {
    //            return context.Сотрудник
    //            .Select(CreateModel).ToList();
    //        }
    //    }

    //    public List<WorkerViewModel> GetFilteredList(WorkerBindingModel model)
    //    {
    //        if (model == null)
    //        {
    //            return null;
    //        }
    //        using (var context = new stockContext())
    //        {
    //            return context.Сотрудник
    //                .Where(rec => rec.Фио.Contains(model.FIO))
    //                .Select(CreateModel).ToList();
    //        }
    //    }

    //    public WorkerViewModel GetElement(WorkerBindingModel model)
    //    {
    //        if (model == null)
    //        {
    //            return null;
    //        }
    //        using (var context = new stockContext())
    //        {
    //            var client = context.Сотрудник
    //                .FirstOrDefault(rec => rec.Телефон.Equals(model.Telephone) || rec.Id == model.Id);
    //            return client != null ? CreateModel(client) : null;
    //        }
    //    }

    //    public void Insert(WorkerBindingModel model)
    //    {
    //        using (var context = new stockContext())
    //        {
    //            context.Сотрудник.Add(CreateModel(model, new Сотрудник()));
    //            context.SaveChanges();
    //        }
    //    }

    //    public void Update(WorkerBindingModel model)
    //    {
    //        using (var context = new stockContext())
    //        {
    //            var element = context.Сотрудник.FirstOrDefault(rec => rec.Id == model.Id);
    //            if (element == null)
    //            {
    //                throw new Exception("Сотрудник не найден");
    //            }
    //            CreateModel(model, element);
    //            context.SaveChanges();
    //        }
    //    }

    //    public void Delete(WorkerBindingModel model)
    //    {
    //        using (var context = new stockContext())
    //        {
    //            Сотрудник element = context.Сотрудник.FirstOrDefault(rec => rec.Id == model.Id);
    //            if (element != null)
    //            {
    //                context.Сотрудник.Remove(element);
    //                context.SaveChanges();
    //            }
    //            else
    //            {
    //                throw new Exception("Сотрудник не найден");
    //            }
    //        }
    //    }

    //    private Сотрудник CreateModel(WorkerBindingModel model, Сотрудник client)
    //    {
    //        client.Фио = model.FIO;
    //        client.Телефон = model.Telephone;
    //        //client. = model.FIO;
    //        return client;
    //    }

    //    private ClientViewModel CreateModel(Покупатель client)
    //    {
    //        return new ClientViewModel
    //        {
    //            Id = client.Id,
    //            FIO = client.Фио,
    //            Telephone = client.Телефон,

    //        };
    //    }
    //}
}

using StockBusinessLogic.BindingModels;
using StockBusinessLogic.Interfaces;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBusinessLogic.BusinessLogic
{
    public class WorkerBusinessLogic
    {
        private readonly IWorkerStorage _workerStorage;

        public WorkerBusinessLogic(IWorkerStorage workerStorage)
        {
            _workerStorage = workerStorage;
        }

        public List<WorkerViewModel> Read(WorkerBindingModel model)
        {
            if (model == null)
            {
                return _workerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WorkerViewModel> { _workerStorage.GetElement(model) };
            }
            return _workerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(WorkerBindingModel model)
        {
            var element = _workerStorage.GetElement(new WorkerBindingModel { Telephone = model.Telephone });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сотрудник с таким номером телефона");
            }
            if (model.Id.HasValue)
            {
                _workerStorage.Update(model);
            }
            else
            {
                _workerStorage.Insert(model);
            }
        }

        public void Delete(WorkerBindingModel model)
        {
            var element = _workerStorage.GetElement(new WorkerBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Сотрудник не найден");
            }
            _workerStorage.Delete(model);
        }
    }
}

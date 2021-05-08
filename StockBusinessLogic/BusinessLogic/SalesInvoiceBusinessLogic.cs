using StockBusinessLogic.BindingModels;
using StockBusinessLogic.Interfaces;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBusinessLogic.BusinessLogic
{
    public class SalesInvoiceBusinessLogic
    {
        private readonly ISalesInvoiceStorage _salesInvoiceStorage;

        public SalesInvoiceBusinessLogic(ISalesInvoiceStorage salesInvoiceStorage)
        {
            _salesInvoiceStorage = salesInvoiceStorage;
        }
        public List<SalesInvoiceViewModel> Read(SalesInvoiceBindingModel model)
        {
            if (model == null)
            {
                return _salesInvoiceStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SalesInvoiceViewModel> { _salesInvoiceStorage.GetElement(model) };
            }
            return _salesInvoiceStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SalesInvoiceBindingModel model)
        {
            var element = _salesInvoiceStorage.GetElement(new SalesInvoiceBindingModel { Date = model.Date });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая накладная");
            }
            if (model.Id.HasValue)
            {
                _salesInvoiceStorage.Update(model);
            }
            else
            {
                _salesInvoiceStorage.Insert(model);
            }
        }

        public void Delete(SalesInvoiceBindingModel model)
        {
            var element = _salesInvoiceStorage.GetElement(new SalesInvoiceBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Накладная не найдена");
            }
            _salesInvoiceStorage.Delete(model);
        }
    }
}

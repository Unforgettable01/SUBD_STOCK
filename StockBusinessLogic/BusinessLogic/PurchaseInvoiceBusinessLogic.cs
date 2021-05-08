using StockBusinessLogic.BindingModels;
using StockBusinessLogic.Interfaces;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBusinessLogic.BusinessLogic
{
    public class PurchaseInvoiceBusinessLogic
    {
        private readonly IPurchaseInvoiceStorage _purchaseInvoiceStorage;

        public PurchaseInvoiceBusinessLogic(IPurchaseInvoiceStorage purchaseInvoiceStorage)
        {
            _purchaseInvoiceStorage = purchaseInvoiceStorage;
        }
        public List<PurchaseInvoiceViewModel> Read(PurchaseInvoiceBindingModel model)
        {
            if (model == null)
            {
                return _purchaseInvoiceStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchaseInvoiceViewModel> { _purchaseInvoiceStorage.GetElement(model) };
            }
            return _purchaseInvoiceStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PurchaseInvoiceBindingModel model)
        {
            var element = _purchaseInvoiceStorage.GetElement(new PurchaseInvoiceBindingModel { Date = model.Date });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такое поступление");
            }
            if (model.Id.HasValue)
            {
                _purchaseInvoiceStorage.Update(model);
            }
            else
            {
                _purchaseInvoiceStorage.Insert(model);
            }
        }

        public void Delete(PurchaseInvoiceBindingModel model)
        {
            var element = _purchaseInvoiceStorage.GetElement(new PurchaseInvoiceBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Накладная не найдена");
            }
            _purchaseInvoiceStorage.Delete(model);
        }
    }
}

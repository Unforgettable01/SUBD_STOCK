using StockBusinessLogic.BindingModels;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBusinessLogic.Interfaces
{
    public interface IPurchaseInvoiceStorage
    {
        List<PurchaseInvoiceViewModel> GetFullList();
        List<PurchaseInvoiceViewModel> GetFilteredList(PurchaseInvoiceBindingModel model);
        PurchaseInvoiceViewModel GetElement(PurchaseInvoiceBindingModel model);
        void Insert(PurchaseInvoiceBindingModel model);
        void Update(PurchaseInvoiceBindingModel model);
        void Delete(PurchaseInvoiceBindingModel model);
    }
}

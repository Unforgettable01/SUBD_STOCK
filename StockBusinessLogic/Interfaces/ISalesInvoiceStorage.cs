using StockBusinessLogic.BindingModels;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBusinessLogic.Interfaces
{
    public interface ISalesInvoiceStorage
    {
        List<SalesInvoiceViewModel> GetFullList();
        List<SalesInvoiceViewModel> GetFilteredList(SalesInvoiceBindingModel model);
        SalesInvoiceViewModel GetElement(SalesInvoiceBindingModel model);
        void Insert(SalesInvoiceBindingModel model);
        void Update(SalesInvoiceBindingModel model);
        void Delete(SalesInvoiceBindingModel model);
    }
}

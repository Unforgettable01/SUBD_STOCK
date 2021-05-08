using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace StockBusinessLogic.ViewModels
{
    [DataContract]
    public class PurchaseInvoiceViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Дата поступления")]
        public DateTime Date { get; set; }
        [DataMember]
        [DisplayName("ФИОСотрудника")]
        public string WorkerName { get; set; }
    }
}

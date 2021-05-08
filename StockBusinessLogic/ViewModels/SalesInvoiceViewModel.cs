using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace StockBusinessLogic.ViewModels
{
    [DataContract]
    public class SalesInvoiceViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Дата продажи")]
        public DateTime Date { get; set; }
        [DataMember]
        [DisplayName("ФИОПосетителя")]
        public string ClientName { get; set; }
        [DataMember]
        [DisplayName("ФИОСотрудника")]
        public string WorkerName { get; set; }
    }
}

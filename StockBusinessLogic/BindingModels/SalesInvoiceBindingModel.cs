using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StockBusinessLogic.BindingModels
{
    [DataContract]
    public class SalesInvoiceBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int WorkerId { get; set; }
    }
}

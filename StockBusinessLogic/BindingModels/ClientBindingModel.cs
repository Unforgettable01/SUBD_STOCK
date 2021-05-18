using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StockBusinessLogic.BindingModels
{
    [DataContract]
    public class ClientBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public int Telephone { get; set; }
    }
}

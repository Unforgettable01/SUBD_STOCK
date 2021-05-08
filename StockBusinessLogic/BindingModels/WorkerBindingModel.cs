using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StockBusinessLogic.BindingModels
{
    [DataContract]
    public class WorkerBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}

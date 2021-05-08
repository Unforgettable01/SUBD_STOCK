using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace StockBusinessLogic.ViewModels
{
    [DataContract]
    public class ProductViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название")]
        public string Name { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public int Price { get; set; }
    }
}

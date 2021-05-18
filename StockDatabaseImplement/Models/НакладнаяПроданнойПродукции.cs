using System;
using System.Collections.Generic;

namespace StockDatabaseImplement
{
    public partial class НакладнаяПроданнойПродукции
    {
        public int Id { get; set; }
        public string ДатаПродажи { get; set; }
        public int? Телефон { get; set; }
        public int Покупательid { get; set; }
        public int Сотрудникid { get; set; }
        public virtual Покупатель Покупатель { get; set; }
        public virtual Сотрудник Сотрудник { get; set; }
    }
}

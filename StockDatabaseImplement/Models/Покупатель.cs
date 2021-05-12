using System;
using System.Collections.Generic;

namespace StockDatabaseImplement
{
    public partial class Покупатель
    {
        public Покупатель()
        {
            НакладнаяПроданнойПродукции = new HashSet<НакладнаяПроданнойПродукции>();
        }

        public int Id { get; set; }
        public string Фио { get; set; }
        public int Телефон { get; set; }

        public virtual ICollection<НакладнаяПроданнойПродукции> НакладнаяПроданнойПродукции { get; set; }
    }
}

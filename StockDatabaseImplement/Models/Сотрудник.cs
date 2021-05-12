using System;
using System.Collections.Generic;

namespace StockDatabaseImplement
{
    public partial class Сотрудник
    {
        public Сотрудник()
        {
            НакладнаяПроданнойПродукции = new HashSet<НакладнаяПроданнойПродукции>();
            ПриходнаяНакладная = new HashSet<ПриходнаяНакладная>();
        }

        public int Id { get; set; }
        public string Фио { get; set; }
        public int? Телефон { get; set; }
        public int Пароль { get; set; }
        public string Логин { get; set; }

        public virtual ICollection<НакладнаяПроданнойПродукции> НакладнаяПроданнойПродукции { get; set; }
        public virtual ICollection<ПриходнаяНакладная> ПриходнаяНакладная { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace StockDatabaseImplement
{
    public partial class ПриходнаяНакладная
    {
        public int Id { get; set; }
        public DateTime ДатаПоступления { get; set; }
        public int Сотрудникid { get; set; }

        public virtual Сотрудник Сотрудник { get; set; }
    }
}

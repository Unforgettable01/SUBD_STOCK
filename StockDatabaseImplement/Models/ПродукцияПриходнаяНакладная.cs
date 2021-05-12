using System;
using System.Collections.Generic;

namespace StockDatabaseImplement
{
    public partial class ПродукцияПриходнаяНакладная
    {
        public int КоличествоПроданнойПродукции { get; set; }
        public int Продукцияid { get; set; }
        public int ПриходнаяНакладнаяid { get; set; }

        public virtual ПриходнаяНакладная ПриходнаяНакладная { get; set; }
        public virtual Продукция Продукция { get; set; }
    }
}

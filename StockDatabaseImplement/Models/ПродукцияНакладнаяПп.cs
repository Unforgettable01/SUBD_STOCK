using System;
using System.Collections.Generic;

namespace StockDatabaseImplement
{
    public partial class ПродукцияНакладнаяПп
    {
        public int КоличествоПроданнойПродукции { get; set; }
        public int Продукцияid { get; set; }
        public int НакладнаяПроданнойПродукцииid { get; set; }

        public virtual НакладнаяПроданнойПродукции НакладнаяПроданнойПродукции { get; set; }
        public virtual Продукция Продукция { get; set; }
    }
}

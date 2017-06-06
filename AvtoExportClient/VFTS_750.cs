﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoExportClient
{
    public class VFTS_750 : VFTS_Base
    {
        public VFTS_750()
        {
            Название_Модели = "ВФТС 750 кг";
            Вес = 750;
            ИспользованиеКомпозитныхМатериалов = true;

            СтабилизаторПоперечнойУчтойчивостиИМатериал = new Tuple<bool, _МатериалыМеталл>(true, _МатериалыМеталл.Титан);
            МассаМаховикаИМатериал = new Tuple<float, _МатериалыМеталл>((float)3.2, _МатериалыМеталл.Титан); // Заводской вес сильно больше
            ПрямозубаяКоробкаПередач = true;
            КоличествоСтупеней = 5;
            Цена = 40000;
            СтепеньСжатия = (float)12.5;
            МодельИспользуемогоРаспредвала = _МодельИспользуемогоРаспредвала.VFTS_3;
        }
    }
}

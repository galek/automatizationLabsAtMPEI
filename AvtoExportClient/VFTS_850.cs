﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoExportClient
{
    public class VFTS_850 : VFTS_Base
    {
        public VFTS_850()
        {
            Название_Модели = "ВФТС 850 кг";
            Вес = 850;
            СтабилизаторПоперечнойУчтойчивостиИМатериал = new Tuple<bool, _МатериалыМеталл>(true, _МатериалыМеталл.Титан);
            МассаМаховикаИМатериал = new Tuple<float, _МатериалыМеталл>((float)4.0, _МатериалыМеталл.УсиленнаяСталь); // Заводской вес сильно больше
            ПрямозубаяКоробкаПередач = true;
            КоличествоСтупеней = 5;
            Цена = 25000;
            МодельИспользуемогоРаспредвала = _МодельИспользуемогоРаспредвала.VFTS_2;
        }
    }
}

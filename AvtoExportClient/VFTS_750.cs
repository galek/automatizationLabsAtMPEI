using System;
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
            Name = "ВФТС 750 кг";
            Weight = 750;
            WithCompositeMaterials = true;

            СтабилизаторПоперечнойУчтойчивостиИМатериал = new Tuple<bool, _МатериалыМеталл>(true, _МатериалыМеталл.Титан);
            МассаМаховикаИМатериал = new Tuple<float, _МатериалыМеталл>((float)3.2, _МатериалыМеталл.Титан); // Заводской вес сильно больше
            ПрямозубаяКоробкаПередач = true;
            КоличествоСтупеней = 5;
            Price = 40000;
            СтепеньСжатия = (float)12.5;
            МодельИспользуемогоРаспредвала = "VFTS-3";
        }
    }
}

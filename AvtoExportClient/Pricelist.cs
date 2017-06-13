using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AvtoExportClient
{
    //https://habrahabr.ru/post/137405/
    [Serializable]
    // хранится в БД
    // TODO: Получаем номера из BD
    public static class Counters
    {
        public static int carNumber = 0;
        public static int НомерЗаказа = 0;
        public static string ИмяЗаказчика = "";
    }

    class Pricelist
    {
    }
}

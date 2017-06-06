﻿using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace AvtoExportClient
{
    // Количество облегченных детелаей. Просто счетчик
    [Serializable]
    [DataContract]
    public class BaseCar
    {
        public enum _МатериалыМеталл
        {
            Заводская,
            УсиленнаяСталь,
            Титан,
            Алюминий
        }

        public enum _МатериалыОбщие
        {
            Заводская = 0,
            УсиленнаяСталь,
            Титан,
            Алюминий,
            Углепластик,
            Стекловолокно
        }

        public enum _ТипАмортизаторов
        {
            Масло = 0,
            ГазМасло,
            Газ
        }

        public enum _Привод
        {
            Задний = 0,
            Передний,
            Полный
        };

        public enum _ИспользуемыйРяд
        {
            Стандарт = 0,
            R1,
            R2, R3, R4, R5, R505
        }

        [DataMember]
        // Название модели
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        [DataMember]
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
            }
        }

        [DataMember]
        public float Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        [DataMember]
        public float Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        [DataMember]
        public bool WithSafetyCarcass
        {
            get
            {
                return withSafetyCarcass;
            }

            set
            {
                withSafetyCarcass = value;
            }
        }

        [DataMember]
        public bool WithCompositeMaterials
        {
            get
            {
                return withCompositeMaterials;
            }

            set
            {
                withCompositeMaterials = value;
            }
        }

        [DataMember]
        public bool ИспользуетсяЗаднийСтабилизатор
        {
            get
            {
                return используетсяЗаднийСтабилизатор;
            }

            set
            {
                используетсяЗаднийСтабилизатор = value;
            }
        }

        [DataMember]
        public _ТипАмортизаторов ТипАмортизаторов
        {
            get
            {
                return типАмортизаторов;
            }

            set
            {
                типАмортизаторов = value;
            }
        }

        [DataMember]
        public string МаркаАмортизаторов
        {
            get
            {
                return маркаАмортизаторов;
            }

            set
            {
                маркаАмортизаторов = value;
            }
        }

        [DataMember]
        public Tuple<bool, _МатериалыМеталл> СтабилизаторПоперечнойУчтойчивостиИМатериал
        {
            get
            {
                return стабилизаторПоперечнойУчтойчивостиИМатериал;
            }

            set
            {
                стабилизаторПоперечнойУчтойчивостиИМатериал = value;
            }
        }

        [DataMember]
        public bool НаличиеГидроручника
        {
            get
            {
                return наличиеГидроручника;
            }

            set
            {
                наличиеГидроручника = value;
            }
        }

        [DataMember]
        public bool ЗадниеДисковоыеТормоза
        {
            get
            {
                return задниеДисковоыеТормоза;
            }

            set
            {
                задниеДисковоыеТормоза = value;
            }
        }

        [DataMember]
        public int ОбъемБлокаЦилиндров
        {
            get
            {
                return объемБлокаЦилиндров;
            }

            set
            {
                объемБлокаЦилиндров = value;
            }
        }

        [DataMember]
        public string МодельИспользуемогоРаспредвала
        {
            get
            {
                return модельИспользуемогоРаспредвала;
            }

            set
            {
                модельИспользуемогоРаспредвала = value;
            }
        }

        [DataMember]
        public string МаркаКарбюраторов
        {
            get
            {
                return маркаКарбюраторов;
            }

            set
            {
                маркаКарбюраторов = value;
            }
        }

        [DataMember]
        public bool ИспользуетсяСистемаВпрыска
        {
            get
            {
                return используетсяСистемаВпрыска;
            }

            set
            {
                используетсяСистемаВпрыска = value;
            }
        }

        [DataMember]
        public string СистемаВпрыска
        {
            get
            {
                return системаВпрыска;
            }

            set
            {
                системаВпрыска = value;
            }
        }

        [DataMember]
        public string СистемаЗажигания
        {
            get
            {
                return системаЗажигания;
            }

            set
            {
                системаЗажигания = value;
            }
        }

        [DataMember]
        public float СтепеньСжатия
        {
            get
            {
                return степеньСжатия;
            }

            set
            {
                степеньСжатия = value;
            }
        }

        [DataMember]
        public float КоличествоЛС
        {
            get
            {
                return количествоЛС;
            }

            set
            {
                количествоЛС = value;
            }
        }

        [DataMember]
        public Tuple<float, _МатериалыМеталл> МассаМаховикаИМатериал
        {
            get
            {
                return массаМаховикаИМатериал;
            }

            set
            {
                массаМаховикаИМатериал = value;
            }
        }

        [DataMember]
        public bool ПрямозубаяКоробкаПередач
        {
            get
            {
                return прямозубаяКоробкаПередач;
            }

            set
            {
                прямозубаяКоробкаПередач = value;
            }
        }

        [DataMember]
        public int КоличествоСтупеней
        {
            get
            {
                return количествоСтупеней;
            }

            set
            {
                количествоСтупеней = value;
            }
        }

        [DataMember]
        public _ИспользуемыйРяд ИспользуемыйРяд
        {
            get
            {
                return используемыйРяд;
            }

            set
            {
                используемыйРяд = value;
            }
        }

        [DataMember]
        public Tuple<float, int> ГлавнаяПара
        {
            get
            {
                return главнаяПара;
            }

            set
            {
                главнаяПара = value;
            }
        }

        [DataMember]
        public bool ДополнительныйСвет
        {
            get
            {
                return дополнительныйСвет;
            }

            set
            {
                дополнительныйСвет = value;
            }
        }

        [DataMember]
        public string МодельИМаркаИспользуемогоОбвеса
        {
            get
            {
                return модельИМаркаИспользуемогоОбвеса;
            }

            set
            {
                модельИМаркаИспользуемогоОбвеса = value;
            }
        }

        [DataMember]
        public _Привод РеализуемыйПривод
        {
            get
            {
                return реализуемыйПривод;
            }

            set
            {
                реализуемыйПривод = value;
            }
        }

        [DataMember]
        public DateTime ДатаПроизводстваИсходнойМашины
        {
            get
            {
                return датаПроизводстваИсходнойМашины;
            }

            set
            {
                датаПроизводстваИсходнойМашины = value;
            }
        }

        [DataMember]
        public DateTime ДатаПроизводстваЦелевойМашины
        {
            get
            {
                return датаПроизводстваЦелевойМашины;
            }

            set
            {
                датаПроизводстваЦелевойМашины = value;
            }
        }

        [DataMember]
        public string Discipline
        {
            get
            {
                return discipline;
            }

            set
            {
                discipline = value;
            }
        }

        [DataMember]
        public int UniqCarNumber
        {
            get
            {
                return uniqCarNumber;
            }

            set
            {
                uniqCarNumber = value;
            }
        }

        [DataMember]
        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        // Название модели
        private string name = "Заводская Тольятти";

        // Название фирмы производителя
        private string manufacturer = "Тольятти";

        // Вес
        private float weight = 995;

        // Длина
        private float length = 4128;

        // Включен ли каркас безопасности
        private bool withSafetyCarcass = false;

        // Содержатся ли элементы из композитных материалов?
        private bool withCompositeMaterials = false;

        //========================= Подвеска
        private bool используетсяЗаднийСтабилизатор = false;

        /*string ТипАмортизаторов*/
        private _ТипАмортизаторов типАмортизаторов = _ТипАмортизаторов.Масло; // Масло, Газ-Масло, Газ

        private string маркаАмортизаторов = "ДААЗ";// На VFTS бильштейн используется

        // Содержится ли стабилизатор поперечной устойчивости и из какого материала он изготовлен
        //string СтабилизаторПоперечнойУчтойчивостиИМатериал; // титан, сталь, заводской-однорядный
        private Tuple<bool, _МатериалыМеталл> стабилизаторПоперечнойУчтойчивостиИМатериал = new Tuple<bool, _МатериалыМеталл>(false, _МатериалыМеталл.Заводская);

        //============================

        //========================= Тормоза
        private bool наличиеГидроручника = false;

        private bool задниеДисковоыеТормоза = false;
        //============================

        //========================= Двигатель
        private int объемБлокаЦилиндров = 1294; //1.3 двигатель

        private string модельИспользуемогоРаспредвала = "стандарт";

        private string маркаКарбюраторов = "Дааз"; // Дааз(стандарт), Солекс(экспортный вариант), Weber 45 DCOE(боевой карбюратор), dellorto 40/45(боевой карбюратор), кастомные

        private bool используетсяСистемаВпрыска = false; // Только для MTX машин и последних поколений VFTS
        private string системаВпрыска = "Не Используется"; // Только для MTX машин и последних поколений VFTS
        private string системаЗажигания = "Контактная";//Контактная, Бесконтактная

        // Мощность двигателя
        private float степеньСжатия = (float)8.5;

        private float количествоЛС = 69;//1.3 двигатель

        private Tuple<float, _МатериалыМеталл> массаМаховикаИМатериал = new Tuple<float, _МатериалыМеталл>((float)7.4, _МатериалыМеталл.Заводская); // Заводской вес сильно больше
        //=========================

        //========================= Коробка
        private bool прямозубаяКоробкаПередач = false;

        private int количествоСтупеней = 4;
        private _ИспользуемыйРяд используемыйРяд = _ИспользуемыйРяд.Стандарт;
        /*
        В стандартных переднеприводных ВАЗах применяются главные пары с передаточным отношением 3.7:1 или 3.9:1.
        Существуют варианты для тюнинга с соотношением 4.1:1, 4.3:1, 4.5:1, 4.7:1, 4.9:1, 5.1:1.
        */
        private Tuple<float, int> главнаяПара = new Tuple<float, int>((float)4.1, 1);
        //============================

        //========================= Свет
        private bool дополнительныйСвет;

        //============================

        //========================= Внешний вид
        private string модельИМаркаИспользуемогоОбвеса = "Нет"; // VFTS, MTX, Нет(заводской), другой

        //============================

        private _Привод реализуемыйПривод = _Привод.Задний;

        private DateTime датаПроизводстваИсходнойМашины = DateTime.Today;
        private DateTime датаПроизводстваЦелевойМашины = DateTime.Today;

        // Название дисциплины в которой применяется авто.
        private string discipline = "Дороги общего пользования";

        // Уникальный фабричный номер машины
        // TODO: Увеличивать инкрементно
        private int uniqCarNumber = -1;

        private float price = (float)700.0;//$
    }
}
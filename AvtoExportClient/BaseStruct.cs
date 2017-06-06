﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoExportClient
{
    // Количество облегченных детелаей. Просто счетчик

    class BaseCar
    {
        enum _МатериалыМеталл
        {
            Заводская,
            УсиленнаяСталь,
            Титан,
            Алюминий
        }
        enum _МатериалыОбщие
        {
            Заводская = 0,
            УсиленнаяСталь,
            Титан,
            Алюминий,
            Углепластик,
            Стекловолокно
        }
        enum _ТипАмортизаторов
        {
            Масло = 0,
            ГазМасло,
            Газ
        }
        enum _Привод
        {
            Задний = 0,
            Передний,
            Полный
        };
        enum _ИспользуемыйРяд
        {
            Стандарт = 0,
            R1,
            R2, R3, R4, R5, R505
        }

        // Название модели
        string Name = "Заводская Тольятти";
        // Название фирмы производителя
        string Manufacturer = "Тольятти";
        // Вес
        float Weight = 995;
        // Длина
        float Length = 4128;

        // Включен ли каркас безопасности
        bool WithSafetyCarcass = false;
        // Содержатся ли элементы из композитных материалов?
        bool withCompositeMaterials = false;


        //========================= Подвеска
        bool ИспользуетсяЗаднийСтабилизатор = false;
        /*string ТипАмортизаторов*/
        _ТипАмортизаторов ТипАмортизаторов = _ТипАмортизаторов.Масло; // Масло, Газ-Масло, Газ

        string МаркаАмортизаторов = "ДААЗ";// На VFTS бильштейн используется

        // Содержится ли стабилизатор поперечной устойчивости и из какого материала он изготовлен
        //string СтабилизаторПоперечнойУчтойчивостиИМатериал; // титан, сталь, заводской-однорядный
        Tuple<bool, _МатериалыМеталл> СтабилизаторПоперечнойУчтойчивостиИМатериал = new Tuple<bool, _МатериалыМеталл>(false, _МатериалыМеталл.Заводская);
        //============================ 


        //========================= Тормоза
        bool НаличиеГидроручника = false;
        bool ЗадниеДисковоыеТормоза = false;
        //============================ 

        //========================= Двигатель
        int ОбъемБлокаЦилиндров = 1294; //1.3 двигатель
        string МодельИспользуемогоРаспредвала = "стандарт";

        string МаркаКарбюраторов = "Дааз"; // Дааз(стандарт), Солекс(экспортный вариант), Weber 45 DCOE(боевой карбюратор), dellorto 40/45(боевой карбюратор), кастомные

        bool ИспользуетсяСистемаВпрыска = false; // Только для MTX машин и последних поколений VFTS
        string СистемаВпрыска = "Не Используется"; // Только для MTX машин и последних поколений VFTS
        string СистемаЗажигания = "Контактная";//Контактная, Бесконтактная

        // Мощность двигателя
        float СтепеньСжатия = (float)8.5;
        float КоличествоЛС = 69;//1.3 двигатель
        //========================= 

        //========================= Коробка
        bool ПрямозубаяКоробкаПередач = false;
        int КоличествоСтупеней = 4;
        _ИспользуемыйРяд ИспользуемыйРяд = _ИспользуемыйРяд.Стандарт;
        /* 
        В стандартных переднеприводных ВАЗах применяются главные пары с передаточным отношением 3.7:1 или 3.9:1.
        Существуют варианты для тюнинга с соотношением 4.1:1, 4.3:1, 4.5:1, 4.7:1, 4.9:1, 5.1:1.
        */
        Tuple<float, int> ГлавнаяПара = new Tuple<float, int>((float)4.1, 1);
        //============================ 

        //========================= Свет
        bool ДополнительныйСвет;
        //============================ 

        //========================= Внешний вид
        string МодельИМаркаИспользуемогоОбвеса = "Нет"; // VFTS, MTX, Нет(заводской), другой
        //============================ 


        _Привод РеализуемыйПривод = _Привод.Задний;

        DateTime датаПроизводстваИсходнойМашины = DateTime.Today;
        DateTime датаПроизводстваЦелевойМашины = DateTime.Today;

        // Название дисциплины в которой применяется авто.
        string Discipline = "Дороги общего пользования";

        // Уникальный фабричный номер машины
        int UniqCarNumber = -1;
    }

    class VFTS_Model_1 : BaseCar
    { }
}

﻿using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace AvtoExportClient
{
    //ВФТС Базовая Модель без алюминиевых деталей(WithSafetyCarcass)
    [Serializable]
    public class VFTS_Base : BaseCar
    {
        public VFTS_Base()
        {
            //==============БАЗОВАЯ МОДЕЛЬ//==============
            Name = "ВФТС Базовая Модель";
            Manufacturer = "ВФТС";
            Weight = 980;
            Length = 4090;
            // Включен ли каркас безопасности
            WithSafetyCarcass = true;

            // Содержатся ли элементы из композитных материалов?
            WithCompositeMaterials = false;
            //============================================
            //==============Подвеска======================
            ИспользуетсяЗаднийСтабилизатор = false;
            ТипАмортизаторов = _ТипАмортизаторов.ГазМасло;
            МаркаАмортизаторов = "Bilstein";
            СтабилизаторПоперечнойУчтойчивостиИМатериал = new Tuple<bool, _МатериалыМеталл>(true, _МатериалыМеталл.УсиленнаяСталь);

            //============================================

            //========================= Свет
            ДополнительныйСвет = true;
            //============================

            //========================= Внешний вид
            МодельИМаркаИспользуемогоОбвеса = "VFTS";
            //============================

            РеализуемыйПривод = _Привод.Задний;

            //========================= Тормоза
            НаличиеГидроручника = true;
            ЗадниеДисковоыеТормоза = true;
            //============================

            //========================= Двигатель
            /*
            Маховик проточенный по Сингуринди, вес 4.7 кг
            Маховик проточенный по моему чертежу, вес 3.2 кг
            Маховик штатный, вес 7.4
            */
            МассаМаховикаИМатериал = new Tuple<float, _МатериалыМеталл>((float)4.7, _МатериалыМеталл.УсиленнаяСталь); // Заводской вес сильно больше

            // Мощность двигателя
            СтепеньСжатия = (float)11.5;
            ОбъемБлокаЦилиндров = 1588;
            КоличествоЛС = 160;//1.6 двигатель
            МодельИспользуемогоРаспредвала = "VFTS-1";
            МаркаКарбюраторов = "Weber 45 DCOE";
            ИспользуетсяСистемаВпрыска = false;
            СистемаВпрыска = "Не Используется";
            СистемаЗажигания = "Бесконтактная";

            //========================= Коробка
            ПрямозубаяКоробкаПередач = false;
            КоличествоСтупеней = 4;
            ИспользуемыйРяд = _ИспользуемыйРяд.R3;

            // ГлавнаяПара без изменений
            //============================================

            // Название дисциплины в которой применяется авто.
            Discipline = "Ралли";

            Price = 20000;
        }
        
    }
}
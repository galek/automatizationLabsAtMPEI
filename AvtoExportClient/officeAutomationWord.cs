using Microsoft.Office.Interop.Word;
using System;
using System.Windows.Forms;

namespace AvtoExportClient
{
    static class officeAutomationWord
    {
        public static void CreateDocument(string _номердоговора, string _имязаказчика, int _количествомашин,
           System.Windows.Controls.DataGrid _cars)
        {
            if (_количествомашин <= 0)
            {
                MessageBox.Show("Пустой заказ или машины не добавлены в обработку");
                return;
            }

            try
            {
                //Create an instance for word app
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //Заголовок документа
                winword.Documents.Application.Caption = "Договор №" + _номердоговора + "-" + _имязаказчика;

                //Create a new document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Добавление верхнего колонтитула
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[
                    Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(
                   headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment =
                   Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex =
                   Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Верхний колонтитул" + Environment.NewLine + "Договор №" + _номердоговора + "-" + _имязаказчика;
                }

                //Добавление нижнего колонтитула
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //
                    Microsoft.Office.Interop.Word.Range footerRange =
            wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    //Установка цвета текста
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    //Размер
                    footerRange.Font.Size = 10;
                    //Установка расположения по центру
                    footerRange.ParagraphFormat.Alignment =
                        Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    //Установка текста для вывода в нижнем колонтитуле
                    footerRange.Text = "Нижний колонтитул" + Environment.NewLine + "";
                }

                //Добавление текста в документ
                document.Content.SetRange(0, 0);
                document.Content.Text = "Договор №" + _номердоговора + "-" + _имязаказчика + Environment.NewLine;

                //Добавление текста со стилем Заголовок 1
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Заголовок 1";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Договор №" + _номердоговора + "-" + _имязаказчика;
                para1.Range.InsertParagraphAfter();

                //Создание таблицы 4хn
                Table firstTable = document.Tables.Add(para1.Range, _количествомашин + 1, 4, ref missing, ref missing);

                firstTable.Borders.Enable = 1;

                foreach (Row row in firstTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {

                        //Заголовок таблицы
                        if (cell.RowIndex == 1)
                        {
                            // Базовая структура
                            if (cell.ColumnIndex == 1)
                            {
                                cell.Range.Text = "Название модели";
                                cell.Range.Font.Bold = 1;
                                //Задаем шрифт и размер текста
                                cell.Range.Font.Name = "verdana";
                                cell.Range.Font.Size = 10;
                                cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                                //Выравнивание текста в заголовках столбцов по центру
                                cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            else if (cell.ColumnIndex == 2)
                            {
                                cell.Range.Text = "Уникальный фабричный номер";
                                cell.Range.Font.Bold = 1;
                                //Задаем шрифт и размер текста
                                cell.Range.Font.Name = "verdana";
                                cell.Range.Font.Size = 10;
                                cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                                //Выравнивание текста в заголовках столбцов по центру
                                cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            else
                            if (cell.ColumnIndex == 3)
                            {
                                cell.Range.Text = "Дата производства исходной машины";
                                cell.Range.Font.Bold = 1;
                                //Задаем шрифт и размер текста
                                cell.Range.Font.Name = "verdana";
                                cell.Range.Font.Size = 10;
                                cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                                //Выравнивание текста в заголовках столбцов по центру
                                cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            else
                            if (cell.ColumnIndex == 4)
                            {
                                cell.Range.Text = "Дата получения машины заказчиком";
                                cell.Range.Font.Bold = 1;
                                //Задаем шрифт и размер текста
                                cell.Range.Font.Name = "verdana";
                                cell.Range.Font.Size = 10;
                                cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                                //Выравнивание текста в заголовках столбцов по центру
                                cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                        }
                        //Значения ячеек
                        else
                        {
                            // к одномерному Row-2+Column
                            BaseCar car = _cars.Items[cell.RowIndex - 2] as BaseCar;

                            if (cell.ColumnIndex == 1)
                                cell.Range.Text = car.Название_Модели.ToString();
                            else if (cell.ColumnIndex == 2)
                                cell.Range.Text = car.УникальныйФабричныйНомер.ToString();
                            else if (cell.ColumnIndex == 3)
                                cell.Range.Text = car.ДатаПроизводстваИсходнойМашины.ToString();
                            else if (cell.ColumnIndex == 4)
                                cell.Range.Text = car.ДатаПроизводстваЦелевойМашины.ToString();
                        }
                    }
                }

                _ТекстДоговора(document, missing, _количествомашин);

                //Сохранение документа
                object filename = @"C:\res\" + _номердоговора + ".docx";
                document.SaveAs(ref filename);

                if (MessageBox.Show("Document created successfully: on path:" + filename.ToString() + " Open in Word?", "Successfull", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    winword.Visible = true;
                }
                else
                {
                    //Закрытие текущего документа
                    document.Close(ref missing, ref missing, ref missing);
                    document = null;

                    //Закрытие приложения Word
                    winword.Quit(ref missing, ref missing, ref missing);
                    winword = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static private void _ТекстДоговора(Microsoft.Office.Interop.Word.Document document, object missing, int _количествомашин)
        {

            //Добавление текста со стилем Обычный
            var para1 = document.Content.Paragraphs.Add(ref missing);
            object styleHeading1 = "Обычный";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Всего заказано машин: " + _количествомашин.ToString() + Environment.NewLine;
            para1.Range.InsertParagraphAfter();


            //Добавление текста со стилем Заголовок 1
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "\nДоговор-оферта";
            para1.Range.InsertParagraphAfter();

            //Добавление текста со стилем Заголовок 1
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Строгий";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "г.Москва\n";
            para1.Range.InsertParagraphAfter();

            //Добавление текста со стилем Обычный
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Обычный";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Публичная оферта на оказание услуг представленных на сайте: ....."
                + "Данное предложение направлено директором тюнинг-ателье «Tuning Town» (далее Исполнитель) в адрес неограниченного количества физических лиц (далее Заказчик) на заключение договора по оказанию услуг тюнинг-ателье «Tuning Town» (далее Договор)."
                + "Услуги тюнинг-ателье «Tuning Town» предоставляются без подписания договора в бумажной форме на основании: Публичного договора-оферты. С момента оплаты услуг Исполнителя Заказчик автоматически принимает условия договора, и этот договор вступает в силу без подписания в каждом отдельном случае."
                + "\n";
            para1.Range.InsertParagraphAfter();

            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Общие положения";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                    "1.1. Данный документ, адресованный физическим лицам, именуемым далее по тексту «Заказчик», является официальным, публичным и безотзывным предложением директора тюнинг-ателье «Tuning Town» именуемой далее по тексту «Исполнитель», заключить договор на указанных ниже условия. \n"
                + "1.2.Полным и безоговорочным акцептом настоящей публичной оферты является осуществление Заказчиком оплаты предложенных Исполнителем услуг в порядке, определенном в разделе 5 настоящего предложения.\n"
                + "1.3.Акцепт оферты означает, что Заказчик согласен со всеми положениями настоящего предложения, и равносилен заключению договора об оказании услуг по предоставлению сервиса тюнинг - ателье «Tuning Town»." + "\n";
                para1.Range.InsertParagraphAfter();
            }
            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Предмет договора";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                    "2.1. Исполнитель оказывает Заказчику услуги по предоставлению сервиса представленном на сайте www.tuningtown.com.ua, а также оказывает Заказчику по его запросу иные дополнительные услуги из числа представленных на сайте.\n"
                    + "2.2.Заказчик оплачивает и пользуется услугами Исполнителя в соответствии с тарифами, определенными на сайте www.tuningtown.com.ua" + "\n";
                para1.Range.InsertParagraphAfter();
            }
            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Обязанности сторон";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                    "3.1. Исполнитель обязуется:\n"
                    + "3.1.1.Оказать Заказчику услуги, которые заказаны и за которые внесена 50 % -ная предоплата Заказчиком в соответствии с условиями настоящего договора.\n"
                    + "3.1.2.Выполнить услуги в срок, оговоренный с Заказчиком в порядке, определенном в разделе 6 настоящего предложения. \n"
                    + "3.1.3.Предоставить Заказчику гарантию (1 год на все выполненные работы) после внесения Исполнителю полной оплаты за услуги. \n"
                    + "3.1.4.Оказывать гарантийное обслуживание Заказчику в течении 1 года с момента выполнения работ. \n"
                    + "3.2.Заказчик обязуется:\n"
                    + "3.2.1.Ознакомиться с настоящим договором, а также самостоятельно следить за изменениями и дополнениями к условиям настоящего договора. \n"
                    + "3.2.2.Заказчику запрещается находится в помещении где ведутся работы по оказанию услуг, оговоренных с Исполнителем в целях безопасности и в некоторых случаях сохранения коммерческой тайны." + "\n";
                para1.Range.InsertParagraphAfter();
            }

            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Права сторон";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                    "4.1. Исполнитель имеет право:\n"
                    + "4.1.1.В одностороннем порядке вносить изменения и дополнения к условиям настоящего договора.\n"
                    + "4.1.2.Прерывать предоставление услуг без предупреждения Заказчика по техническим, технологическим или иным причинам, препятствующим оказанию услуг, на время устранения таких причин.\n"
                    + "4.1.3.Отказать в исполнении услуги для Заказчика, нарушающего условия настоящего договора, без уведомления и возврата средств.\n"
                    + "4.1.4.Вносить изменения в тарифы.Об изменении тарифов Исполнитель уведомляет Заказчика путем размещения соответствующей информации на сайте. Услуги, которые были оплачены до изменения тарифов, предоставляются в соответствии с теми тарифами, которые действовали на момент оплаты.\n"
                    + "4.2.Пользователь имеет право:\n"
                    + "4.2.1.Пользоваться услугами тюнинг-ателье «Tuning Town» представленными на сайте: www.tuningtown.com.ua в строгом соответствии с условиями настоящего договора.\n"
                    + "4.2.1.Пользоваться гарантийным обслуживанием. \n"
                    + "Гарантийным днем считается понедельник\n";
                para1.Range.InsertParagraphAfter();
            }

            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Условия оплаты и порядок расчетов";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                    "5.1. Цены на услуги определяются в соответствии с тарифами на сайте, либо непосредственно в офисе. \n"
                    + "5.2.Оплата услуг Исполнителя по настоящему договору осуществляется Заказчиком в виде 50 % -ной предоплаты до начала выполнения работ и 50 % оплатой после выполнения работ.\n"
                    + "5.3.Денежные средства за оказание услуг, возврату не подлежат.\n";

                para1.Range.InsertParagraphAfter();
            }

            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Сроки выполнения работ";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                   "6.1. Сроки оговариваются с Заказчиком после определения всего списка услуг, и являются индивидуальными для каждого отдельного случая.\n"
                    + "6.2.Сроки выполнения работ могут увеличится по техническим, технологическим или иным причинам, препятствующим оказанию услуг, на время устранения таких причин.\n"
                    + "6.3.Сроки могут меняться в случае изменения Заказчиком списка оказываемых услуг или отказа от некоторых из них.\n"
                    + "6.4.Исполнитель имеет право увеличить сроки Заказчику, нарушающего условия настоящего договора, без уведомления и возврата средств. \n"
                    + "6.5.Об изменении сроков Исполнитель уведомляет Заказчика путем телефонного звонка или личной встречи. \n";

                para1.Range.InsertParagraphAfter();
            }
            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Ответственность сторон";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                  "7.2. Исполнитель не несет ответственности:\n"
                + "7.2.1 За любые противоправные или иные действия Заказчика и третьих лиц, ставшие возможными благодаря предоставляемым Заказчику Исполнителем услуг сервиса;\n"
                + "7.2.2.По любым обязательствам Заказчика или третьих лиц, расходам, упущенной выгоде, а также по любым прямым или косвенным убыткам, возникшим в результате прямого или косвенного пользования услугами сервиса Заказчиком или третьими лицами;\n"
                + "7.2.3.За любые другие обстоятельства, не зависящие от воли и действий Исполнителя.\n"
                + "7.3. Заказчик самостоятельно и в полной мере несет ответственность:\n"
                + "7.3.1 За ущерб любого рода, понесенный Заказчиком или третьими лицами в ходе использования Заказчиком услуг сервиса.\n"
                + "7.4.Ответственность сторон по настоящему договору за неисполнение, либо ненадлежащее исполнение условий настоящего договора явно указана в тексте договора. Стороны не вправе требовать друг от друга возмещения каких - либо убытков или компенсации расходов в любой форме, если иное не определено условиями договора.\n";
                para1.Range.InsertParagraphAfter();
            }
            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Заголовок 2";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Заключительные положения договора\n";
                para1.Range.InsertParagraphAfter();

                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text =
                    "8.1. Настоящий договор вступает в силу с момента его акцептирования и действует до момента полного исполнения сторонами своих обязательств по настоящему договору.\n"
                    + "8.2.Вступая в настоящий договор Стороны подтверждают, что обладают всеми необходимыми полномочиями и правами для его исполнения.\n";
                para1.Range.InsertParagraphAfter();
            }
            //Добавление текста со стилем Заголовок 2
            {
                para1 = document.Content.Paragraphs.Add(ref missing);
                styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "\n Дата '___' _________201__г.\n";
                para1.Range.InsertParagraphAfter();
            }
        }

    }
}

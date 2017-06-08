using System.IO;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace AvtoExportClient
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.dataGrid.AutoGenerateColumns = true;
            this.dataGrid.AddingNewItem += RecomputePrice;
            this.dataGrid.BeginningEdit += DataGrid_BeginningEdit;
            this.dataGrid.CellEditEnding += DataGrid_CellEditEnding;
            this.dataGrid.ColumnReordered += DataGrid_ColumnReordered;
            this.dataGrid.CurrentCellChanged += DataGrid_CurrentCellChanged;
            this.dataGrid.RowEditEnding += DataGrid_RowEditEnding;
            this.dataGrid.DataContextChanged += DataGrid_DataContextChanged;
            this.dataGrid.Initialized += DataGrid_Initialized;
            this.dataGrid.Loaded += DataGrid_Loaded;


            this.dataGrid.ItemsSource = CarManager.Instance.carListOrdered;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_Initialized(object sender, System.EventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_RowEditEnding(object sender, System.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_ColumnReordered(object sender, System.Windows.Controls.DataGridColumnEventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            _RecomputePrice();
        }

        private void DataGrid_BeginningEdit(object sender, System.Windows.Controls.DataGridBeginningEditEventArgs e)
        {
            _RecomputePrice();
        }

        void _RecomputePrice()
        {
            float _price = 0;

            foreach (BaseCar car in CarManager.Instance.carListOrdered)
                _price += car.Цена;

            label_price.Content = _price + " $";
        }

        private void RecomputePrice(object sender, System.Windows.Controls.AddingNewItemEventArgs e)
        {
            float _price = 0;

            foreach (BaseCar car in CarManager.Instance.carListOrdered)
                _price += car.Цена;

            label_price.Content = _price + " $";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            {
                JavaScriptSerializer jsonFormatter = new JavaScriptSerializer();
                string res = jsonFormatter.Serialize(CarManager.Instance.carListOrdered);
                File.WriteAllText(System.Environment.CurrentDirectory + @"\cars.json", res);
            }
        }

        private void PrintItem_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // A4
                Size pageSize = new Size(900, 1200);
                // sizing of the element.
                dataGrid.Measure(pageSize);
                dataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));

                FlowDocument doc = new FlowDocument();

                int counter = 0;

                foreach (BaseCar car in this.dataGrid.ItemsSource)
                {
                    Paragraph par = new Paragraph();
                    par.Inlines.Add(car.Название_Модели.ToString() + " " + car.UniqCarNumber.ToString() + " " + car.ДатаПроизводстваИсходнойМашины + " " + car.ДатаПроизводстваЦелевойМашины + "\r\n");
                    par.Inlines.Add("___________________________________\r\n");

                    par.Margin = new Thickness(0);

                    doc.Blocks.Add(par);

                    counter++;
                }


                Paragraph p = new Paragraph();
                p.Inlines.Add("===================================\r\n");
                p.Inlines.Add("Всего заказано машин: " + counter.ToString() +" cтоимость: " + label_price.Content.ToString() + "\r\n");
                p.Margin = new Thickness(0);

                doc.Blocks.Add(p);
                doc.Name = "FlowDoc";
                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "My Printing");
            }

        }
    }
}
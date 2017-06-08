using System.Data;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            this.dataGrid_Copy.AutoGenerateColumns = true;

            this.dataGrid.AddingNewItem += RecomputePrice;
            this.dataGrid.BeginningEdit += DataGrid_BeginningEdit;
            this.dataGrid.CellEditEnding += DataGrid_CellEditEnding;
            this.dataGrid.ColumnReordered += DataGrid_ColumnReordered;
            this.dataGrid.CurrentCellChanged += DataGrid_CurrentCellChanged;
            this.dataGrid.RowEditEnding += DataGrid_RowEditEnding;
            this.dataGrid.DataContextChanged += DataGrid_DataContextChanged;
            this.dataGrid.Initialized += DataGrid_Initialized;
            this.dataGrid.Loaded += DataGrid_Loaded;
            this.dataGrid.DataContextChanged += DataGrid_DataContextChanged;

            this.dataGrid_Copy.AddingNewItem += RecomputePrice;
            this.dataGrid_Copy.BeginningEdit += DataGrid_BeginningEdit;
            this.dataGrid_Copy.CellEditEnding += DataGrid_CellEditEnding;
            this.dataGrid_Copy.ColumnReordered += DataGrid_ColumnReordered;
            this.dataGrid_Copy.CurrentCellChanged += DataGrid_CurrentCellChanged;
            this.dataGrid_Copy.RowEditEnding += DataGrid_RowEditEnding;
            this.dataGrid_Copy.DataContextChanged += DataGrid_DataContextChanged;
            this.dataGrid_Copy.Initialized += DataGrid_Initialized;
            this.dataGrid_Copy.Loaded += DataGrid_Loaded;
            this.dataGrid_Copy.DataContextChanged += DataGrid_DataContextChanged;


            this.dataGrid.ItemsSource = CarManager.Instance.carListOrdered;
            this.dataGrid_Copy.ItemsSource = CarManager.Instance.carListPreOrder;

            this.dataGrid.CanUserAddRows = false;

            this.dataGrid_Copy.CanUserAddRows = false;

            _InitConstants();
        }

        void _InitConstants()
        {
            Counters.carNumber = 1;// TODO: максимальный номер из BD
        }

        private void DataGrid_Copy_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_Initialized(object sender, System.EventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_RowEditEnding(object sender, System.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_ColumnReordered(object sender, System.Windows.Controls.DataGridColumnEventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        private void DataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("1");
            // TODO: Check in prices;
            _CheckInPrice(dataGrid_Copy.SelectedItem as BaseCar);



            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        void _CheckInPrice(BaseCar car)
        {


            //car.Цена += 9999;


            _RecomputePrice_Copy();
        }

        private void DataGrid_BeginningEdit(object sender, System.Windows.Controls.DataGridBeginningEditEventArgs e)
        {
            _RecomputePrice();
            _RecomputePrice_Copy();
        }

        void _RecomputePrice()
        {
            float _price = 0;

            foreach (BaseCar car in CarManager.Instance.carListOrdered)
                _price += car.Цена;

            label_price.Content = _price + " $";
        }

        void _RecomputePrice_Copy()
        {
            float _price = 0;

            foreach (BaseCar car in CarManager.Instance.carListPreOrder)
                _price += car.Цена;

            label_price_Copy.Content = _price + " $";
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
                    par.Inlines.Add(car.Название_Модели.ToString() + " " + car.УникальныйФабричныйНомер.ToString() + " " + car.ДатаПроизводстваИсходнойМашины + " " + car.ДатаПроизводстваЦелевойМашины + "\r\n");
                    par.Inlines.Add("___________________________________\r\n");

                    par.Margin = new Thickness(0);

                    doc.Blocks.Add(par);

                    counter++;
                }


                Paragraph p = new Paragraph();
                p.Inlines.Add("===================================\r\n");
                p.Inlines.Add("Всего заказано машин: " + counter.ToString() + " cтоимость: " + label_price.Content.ToString() + "\r\n");
                p.Margin = new Thickness(0);

                doc.Blocks.Add(p);
                doc.Name = "FlowDoc";
                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "My Printing");
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid.SelectedItem == null)
                return;

            if (MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (BaseCar car in dataGrid.SelectedItems)
                {
                    if (car != null)
                        CarManager.Instance.carListOrdered.Remove(car);

                }
                this.dataGrid.ItemsSource = null;
                this.dataGrid.ItemsSource = CarManager.Instance.carListOrdered;

                _RecomputePrice();
            }
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            var car = new BaseCar();
            CarManager.Instance.carListPreOrder.Add(car);

            this.dataGrid_Copy.ItemsSource = null;
            this.dataGrid_Copy.ItemsSource = CarManager.Instance.carListPreOrder;
            _RecomputePrice_Copy();
        }

        private void VFTS_Base_Click(object sender, RoutedEventArgs e)
        {
            var car = new VFTS_Base();
            CarManager.Instance.carListPreOrder.Add(car);

            this.dataGrid_Copy.ItemsSource = null;
            this.dataGrid_Copy.ItemsSource = CarManager.Instance.carListPreOrder;
            _RecomputePrice_Copy();
        }

        private void VFTS_850_Click(object sender, RoutedEventArgs e)
        {
            var car = new VFTS_850();
            CarManager.Instance.carListPreOrder.Add(car);

            this.dataGrid_Copy.ItemsSource = null;
            this.dataGrid_Copy.ItemsSource = CarManager.Instance.carListPreOrder;
            _RecomputePrice_Copy();
        }

        private void VFTS_750_Click(object sender, RoutedEventArgs e)
        {
            var car = new VFTS_750();
            CarManager.Instance.carListPreOrder.Add(car);

            this.dataGrid_Copy.ItemsSource = null;
            this.dataGrid_Copy.ItemsSource = CarManager.Instance.carListPreOrder;
            _RecomputePrice_Copy();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid_Copy.SelectedItem == null)
                return;

            if (MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (BaseCar car in dataGrid_Copy.SelectedItems)
                {
                    if (car != null)
                        CarManager.Instance.carListPreOrder.Remove(car);

                }
                this.dataGrid_Copy.ItemsSource = null;
                this.dataGrid_Copy.ItemsSource = CarManager.Instance.carListPreOrder;

                _RecomputePrice_Copy();
            }
        }
    }
}
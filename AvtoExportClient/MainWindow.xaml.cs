using System.IO;
using System.Web.Script.Serialization;
using System.Windows;

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
    }
}
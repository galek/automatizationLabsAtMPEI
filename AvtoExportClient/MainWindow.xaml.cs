using System.Windows;
using System.IO;
using System.Web.Script.Serialization;

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
            this.dataGrid.ItemsSource = CarManager.Instance.carList;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            {
                JavaScriptSerializer jsonFormatter = new JavaScriptSerializer();
                string res = jsonFormatter.Serialize(CarManager.Instance.carList);
                File.WriteAllText(System.Environment.CurrentDirectory + @"\cars.json", res);
            }
        }
    }
}

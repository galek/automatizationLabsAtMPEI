using System.Windows.Forms;

namespace AvtoExportClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            foreach (BaseCar car in m_carManager.carList)
            {
                listView1.Items.Add(car.Name);
            }
        }

        static CarManager m_carManager = CarManager.Instance;
    }
}

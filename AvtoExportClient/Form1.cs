using System.Windows.Forms;

namespace AvtoExportClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _Load();
        }

        private void _Load()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = m_carManager.carList;
        }

        private static CarManager m_carManager = CarManager.Instance;
    }
}
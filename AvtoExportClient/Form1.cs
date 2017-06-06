using System.Collections.Generic;
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
            //foreach (BaseCar car in m_carManager.carList)
            //{
            //    listView1.Items.Add(car.Name);
            //}

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = m_carManager.carList;

        }

        static CarManager m_carManager = CarManager.Instance;
    }
    

}

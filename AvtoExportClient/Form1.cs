using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvtoExportClient;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(System.Windows.Controls.DataGrid _grid, int _count)
        {
            grid = _grid;
            ItemsCount = _count;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Counters.ИмяЗаказчика = this.textBox1.Text;
            officeAutomationWord.CreateDocument(Counters.НомерЗаказа.ToString() + "(Клиент)", Counters.ИмяЗаказчика, ItemsCount, this.grid);
            officeAutomationWord.CreateDocument(Counters.НомерЗаказа.ToString() + "(Салон)", Counters.ИмяЗаказчика, ItemsCount, this.grid);
            Counters.НомерЗаказа++;

            this.Dispose();
        }

        public System.Windows.Controls.DataGrid grid = null;
        public int ItemsCount = 0;
    }
}

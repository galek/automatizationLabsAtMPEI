using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;

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

            dataGridView1.CellPainting += DataGridView1_CellPainting;



        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //var q = from x in m_carManager.carList
            //        group x by x into g
            //        let count = g.Count()
            //        orderby count descending
            //        select new { Value = g.Key, Count = count };

            //    var q = dataGridView1.Rows.OfType<DataGridViewRow>()
            //.GroupBy(x => x.Cells["Name"].Value.ToString())
            //.Select(g => new { Value = g.Key, Count = g.Count(), Rows = g.ToList() })
            //.OrderByDescending(x => x.Count);


        }

        void Group()
        {
            if (m_carManager.carList.Count != 0)
            {
                var dtCoaching = new DataTable();

                dtCoaching.Columns.AddRange(new[]
                {
                    new DataColumn("Call Type"),  new DataColumn("Count")
                });

                foreach (var oListItem in m_carManager.carList)
                {
                    //oListItem["Call_x0020_Type"]
                    dtCoaching.Rows.Add("TEST");
                }

                var result = from row in dtCoaching.AsEnumerable()
                             group row by row.Field<string>("Call Type") into grp
                             select new
                             {
                                 CallType = grp.Key,
                                 CallCount = grp.Count()
                             };

                DataTable dtCoachingClone = new DataTable();
                dtCoachingClone = dtCoaching.Clone();

                foreach (var item in result)
                {
                    DataRow newRow = dtCoachingClone.NewRow();
                    newRow["Call Type"] = item.CallType;
                    newRow["Count"] = item.CallCount;
                    dtCoachingClone.Rows.Add(newRow);
                }

                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = dtCoachingClone;
                }

                return;
            }
        }

        private static CarManager m_carManager = CarManager.Instance;

        private void button1_Click(object sender, System.EventArgs e)
        {
            {
                JavaScriptSerializer jsonFormatter = new JavaScriptSerializer();
                string res = jsonFormatter.Serialize(m_carManager.carList);
                File.WriteAllText(System.Environment.CurrentDirectory + @"\cars.json", res);
            }
        }
    }
}
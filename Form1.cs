using Crystal_Report_Demo.bin.Debug;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystal_Report_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();
            Form2 f2 = new Form2();
            f2.Show();

            string connetionString;
            SqlConnection cnn;
            connetionString = @"data source=DESKTOP-6KNAVMC\SQLEXPRESS01;initial catalog=TaskManegement;persist security info=True;Integrated Security=SSPI;";
            cnn = new SqlConnection(connetionString);
            if(cnn.State != ConnectionState.Open)
            {

                cnn.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from Task", cnn);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Task");

            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            CrystalReport1 rp = new CrystalReport1();
            rp.SetDataSource(ds);
            //f2.

            //f2.cr.ReportSource = rp;
            f2.crystalReportViewer1.ReportSource = rp;
            f2.crystalReportViewer1.Refresh();

            //MessageBox.Show("Connection Open  !");
            cnn.Close();
        }
    }
}

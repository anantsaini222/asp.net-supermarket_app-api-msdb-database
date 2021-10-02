using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Supermarket
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        SqlConnection Con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=msdb;Integrated Security=True");
        SqlConnection Con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=msdb;Integrated Security=True");
        SqlConnection Con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=msdb;Integrated Security=True");

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(SellerId) from SellerTbl",Con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblseller.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select max(ProdId) from ProductTbl", Con2);
            DataTable dt1 = new DataTable();
            sda2.Fill(dt1);
            lblProd.Text = dt1.Rows[0][0].ToString();


            SqlDataAdapter sda3 = new SqlDataAdapter("select max(BillId) from BillTbl", Con3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            lblOrder.Text = dt3.Rows[0][0].ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SellerForm sell = new SellerForm();
            sell.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductForm prodf = new ProductForm();
            prodf.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}

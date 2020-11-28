using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garment_Management_System
{
    public partial class Monthlt_Activity_Class : Form
    {
        public string whoLoggedIn;
        DataClasses1DataContext db = new DataClasses1DataContext();
        CurrentOrder orDb = new CurrentOrder();
        Employee emDb = new Employee();

        public Monthlt_Activity_Class()
        {
            InitializeComponent();
        }

        private void Monthlt_Activity_Class_Load(object sender, EventArgs e)
        {
            var prods = from p in db.CurrentOrders
                        select new { p.order_name, p.buyer_pays, p.estimated_cost };
            dataGridView1.DataSource = prods;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ///-------grid view done

            ///first
            CurrentOrder first = db.CurrentOrders.SingleOrDefault(x => x.Id == 1);
            string b1 = first.buyer_pays.ToString();
            string e1 = first.estimated_cost.ToString();

            ///second
            CurrentOrder second = db.CurrentOrders.SingleOrDefault(x => x.Id == 2);
            string b2 = second.buyer_pays.ToString();
            string e2 = second.estimated_cost.ToString();

            ///third
            CurrentOrder third = db.CurrentOrders.SingleOrDefault(x => x.Id == 3);
            string b3 = third.buyer_pays.ToString();
            string e3 = third.estimated_cost.ToString();

            ///forth
            CurrentOrder forth = db.CurrentOrders.SingleOrDefault(x => x.Id == 4);
            string b4 = forth.buyer_pays.ToString();
            string e4 = forth.estimated_cost.ToString();

            ///chart
            this.chart1.Series["Buyer Pay"].Points.AddXY("Order 1", Convert.ToInt32(b1));
            this.chart1.Series["Estimated Cost"].Points.AddXY("Order 1", Convert.ToInt32(e1));

            this.chart1.Series["Buyer Pay"].Points.AddXY("Order 2", Convert.ToInt32(b2));
            this.chart1.Series["Estimated Cost"].Points.AddXY("Order 2", Convert.ToInt32(e2));

            this.chart1.Series["Buyer Pay"].Points.AddXY("Order 3", Convert.ToInt32(b3));
            this.chart1.Series["Estimated Cost"].Points.AddXY("Order 3", Convert.ToInt32(e3));

            this.chart1.Series["Buyer Pay"].Points.AddXY("Order 4", Convert.ToInt32(b4));
            this.chart1.Series["Estimated Cost"].Points.AddXY("Order 4", Convert.ToInt32(e4));

            ///chart done

            ///total worker salary
            var salaryWorker = from p in db.Employees
                               select p.sallery;

            textBox2.Text = salaryWorker.Sum().ToString() + "$";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeObj = new Home();
            homeObj.whoLoggedIn = this.whoLoggedIn;
            homeObj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class CurrentOrderClass : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        CurrentOrder crDb = new CurrentOrder();

        public CurrentOrderClass()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void CurrentOrderClass_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.CurrentOrders;
            comboBox1.DisplayMember = "order_name";
            comboBox1.ValueMember = "id";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeObj = new Home();
            homeObj.whoLoggedIn = this.whoLoggedIn;
            homeObj.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///searching
            string name = comboBox1.Text;
            crDb = db.CurrentOrders.SingleOrDefault(x => x.order_name == name);
            if (crDb != null)
            {

                textBox5.Text = crDb.order_name;
                textBox1.Text = crDb.client;
                textBox2.Text = crDb.quantity.ToString();
                textBox3.Text = crDb.shipment_date;
                textBox4.Text = crDb.buyer_pays.ToString();
                textBox6.Text = crDb.estimated_cost.ToString();
                textBox7.Text = "Click To Calculate";

                pictureBox1.ImageLocation = crDb.sample.ToString();
                pictureBox1.Show();
                
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = (Convert.ToInt32(textBox4.Text) - Convert.ToInt32(textBox6.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buyer_Details newObj = new Buyer_Details();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.whoIsBuyer = textBox1.Text;
            newObj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ///delete order
            string fullName = textBox5.Text;
            CurrentOrder dltOrder = db.CurrentOrders.SingleOrDefault(x => x.order_name == fullName);
            db.CurrentOrders.DeleteOnSubmit(dltOrder);
            db.SubmitChanges();
            MessageBox.Show("Order Deleted");

            //opening this window by refershing again
            Hide();
            CurrentOrderClass newObj = new CurrentOrderClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ///Update Order

            try
            {
                string fullName = textBox5.Text;
                CurrentOrder upDb = db.CurrentOrders.SingleOrDefault(x => x.order_name == fullName);

                upDb.quantity = int.Parse(textBox2.Text);
                upDb.shipment_date = textBox3.Text;
                upDb.buyer_pays = int.Parse(textBox4.Text);
                upDb.estimated_cost = int.Parse(textBox6.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                CurrentOrderClass newObj = new CurrentOrderClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }

            catch
            {
                MessageBox.Show("Order Name/Buyer Name can not be updated");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Hide();
            Add_Order newObj = new Add_Order();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }
    }
}

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
    public partial class Add_Order : Form
    {

        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Client clientDb = new Client();
        CurrentOrder crDb = new CurrentOrder();

        public Add_Order()
        {
            InitializeComponent();
        }

        private void Add_Order_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Clients;
            comboBox1.DisplayMember = "buyer_name";
            comboBox1.ValueMember = "id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            CurrentOrderClass obj = new CurrentOrderClass();
            obj.whoLoggedIn = this.whoLoggedIn;
            obj.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Hide();
            CurrentOrderClass obj = new CurrentOrderClass();
            obj.whoLoggedIn = this.whoLoggedIn;
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select an image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc1 = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc1;
                crDb.sample = picLoc1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //add new order
                crDb.order_name = textBox5.Text;
                crDb.client = comboBox1.Text;
                crDb.quantity = int.Parse(textBox2.Text);
                crDb.shipment_date = textBox3.Text;
                crDb.buyer_pays = float.Parse(textBox4.Text);
                crDb.estimated_cost = float.Parse(textBox6.Text);


                db.CurrentOrders.InsertOnSubmit(crDb);
                db.SubmitChanges();
                //db.ExecuteNonQuery();


                MessageBox.Show("Order Inserted");
            }
            catch
            {
                MessageBox.Show("Wrong Input");
            }
        }
    }
}

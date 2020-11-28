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
    public partial class InventoryClass : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Inventory invenDb = new Inventory();

        public InventoryClass()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = db.Inventories;
            comboBox1.DisplayMember = "product_name";
            comboBox1.ValueMember = "id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Inventories;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeObj = new Home();
            homeObj.whoLoggedIn = this.whoLoggedIn;
            homeObj.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {   
            string search_text = textBox2.Text;
            var prods = from p in db.Inventories
                        where p.product_name.Contains(search_text)
                        select new { p.Id, p.product_name, p.price_perUunit, p.amount_inStock, p.total_costStock, p.amount_needed, p.total_costNeeded };
            dataGridView1.DataSource = prods;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var prods = from p in db.Inventories
                        select p.total_costStock;

            textBox5.Text = prods.Sum().ToString()+"$";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var prods = from p in db.Inventories
                        select p.total_costNeeded;

            textBox1.Text = prods.Sum().ToString() +"$";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ///delete product
                string proName = comboBox1.Text;
                Inventory dltProduct = db.Inventories.SingleOrDefault(x => x.product_name == proName);
                db.Inventories.DeleteOnSubmit(dltProduct);
                db.SubmitChanges();
                MessageBox.Show("Product Deleted");

                //opening this window by refershing again
                Hide();
                InventoryClass newObj = new InventoryClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }
            catch { MessageBox.Show("No Product Selected"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hide();
            Add_Inventory addObj = new Add_Inventory();
            addObj.whoLoggedIn = this.whoLoggedIn;
            addObj.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Add_Inventory : Form
    {
        public string whoLoggedIn;


        DataClasses1DataContext db = new DataClasses1DataContext();
        Inventory invenDb = new Inventory();

        public Add_Inventory()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Hide();
            InventoryClass inOb = new InventoryClass();
            inOb.whoLoggedIn = this.whoLoggedIn;
            inOb.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            InventoryClass inOb = new InventoryClass();
            inOb.whoLoggedIn = this.whoLoggedIn;
            inOb.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int totalCost = 0;
            totalCost = Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text);
            textBox3.Text = totalCost.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int totalCost = 0;
            totalCost = Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox4.Text);
            textBox6.Text = totalCost.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ///adding product
                //add client button
                invenDb.product_name = textBox5.Text;
                invenDb.price_perUunit = Convert.ToInt32(textBox1.Text);
                invenDb.amount_inStock = Convert.ToInt32(textBox2.Text);
                invenDb.total_costStock = Convert.ToInt32(textBox3.Text);
                invenDb.amount_needed = Convert.ToInt32(textBox4.Text);
                invenDb.total_costNeeded = Convert.ToInt32(textBox6.Text);


                db.Inventories.InsertOnSubmit(invenDb);
                db.SubmitChanges();
                
            }

            catch { MessageBox.Show("Incomplete Input"); }


            MessageBox.Show("Data Inserted");
        }

        private void Add_Inventory_Load(object sender, EventArgs e)
        {

        }
    }
}

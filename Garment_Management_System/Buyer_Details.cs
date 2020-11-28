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
    public partial class Buyer_Details : Form
    {
        public string whoLoggedIn;
        public string whoIsBuyer;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Client clDb = new Client();

        public Buyer_Details()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Buyer_Details_Load(object sender, EventArgs e)
        {
            clDb = db.Clients.SingleOrDefault(x => x.buyer_name == whoIsBuyer);

            if (clDb != null)
            {

                textBox5.Text = clDb.company;
                textBox1.Text = clDb.buyer_name;
                textBox2.Text = clDb.country;
                textBox3.Text = clDb.address;
                textBox4.Text = clDb.mobile_no;
                textBox6.Text = clDb.skype;
                textBox7.Text = clDb.email;

                pictureBox1.ImageLocation = clDb.image.ToString();
                pictureBox1.Show();
                //MessageBox.Show("Data Found");
            }

            //else { MessageBox.Show("Data Not Found"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Hide();
            
        }
    }
}

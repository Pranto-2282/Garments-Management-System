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
    
    public partial class ClientClass : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Client clientDb = new Client();


        public ClientClass()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeObj = new Home();
            homeObj.whoLoggedIn = this.whoLoggedIn;
            homeObj.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///searching
            string name = comboBox1.Text;
            clientDb = db.Clients.SingleOrDefault(x => x.buyer_name == name);
            if (clientDb != null)
            {

                textBox5.Text = clientDb.company;
                textBox1.Text = clientDb.buyer_name;
                textBox2.Text = clientDb.country;
                textBox3.Text = clientDb.address;
                textBox4.Text = clientDb.mobile_no;
                textBox6.Text = clientDb.skype;
                textBox7.Text = clientDb.email;

                pictureBox2.ImageLocation = clientDb.image.ToString();
                pictureBox2.Show();
                
            }
        }

        private void ClientClass_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Clients;
            comboBox1.DisplayMember = "buyer_name";
            comboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///delete client
            string fullName = textBox1.Text;
            Client dltClient = db.Clients.SingleOrDefault(x => x.buyer_name == fullName);
            db.Clients.DeleteOnSubmit(dltClient);
            db.SubmitChanges();
            MessageBox.Show("Client Deleted");

            //opening this window by refershing again
            Hide();
            ClientClass cObj = new ClientClass();
            cObj.whoLoggedIn = this.whoLoggedIn;
            cObj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Client addClObj = new Add_Client();
            addClObj.whoLoggedIn = this.whoLoggedIn;
            addClObj.Show();
        }
    }
}

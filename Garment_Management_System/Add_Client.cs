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
    public partial class Add_Client : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Client clientDb = new Client();

        public Add_Client()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            ClientClass clObj = new ClientClass();
            clObj.whoLoggedIn = this.whoLoggedIn;
            clObj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select an image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc1 = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc1;
                clientDb.image = picLoc1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add client button
            clientDb.buyer_name = textBox1.Text;
            clientDb.company = textBox5.Text;
            clientDb.country = textBox2.Text;
            clientDb.address = textBox3.Text;
            clientDb.mobile_no = textBox4.Text;
            clientDb.skype = textBox6.Text;
            clientDb.email = textBox7.Text;

            db.Clients.InsertOnSubmit(clientDb);
            db.SubmitChanges();
            
            MessageBox.Show("Data Inserted");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Hide();
            ClientClass obj = new ClientClass();
            obj.whoLoggedIn = this.whoLoggedIn;
            obj.Show();
        }

        private void Add_Client_Load(object sender, EventArgs e)
        {

        }
    }
}

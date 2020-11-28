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
    public partial class NoticeClass : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Notice notDb= new Notice();

        public NoticeClass()
        {
            InitializeComponent();
        }

        private void NoticeClass_Load(object sender, EventArgs e)
        {
            var prods = from p in db.Notices
                        select new { p.Date,p.Posted_By,p.Message };
            dataGridView1.DataSource = prods;

            comboBox1.DataSource = db.Notices;
            comboBox1.DisplayMember = "Date";
            comboBox1.ValueMember = "id";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (whoLoggedIn == "admin")
            {
                button4.Enabled = false;
                button5.Enabled = false;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }




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

        private void button5_Click(object sender, EventArgs e)
        {
            ///adding notice
            notDb.Posted_By = whoLoggedIn;
            notDb.Message = textBox1.Text;
            notDb.Date = DateTime.Now.ToString();


            db.Notices.InsertOnSubmit(notDb);
            db.SubmitChanges();

            MessageBox.Show("Notice Posted");


            Hide();
            NoticeClass newObj = new NoticeClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ///delete employee
            string time = comboBox1.Text;
            Notice objNew = db.Notices.SingleOrDefault(x => x.Date == time);
            db.Notices.DeleteOnSubmit(objNew);
            db.SubmitChanges();
            MessageBox.Show("Notice Deleted");

            //opening this window by refershing again
            Hide();
            NoticeClass nObj = new NoticeClass();
            nObj.whoLoggedIn = this.whoLoggedIn;
            nObj.Show();
        }
    }
}

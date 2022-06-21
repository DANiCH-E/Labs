using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Music_Shop
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            MusicDisc musdisk = new MusicDisc();
            musdisk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            Buyers buyer = new Buyers();
            buyer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            Seller adminmenu = new Seller();
            adminmenu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            DiskSale adminmenu = new DiskSale();
            adminmenu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            Prices adminmenu = new Prices();
            adminmenu.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            Members adminmenu = new Members();
            adminmenu.Show();
        }
    }
}

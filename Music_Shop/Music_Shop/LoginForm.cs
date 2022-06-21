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
    public partial class LoginForm : Form
    {
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Mus_shop.mdb";
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Mus_shop.mdb";
        private OleDbConnection myConnection;
        public LoginForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 64);

            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            
            var loginUser = loginField.Text;
            var passUser = passField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            OleDbDataAdapter adapter = new OleDbDataAdapter();

            string queryString = $"SELECT * FROM Users WHERE Groups = @uL AND Pass = @pU";
            OleDbCommand command = new OleDbCommand(queryString, db.GetConnection());
            command.Parameters.Add("@uL", OleDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", OleDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count ==1 && loginUser == "Admin")
            {
                
                AdminMenu formad = new AdminMenu();
                this.Hide();
                formad.ShowDialog();
                this.Show();
            } else if (table.Rows.Count == 1 && loginUser == "User")
            {
                UserMenu form1 = new UserMenu();
                this.Hide();
                form1.ShowDialog();
                this.Show();
            }

            else
              MessageBox.Show("Неверный пароль!");
            loginField.Clear();
            passField.Clear();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

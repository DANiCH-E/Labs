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
    public partial class AddForm_Buyer : Form
    {
        public AddForm_Buyer()
        {
            InitializeComponent();
        }
        DB db = new DB();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var name = NameText.Text;
            var alb = FamText.Text;
            var genre = DadText.Text;
            var count = NumText.Text;
            var year = EmailText.Text;
        


            var addQuery = "INSERT INTO Buyer (Фамилия, Имя, Отчество, Контактный_номер, Электронный_адрес) VALUES (@name, @alb, @genre, @count, @year)";
            var command = new OleDbCommand(addQuery, db.GetConnection());
            command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
            command.Parameters.Add("@alb", OleDbType.VarChar).Value = alb;
            command.Parameters.Add("@genre", OleDbType.VarChar).Value = genre;
            command.Parameters.Add("@count", OleDbType.VarChar).Value = count;
            command.Parameters.Add("@year", OleDbType.VarChar).Value = year;
            command.ExecuteNonQuery();

            this.Hide();
            db.closeConnection();
        }
    }
}

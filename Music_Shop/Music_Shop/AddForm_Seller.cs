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
    public partial class AddForm_Seller : Form
    {
        DB db = new DB();
        public AddForm_Seller()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var name = FamText.Text;
            var alb = NameText.Text;
            var genre = DadText.Text;
            var count = NumText.Text;
            

            var addQuery = "INSERT INTO Sellers (Фамилия, Имя, Отчество, Контактный_номер) VALUES (@name, @alb, @genre, @count)";
            var command = new OleDbCommand(addQuery, db.GetConnection());
            command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
            command.Parameters.Add("@alb", OleDbType.VarChar).Value = alb;
            command.Parameters.Add("@genre", OleDbType.VarChar).Value = genre;
            command.Parameters.Add("@count", OleDbType.VarChar).Value = count;
            
            command.ExecuteNonQuery();

            this.Hide();
            db.closeConnection();
        }
    }
}

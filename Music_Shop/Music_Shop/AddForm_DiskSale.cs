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

    public partial class AddForm_DiskSale : Form
    {
        public AddForm_DiskSale()
        {
            InitializeComponent();
        }
        DB db = new DB();

        private void button5_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var name = Name_Text.Text;
            var alb = AlbText.Text;
            var genre = Genre.Text;
            var count = Count.Text;
            var year = Year.Text;
            


            var addQuery = "INSERT INTO DiskSale (Название_диска, Продавец, Покупатель, Цена_диска, Дата_покупки) VALUES (@name, @alb, @genre, @count, @year)";
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

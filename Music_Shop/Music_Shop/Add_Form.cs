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
    public partial class Add_Form : Form
    {
        DB db = new DB();

        public Add_Form()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var name = Name_Text.Text;
            var alb = AlbText.Text;
            var genre = Genre.Text;
            var count = Count.Text;
            var year = Year.Text;
            var songs = Songs.Text;
            var memb = Members.Text;


            var addQuery = "INSERT INTO MusDisk (Название_группы, Название_альбома, Жанр, Количество, Год_выпуска, Песни, Участники) VALUES (@name, @alb, @genre, @count, @year, @songs, @memb)";
            var command = new OleDbCommand(addQuery, db.GetConnection());
            command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
            command.Parameters.Add("@alb", OleDbType.VarChar).Value = alb;
            command.Parameters.Add("@genre", OleDbType.VarChar).Value = genre;
            command.Parameters.Add("@count", OleDbType.VarChar).Value = count;
            command.Parameters.Add("@year", OleDbType.VarChar).Value = year;
            command.Parameters.Add("@songs", OleDbType.VarChar).Value = songs;
            command.Parameters.Add("@memb", OleDbType.VarChar).Value = memb;
            command.ExecuteNonQuery();

            this.Hide();
            db.closeConnection();
        }
    }
}

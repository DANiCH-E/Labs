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
    public partial class Form1 : Form
    {
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Mus_shop.mdb";
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Mus_shop.mdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT Название_группы FROM MusDisk WHERE ID_Диска = 2";
            OleDbCommand command = new OleDbCommand(query, myConnection);
          
            textBox1.Text = command.ExecuteScalar().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT Название_группы, Название_альбома, Жанр FROM MusDisk ORDER BY ID_Диска";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString() + ' ' + reader[1].ToString() + ' ' + reader[2].ToString());
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO MusDisk (Название_группы, Название_альбома, Жанр) VALUES ('AC/DC','Back in Black', 'РОК')";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            command.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "UPDATE MusDisk SET Название_альбома = 'Night of Opera' WHERE Название_группы = 'Queen'";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            command.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM MusDisk WHERE Название_группы = 'AC/DC'";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            command.ExecuteNonQuery();
        }
    }
}

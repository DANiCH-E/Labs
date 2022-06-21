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
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
            LoadData();
        }
        public OleDbConnection myConnection = new OleDbConnection(connectString);
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Mus_shop.mdb";
        private void BackButton_Click(object sender, EventArgs e)
        {
            LoginForm formad = new LoginForm();
            this.Hide();
            formad.Show();
            
        }
        private void LoadData()
        {


            myConnection.Open();

            string query = "SELECT * FROM MusDisk ORDER BY ID_Диска";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }
            reader.Close();
            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            String GroupName = textBox1.Text;
            string query = "SELECT ID_Диска, Название_группы, Название_альбома FROM MusDisk WHERE Название_группы = @gN";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.Add("@gN", OleDbType.VarChar).Value = GroupName;
            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();
            myConnection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            textBox1.Clear();
        }

        private void ShowAllDisks_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        int selectedRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                ID_Text.Text = row.Cells[0].Value.ToString();
                Name_Text.Text = row.Cells[1].Value.ToString();
                AlbText.Text = row.Cells[2].Value.ToString();
                Genre.Text = row.Cells[3].Value.ToString();
                Count.Text = row.Cells[4].Value.ToString();
                Year.Text = row.Cells[5].Value.ToString();
                Songs.Text = row.Cells[6].Value.ToString();
                Members.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}

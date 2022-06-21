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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    
    public partial class MusicDisc : Form
    {
        int selectedRow;
        public MusicDisc()
        {
            InitializeComponent();
            LoadData();
        }
        public OleDbConnection myConnection = new OleDbConnection(connectString);
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Mus_shop.mdb";
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

        private void MusicDisc_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        

        private void ShowAllDisks_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Form addfrm = new Add_Form();
            addfrm.Show();

        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[8].Value = RowState.Deleted;
                return;
            }
        }

        private void ClearFields()
        {
            ID_Text.Text = "";
            Name_Text.Text = "";
            AlbText.Text = "";
            Genre.Text = "";
            Count.Text = "";
            Year.Text = "";
            Songs.Text = "";
            Members.Text = "";
        }

        private void Update()
        {
           DB db = new DB();
           db.openConnection();
            for (int index = 0; index <= dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[8].Value;

                if (rowState == RowState.Existed)
                    continue;
                if(rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = "DELETE * FROM MusDisk WHERE ID_Диска = @id";
                    var command = new OleDbCommand(deleteQuery, db.GetConnection());
                    command.Parameters.Add("@id", OleDbType.Integer).Value = id;
                    command.ExecuteNonQuery();
                }
                if(rowState ==RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var alb = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var genre = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var count = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var year = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var songs = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var memb = dataGridView1.Rows[index].Cells[7].Value.ToString();

                    var changeQuery = "UPDATE MusDisk SET ID_Диска = @id, Название_группы = @name, Название_альбома = @alb, Жанр = @genre, Количество = @count, Год_выпуска = @year, Песни = @songs, Участники = @memb WHERE ID_Диска = @id";
                    var command = new OleDbCommand(changeQuery, db.GetConnection());
                    command.Parameters.Add("@id", OleDbType.VarChar).Value = id;
                    command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
                    command.Parameters.Add("@alb", OleDbType.VarChar).Value = alb;
                    command.Parameters.Add("@genre", OleDbType.VarChar).Value = genre;
                    command.Parameters.Add("@count", OleDbType.VarChar).Value = count;
                    command.Parameters.Add("@year", OleDbType.VarChar).Value = year;
                    command.Parameters.Add("@songs", OleDbType.VarChar).Value = songs;
                    command.Parameters.Add("@memb", OleDbType.VarChar).Value = memb;
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var SelectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var name = Name_Text.Text;
            var alb = AlbText.Text;
            var genre = Genre.Text;
            var count = Count.Text;
            var year = Year.Text;
            var songs = Songs.Text;
            var memb = Members.Text;

            if (dataGridView1.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[SelectedRowIndex].SetValues(name, alb, genre, count, year, songs, memb);
                dataGridView1.Rows[SelectedRowIndex].Cells[7].Value = RowState.Modified;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            AdminMenu adminmenu= new AdminMenu();
            adminmenu.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

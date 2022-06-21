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
    public partial class Prices : Form
    {
        public Prices()
        {
            InitializeComponent();
            LoadData();
        }
        public OleDbConnection myConnection = new OleDbConnection(connectString);
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Mus_shop.mdb";
        int selectedRow;
        private void LoadData()
        {


            myConnection.Open();

            string query = "SELECT * FROM Цена_Диска ORDER BY ID_Цены";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
               
            }
            reader.Close();
            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Prices_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            this.Hide();
            AdminMenu adminmenu = new AdminMenu();
            adminmenu.Show();
        }

        private void ShowAllDisks_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void Update()
        {
            DB db = new DB();
            db.openConnection();
            for (int index = 0; index <= dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = "DELETE * FROM Цена_Диска WHERE ID_Цены = @id";
                    var command = new OleDbCommand(deleteQuery, db.GetConnection());
                    command.Parameters.Add("@id", OleDbType.Integer).Value = id;
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var alb = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var genre = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    

                    var changeQuery = "UPDATE Цена_Диска SET ID_Цены = @id, Цена = @name, Скидка(%) = @alb, Цена_с_учетом_скидки = @genre WHERE ID_Цены = @id";
                    var command = new OleDbCommand(changeQuery, db.GetConnection());
                    command.Parameters.Add("@id", OleDbType.VarChar).Value = id;
                    command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
                    command.Parameters.Add("@alb", OleDbType.VarChar).Value = alb;
                    command.Parameters.Add("@genre", OleDbType.VarChar).Value = genre;
                    
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
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
        private void Change()
        {
            var SelectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var name = Name_Text.Text;
            var alb = AlbText.Text;
            var genre = Genre.Text;
            

            if (dataGridView1.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[SelectedRowIndex].SetValues(name, alb, genre);
                dataGridView1.Rows[SelectedRowIndex].Cells[3].Value = RowState.Modified;
            }
        }
        private void ClearFields()
        {
            ID_Text.Text = "";
            Name_Text.Text = "";
            AlbText.Text = "";
            Genre.Text = "";
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update();
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
                
            }
        }
    }
}

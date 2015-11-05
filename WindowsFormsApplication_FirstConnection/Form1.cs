using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication_FirstConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string connectionString = "Server=HAZAR-NOTEBOOK;Database=User_Role_Sample;User Id=sa;Password=123456789?";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertUpdate_Role", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", txtRoleName.Text);
                command.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                btnRefresh_Click(null, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=HAZAR-NOTEBOOK;Database=User_Role_Sample;User Id=sa;Password=123456789?";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                SqlCommand command = new SqlCommand("Select_Role", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);

                connection.Open();
                command.ExecuteNonQuery();
                da.Fill(dt);
                connection.Close();

                dgvRole.DataSource = dt;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=HAZAR-NOTEBOOK;Database=User_Role_Sample;User Id=sa;Password=123456789?";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand("Delete_Role", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", asd);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                btnRefresh_Click(null, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            string connectionString = "Server=HAZAR-NOTEBOOK;Database=User_Role_Sample;User Id=sa;Password=123456789?";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertUpdate_Role", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", asd);
                command.Parameters.AddWithValue("@Name", txtRoleName.Text);
                command.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                btnRefresh_Click(null, null);
            }
        }

        int asd;

        private void dgvRole_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvRole.SelectedRows)
            {
                asd = Convert.ToInt32(item.Cells[0].Value.ToString());
            }
        }
    }
}

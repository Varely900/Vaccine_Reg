using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Vaccine_Reg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string link = "Data Source=LAPTOP-O8OOQLKJ;Initial Catalog=Prac_Tuesday;Integrated Security=True";
            string ID = txtID.Text;
            string Surname = txtSurname.Text;
            string Firstname = txtFirstname.Text;
            string Gender = txtGender.Text;

            SqlConnection con = new SqlConnection(link);
            string dta = "insert into Vaccine  values(@ID,@Surname,@Firstname,@Gender)";
            SqlCommand cmd = new SqlCommand(dta, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Surname", Surname);
            cmd.Parameters.AddWithValue("@Firstname", Firstname);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            if(con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("You have successfully been registered to get the vaccine");

        }
    }
}

namespace LicambaCarlosMesa
{
	using System;
	using System.Data;
	using System.Windows.Forms;
	using System.Data.SqlClient;

	public partial class FormLogin : Form
	{
		public FormLogin()
		{
			InitializeComponent();			
		}
		
		SqlConnection conexion = new SqlConnection(@"Data Source=200.122.233.51; Initial Catalog=dbLicamba; User ID=adminlicamba; Password=Licamba.123");
		
		void BtnLoginClick(object sender, EventArgs e)
		{
			Loguear(txtUser.Text, txtPassword.Text);
		}

        private void Loguear(string User, string Pass)
        {
            try
            {
                conexion.Open();
                var cmd = new SqlCommand("SELECT FistName, LastName, Email, Status, Type FROM Users WHERE Username = @User AND Password = @Pass", conexion);
                cmd.Parameters.AddWithValue("User", User);
                cmd.Parameters.AddWithValue("Pass", Pass);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][3].ToString() == "1")
                    {
                        this.Hide();
                        new FormMenu(dt.Rows[0][4].ToString(), dt.Rows[0][0].ToString()).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Datos erroneos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Login: "+ ex);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
namespace LicambaCarlosMesa
{
	using System;
	using System.Windows.Forms;

	public partial class FormMenu : Form
	{
		public FormMenu(string TypeUser, string NameUser)
		{
			InitializeComponent();
            lblType.Text = TypeUser;
            lblName.Text = NameUser;		
		}
    }
}
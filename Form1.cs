using ContactApp.Data;
using ContactApp.Models;

namespace ContactApp
{
    public partial class Form1 : Form
    {
        private readonly ContactDbContext _db = new();
        public Form1()
        {
            InitializeComponent();
            LoadContacts();
        }

        private void LoadContacts()
        {
            dgvContacts.DataSource = _db.Contacts
                .OrderBy(c => c.LastName)
                .ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact List 1.0. \nWritten by: Chris Boukongou","About");
        }
    }
}

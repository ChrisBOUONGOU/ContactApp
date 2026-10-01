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
            MessageBox.Show("Contact List 1.0. \nWritten by: Chris Boukongou", "About");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
       string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show(
                    "First name and last name are required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var contact = new Contact
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };

            _db.Contacts.Add(contact);
            _db.SaveChanges();

            LoadContacts();
            ClearFields();

            MessageBox.Show(
                "Contact added.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();

            txtFirstName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvContacts.Rows[e.RowIndex];

            txtFirstName.Text =
                row.Cells["FirstName"].Value?.ToString() ?? "";

            txtLastName.Text =
                row.Cells["LastName"].Value?.ToString() ?? "";

            txtEmail.Text =
                row.Cells["Email"].Value?.ToString() ?? "";

            txtPhone.Text =
                row.Cells["Phone"].Value?.ToString() ?? "";
        }
    }
}

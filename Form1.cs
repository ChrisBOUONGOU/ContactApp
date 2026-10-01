using ContactApp.Data;
using ContactApp.Models;

namespace ContactApp
{
    public partial class Form1 : Form
    {
        private readonly ContactDbContext _db = new();
        private int? _selectedContactId;
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

            _selectedContactId =
                Convert.ToInt32(row.Cells["Id"].Value);

            txtFirstName.Text =
                row.Cells["FirstName"].Value?.ToString() ?? "";

            txtLastName.Text =
                row.Cells["LastName"].Value?.ToString() ?? "";

            txtEmail.Text =
                row.Cells["Email"].Value?.ToString() ?? "";

            txtPhone.Text =
                row.Cells["Phone"].Value?.ToString() ?? "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedContactId == null)
            {
                MessageBox.Show(
                    "Select a contact first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var contact = _db.Contacts.Find(
                _selectedContactId.Value);

            if (contact == null)
            {
                MessageBox.Show(
                    "Contact not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            contact.FirstName = txtFirstName.Text.Trim();
            contact.LastName = txtLastName.Text.Trim();
            contact.Email = txtEmail.Text.Trim();
            contact.Phone = txtPhone.Text.Trim();

            _db.SaveChanges();

            LoadContacts();

            MessageBox.Show(
                "Contact modified.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

using System;
using System.Windows.Forms;

namespace StudentRegistrationApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This runs as soon as the Form opens
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDateControls();
        }

        private void PopulateDateControls()
        {
            // Clear and add default prompts
            cmbDay.Items.Clear();
            cmbMonth.Items.Clear();
            cmbYear.Items.Clear();

            cmbDay.Items.Add("-Day-");
            cmbMonth.Items.Add("-Month-");
            cmbYear.Items.Add("-Year-");

            // Fill Days 1-31
            for (int i = 1; i <= 31; i++) cmbDay.Items.Add(i);

            // Fill Months 1-12
            for (int i = 1; i <= 12; i++) cmbMonth.Items.Add(i);

            // Fill Years (Current Year down to 1900)
            for (int i = DateTime.Now.Year; i >= 1900; i--) cmbYear.Items.Add(i);

            // Select the "-Prompts-" by default
            cmbDay.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
            cmbYear.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(FirstNametxt.Text) || cmbDay.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill in the required fields.", "Validation Error");
                return;
            }

            // Gather Data
            string name = $"{FirstNametxt.Text} {MiddleNametxt.Text} {LastNametxt.Text}";
            string gender = rbMale.Checked ? "Male" : "Female";
            string dob = $"{cmbDay.Text}/{cmbMonth.Text}/{cmbYear.Text}";

            // Display Results
            MessageBox.Show($"Student: {name}\nGender: {gender}\nDOB: {dob}", "Registration Successful");
        }

        private void MiddleNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

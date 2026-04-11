using System;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class StudentRegistration : Form
    {
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            // Load only once (prevents resetting issue)
            if (araw.Items.Count == 0)
            {
                LoadComboBoxes();
            }
        }

        private void LoadComboBoxes()
        {
            // Clear first (safe)
            araw.Items.Clear();
            buwan.Items.Clear();
            taon.Items.Clear();
            programa.Items.Clear();

            // Days
            for (int i = 1; i <= 31; i++)
                araw.Items.Add(i.ToString());

            // Months
            string[] months = {
                "January","February","March","April","May","June",
                "July","August","September","October","November","December"
            };
            buwan.Items.AddRange(months);

            // Years
            for (int i = 1950; i <= DateTime.Now.Year; i++)
                taon.Items.Add(i.ToString());

            // Programs
            string[] programs = {
                "Bachelor of Computer Engineering",
                "Bachelor of Computer Science",
                "Bachelor of Information System",
                "Bachelor of Information Technology"
            };
            programa.Items.AddRange(programs);

            // Placeholder text (no more reset bug)
            araw.Text = "-Day-";
            buwan.Text = "-Month-";
            taon.Text = "-Year-";
            programa.Text = "-Program-";
        }

        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(LastNametxt.Text) ||
                string.IsNullOrWhiteSpace(FirstNametxt.Text) ||
                string.IsNullOrWhiteSpace(MiddleNametxt.Text))
            {
                MessageBox.Show("Please fill in all name fields.");
                return false;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select gender.");
                return false;
            }

            if (araw.Text == "-Day-" ||
                buwan.Text == "-Month-" ||
                taon.Text == "-Year-" ||
                programa.Text == "-Program-")
            {
                MessageBox.Show("Please complete all selections.");
                return false;
            }

            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            string fullName = $"{FirstNametxt.Text} {MiddleNametxt.Text} {LastNametxt.Text}";
            string gender = rbMale.Checked ? "Male" : "Female";
            string dob = $"{araw.Text}/{buwan.Text}/{taon.Text}";
            string program = programa.Text;

            MessageBox.Show(
                $"Student Name: {fullName}\n" +
                $"Gender: {gender}\n" +
                $"Date of Birth: {dob}\n" +
                $"Program: {program}",
                "Student Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    
        private void browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("File selected: " + openFileDialog1.FileName);

                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        // METHOD OVERLOADING (optional feature)
        public void ShowStudentInfo(string f, string l)
        {
            MessageBox.Show($"Student: {f} {l}");
        }

        public void ShowStudentInfo(string f, string l, string p)
        {
            MessageBox.Show($"Student: {f} {l}\nProgram: {p}");
        }

        public void ShowStudentInfo(string f, string l, string p, string d)
        {
            MessageBox.Show($"Name: {f} {l}\nProgram: {p}\nBirthday: {d}");
        }

    }
}



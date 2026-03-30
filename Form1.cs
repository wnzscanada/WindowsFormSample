using System.Diagnostics;

namespace WindowsFormSample
{
    public partial class Form1 : Form
    {
        private List<Models.Student> students;
        private Models.ActivityContext context;
        public Form1()
        {
            InitializeComponent();
            context = new Models.ActivityContext();
            students = new List<Models.Student>();
            dataGridView1.DataSource = studentSource;
            InitializeTable();
        }

        private void InitializeTable()
        {
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                studentSource.Add(student);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Student newStudent = new Models.Student
                {
                    StudentId = Int32.Parse(txtId.Text),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    ContactNo = txtContactNumber.Text,
                    Program = txtProgram.Text,
                    YearLevel = Int32.Parse(txtYearLevel.Text)
                };

                context.Students.Add(newStudent);
                context.SaveChanges();

                var students = context.Students.ToList();

                studentSource.Clear();
                foreach (var student in students)
                {
                    studentSource.Add(student);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //studentSource.Add(newStudent);
        }

        private void studentSource_CurrentChanged(object sender, EventArgs e)
        {
           
        }
    }
}

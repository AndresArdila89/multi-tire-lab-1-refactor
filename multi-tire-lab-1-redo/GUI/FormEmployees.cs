using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using multi_tire_lab_1_redo.BLL;
using multi_tire_lab_1_redo.VALIDATION;

namespace multi_tire_lab_1_redo.GUI
{
    public partial class FormEmployees : Form
    {
        public FormEmployees()
        {
            InitializeComponent();
        }

        private void LoadTable()
        {
            List<Employee> empList = new List<Employee>();

            Employee emp = new Employee();

            empList = emp.LoadAllEmployees();
            listViewEmployees.Items.Clear();
            foreach (Employee empT in empList)
            {

                ListViewItem item = new ListViewItem(empT.EmployeeId.ToString());

                item.SubItems.Add(empT.FirstName);
                item.SubItems.Add(empT.LastName);
                item.SubItems.Add(empT.JobTitle);

                listViewEmployees.Items.Add(item);

            }
        }

        private void ClearAllTextBox()
        {
            textBoxEmpID.Clear();
            textBoxEmpFirstName.Clear();
            textBoxEmpLastName.Clear();

            comboBoxJobTitle.SelectedItem = null;
            comboBoxJobTitle.SelectedText = "--select--";
        }

        private void FormEmployees_Load(object sender, EventArgs e)
        {
            comboBoxJobTitle.SelectedItem = null;
            comboBoxJobTitle.SelectedText = "--select--";
            LoadTable();


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeId = Convert.ToInt32(textBoxEmpID.Text);
            emp.FirstName = textBoxEmpFirstName.Text;
            emp.LastName = textBoxEmpLastName.Text;
            emp.JobTitle = comboBoxJobTitle.SelectedItem.ToString();

            emp.UpdateEmployee(emp);
            LoadTable();
            ClearAllTextBox();
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewEmployees.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewEmployees.SelectedItems[0];
                textBoxEmpID.Text = item.SubItems[0].Text;
                textBoxEmpFirstName.Text = item.SubItems[1].Text;
                textBoxEmpLastName.Text = item.SubItems[2].Text;

                switch (item.SubItems[3].Text)
                {
                    case "Developer":
                        comboBoxJobTitle.SelectedIndex = 0;
                        break;
                    case "UX Designer":
                        comboBoxJobTitle.SelectedIndex = 1;
                        break;
                    case "Junior Dev":
                        comboBoxJobTitle.SelectedIndex = 2;
                        break;
                    case "Intern":
                        comboBoxJobTitle.SelectedIndex = 3;
                        break;

                }
                                
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.DeleteEmployee(Convert.ToInt32(textBoxEmpID.Text));
            LoadTable();
            ClearAllTextBox();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void buttonDisplayAll_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.FirstName = textBoxEmpFirstName.Text;
            emp.LastName = textBoxEmpLastName.Text;
            emp.JobTitle = comboBoxJobTitle.SelectedItem.ToString();

            emp.NewEmployee(emp);
            LoadTable();
            ClearAllTextBox();
        }
    }
}
 
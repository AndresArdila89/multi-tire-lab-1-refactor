using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using multi_tire_lab_1_redo.BLL;

namespace multi_tire_lab_1_redo
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp = emp.SearchEmployee(2006);
            MessageBox.Show(emp.LastName); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_dental_cinic
{
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void patientTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void patient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.PatientTbl' table. You can move, or remove it, as needed.
            this.patientTblTableAdapter.Fill(this.dataSet1.PatientTbl);
            dataGridView1.DataSource = this.patientTblTableAdapter.GetDataDGV();

        }
        private void clear()
        {
            Nametxt.Clear();
            Phone.Clear();
            Address.Clear();
            Allergies.Clear();
            dateTimePicker1.Value = DateTime.Now;
            rbMale.Checked = false;
            rbFemale.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)

        {
            string patgender;
            if(rbMale.Checked == true)
            {
                patgender = rbMale.Text;
            }
            else
            {
                patgender = rbFemale.Text;
            }
            var  thedate = dateTimePicker1.Value.Date;

            var x = this.patientTblTableAdapter.GetDataByPatPhone(Phone.Text);
            if(x.Count == 0)
            {
                this.patientTblTableAdapter.Insertpatient(Nametxt.Text, Phone.Text, Address.Text, Convert.ToString(thedate), patgender, Allergies.Text);
                MessageBox.Show("Patient Added successfully ");
                dataGridView1.DataSource = this.patientTblTableAdapter.GetDataDGV();
                clear();
               
            }
            else
            {
                MessageBox.Show("Patient already exists");
                clear();
            }
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  //to disable the row and column headers
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Nametxt.Text = row.Cells[1].Value.ToString();
                Phone.Text = row.Cells[2].Value.ToString();
                Address.Text = row.Cells[3].Value.ToString();
                Allergies.Text = row.Cells[6].Value.ToString();
                string gen = row.Cells[5].Value.ToString();
                if (gen == "Male")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
                if(Nametxt.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Please Select Patient");

            }
            else
            {
                try
                {
                    this.patientTblTableAdapter.DeleteQuerypat(key);
                    MessageBox.Show("Patient Deleted successfully");
                    dataGridView1.DataSource = this.patientTblTableAdapter.GetDataDGV();
                    clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select Patient");

            }
            else
            {
                try
                {
                    string patgender;
                    if (rbMale.Checked == true)
                    {
                        patgender = rbMale.Text;
                    }
                    else
                    {
                        patgender = rbFemale.Text;
                    }
                    var thedate = dateTimePicker1.Value.Date;
                    this.patientTblTableAdapter.UpdateQueryPat(Nametxt.Text, Phone.Text, Address.Text, Convert.ToString(thedate), patgender, Allergies.Text,key);
                    MessageBox.Show("Patient updated successfully");
                    dataGridView1.DataSource = this.patientTblTableAdapter.GetDataDGV();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
    }
}
/* 
  Nametxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Phone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Address.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Allergies.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string gen = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                if (gen == "Male")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
 
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_dental_cinic
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Appointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.dataSet1.Appointment);
            // TODO: This line of code loads data into the 'dataSet1.Table_appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.dataSet1.Appointment);
            AppointmentGDV.DataSource = this.appointmentTableAdapter.GetDataDGV();

        }
        private void clear()
        {
            patient.Text = "";
            treatment.Text = "";
            dateTimePickerdate.Value = DateTime.Now;
            dateTimePickertime.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = this.appointmentTableAdapter.GetDataBytreatment(treatment.Text);
            if (x.Count == 0)
            {
                this.appointmentTableAdapter.Insertapp(patient.SelectedValue.ToString(), treatment.SelectedValue.ToString(), dateTimePickerdate.Value.Date.ToString(), dateTimePickertime.Value.TimeOfDay.ToString());
                MessageBox.Show("Appointment Added successfully ");
                AppointmentGDV.DataSource = this.appointmentTableAdapter.GetDataDGV();
                clear();

            }
            else
            {
                MessageBox.Show("Appointment already exists");
                clear();
            }
        }


        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
               patient.SelectedValue =AppointmentGDV.SelectedRows[0].Cells[1].Value.ToString();

                treatment.Text =AppointmentGDV.SelectedRows[0].Cells[2].Value.ToString();
           
            string pat = AppointmentGDV.SelectedRows[0].Cells[2].Value.ToString();

            if (pat == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(AppointmentGDV.SelectedRows[0].Cells[0].Value.ToString());
                }


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          if (key == 0)
            {
                MessageBox.Show("Please Select Appointment");

            }
            else
            {
                try
                {

                    this.appointmentTableAdapter.Updateapp(patient.SelectedValue.ToString(),treatment.SelectedValue.ToString(), dateTimePickerdate.Value.Date.ToString(),dateTimePickertime.Value.TimeOfDay.ToString());
                    MessageBox.Show("Appointment updated successfully");
                    AppointmentGDV.DataSource = this.appointmentTableAdapter.GetDataDGV();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (key == 0 )
            {
                MessageBox.Show("Please Select Appointment");

            }
            else
            {
                try
                {
                    this.appointmentTableAdapter.Deleteapp(key);
                    MessageBox.Show("Appointment Deleted successfully");
                    AppointmentGDV.DataSource = this.appointmentTableAdapter.GetDataDGV();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            } 
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               this.appointmentTableAdapter.Fill(this.dataSet1.Appointment);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void appointmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }
    }
}

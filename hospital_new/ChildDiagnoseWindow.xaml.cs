using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hospital_new
{
    /// <summary>
    /// Logika interakcji dla klasy ChildDiagnoseWindow.xaml
    /// </summary>
    public partial class ChildDiagnoseWindow : Window
    {
        public ChildDiagnoseWindow()
        {
            InitializeComponent();
            CreateComboBox();
        }

        public void CreateComboBox()
        {
            using(HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                foreach (var patient in hospitalNewDB.Patients)
                {
                    cbPatientId.Items.Add(patient.Id);  
                }

                foreach (var doctor in hospitalNewDB.Doctors)
                {
                    cbDoctorName.Items.Add(doctor.DoctorName);
                }
            }
        }



        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            using (HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                int index = (hospitalNewDB.Diagnoses.ToList().Count() == 0) ? 0 : (hospitalNewDB.Diagnoses.ToList().Count() - 1);
                Diagnoses diagnoses = new Diagnoses()
                {
                    Id = index + 1,
                    Symptoms = tbSymptoms.Text,
                    Medicines = tbMedicines.Text,
                    Diagnossis = tbDiagnossis.Text,
                    Doctors = null,
                    Patients = null,
                    
                };
                hospitalNewDB.Diagnoses.Add(diagnoses);
                hospitalNewDB.SaveChanges();
            }
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}

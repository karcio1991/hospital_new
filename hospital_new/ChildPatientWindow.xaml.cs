using hospital_new.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hospital_new
{
    /// <summary>
    /// Logika interakcji dla klasy ChildPatientWindow.xaml
    /// </summary>
    public partial class ChildPatientWindow : Window
    {
        public ChildPatientWindow()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            using (HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                int index = (hospitalNewDB.Patients.ToList().Count() == 0) ? 0 : (hospitalNewDB.Patients.ToList().Count() - 1);
                Patients patients = new Patients()
                {
                    Id = index + 1,
                    PatientName = tbPatientName.Text,
                    PatientAdresses = tbPatientAdresses.Text,
                    PatientAge = int.Parse(tbPatientAge.Text),
                    PatientDisease = tbPatientDisease.Text,
                    PatientPhone = tbPatientPhone.Text,
                    Gender = (int)Enum.Parse(typeof(Gender), cbGender.Text),
                    BloodGroup = (int)Enum.Parse(typeof(BloodGroup), ConvertComboBox()),
                    Diagnoses = DefaultDiagnoses(),
                    Doctors = RandomDoctor(),
                };
                hospitalNewDB.Patients.Add(patients);
                hospitalNewDB.SaveChanges();
            }
            this.Close();
        }

        //ustaw Defaultowego lekarza

        public Doctors RandomDoctor()
        {
            using(HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                Doctors doctors = null;

                if (hospitalNewDB.Doctors.Count() == 0)
                {
                    //tworzysz defalut lekarz
                    doctors = new Doctors()
                    {
                        Diagnoses = null,
                        DoctorName = "Kowalski",
                        DoctorPassword = 1111,
                        DoctorExp = hospitalNewDB.Diagnoses.Count(),
                    };
                }
                else
                {
                    doctors = hospitalNewDB.Doctors.ToList().Where(x => x.DoctorName == "Kowalski").First();
                   
                }
                return doctors;
            }
        }

        public string ConvertComboBox()
        {
            switch (cbBloodGroup.Text)
            {
                case "A+": return "APlus";
                case "O+": return "OPlus";
                case "B+": return "BPlus";
                case "AB+": return "ABPlus";
                case "A-": return "AMinus";
                case "O-": return "OMinus";
                case "B-": return "BMinus";
                case "AB-": return "ABMinus";
            }
            return "";
        }


        public Diagnoses DefaultDiagnoses()
        {
            Diagnoses diagnoses = new Diagnoses()
            {
                Symptoms = "",
                Diagnossis = "",
                Medicines = "",
                Doctors = null,
                Patients = null,
            };

            return diagnoses;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

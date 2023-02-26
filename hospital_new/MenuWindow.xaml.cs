using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Logika interakcji dla klasy MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            DisplayDiagnoses();
            DisplayDoctors();
            DisplayPatients();

        }


        ObservableCollection<Diagnoses> ListOfDiagnoses = new ObservableCollection<Diagnoses>();
        ObservableCollection<Patients> ListOfPatients = new ObservableCollection<Patients>();
        ObservableCollection<Doctors> ListOfDoctors = new ObservableCollection<Doctors>();
        private void btnDiagnose_Click(object sender, RoutedEventArgs e)
        {
            SetWhichWindowIsActive("Diagnoses");
        }

        public void DisplayDiagnoses()
        {
            ListOfDiagnoses.Clear();
            using (HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                foreach (var eachDiag in hospitalNewDB.Diagnoses)
                {
                    ListOfDiagnoses.Add(new Diagnoses() { Symptoms = eachDiag.Symptoms, Medicines = eachDiag.Medicines, Diagnossis = eachDiag.Diagnossis, Doctors = eachDiag.Doctors, Patients = eachDiag.Patients });
                }
                dataGridDiagnose.ItemsSource = ListOfDiagnoses;
            }


        }

        private void btnAddDiagnose_Click(object sender, RoutedEventArgs e)
        {



        }

        public void SetWhichWindowIsActive(string whichWindow)
        {

            if (whichWindow == "Diagnoses")
            {
                borderDiagnose.Visibility = Visibility.Visible;
                borderDoctor.Visibility = Visibility.Hidden;
                borderPatient.Visibility = Visibility.Hidden;

            }
            else if (whichWindow == "Doctors")
            {
                borderDiagnose.Visibility = Visibility.Hidden;
                borderDoctor.Visibility = Visibility.Visible;
                borderPatient.Visibility = Visibility.Hidden;
            }
            else if (whichWindow == "Patients")
            {
                borderDiagnose.Visibility = Visibility.Hidden;
                borderDoctor.Visibility = Visibility.Hidden;
                borderPatient.Visibility = Visibility.Visible;
            }

        }


        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {

            SetWhichWindowIsActive("Patients");
            DisplayPatients();

        }

        private void btnDoctor_Click(object sender, RoutedEventArgs e)
        {
            SetWhichWindowIsActive("Doctors");
        }

        private void btnAddGeneral_Click(object sender, RoutedEventArgs e)
        {

            //ktory okno jest  aktwyne ? 

            switch (ReturnActiveWindow())
            {
                case "Diagnoses":
                    AddDiagnoses();
                    break;
                case "Doctors":
                    AddDoctors();
                    break;
                case "Patients":
                    AddPatients();
                    break;
            }



        }


        public void AddDoctors()
        {
            ChildDoctorWindow childDoctorWindow = new ChildDoctorWindow();
            childDoctorWindow.Show();
            DisplayDoctors();
        }


        public void DisplayDoctors()
        {
            ListOfDoctors.Clear();
            using (HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                foreach (var eachDoctor in hospitalNewDB.Doctors)
                {
                    ListOfDoctors.Add(new Doctors() { DoctorName = eachDoctor.DoctorName, DoctorPassword = eachDoctor.DoctorPassword, DoctorExp = eachDoctor.DoctorExp, Diagnoses = eachDoctor.Diagnoses, Patients = eachDoctor.Patients, DiagnosesId = eachDoctor.DiagnosesId });
                }
                dataGridDoctor.ItemsSource = ListOfDoctors;
            }
        }


        public void AddPatients()
        {
            ChildPatientWindow childPatientWindow = new ChildPatientWindow();
            childPatientWindow.Show();
            DisplayPatients();

        }

        public void DisplayPatients()
        {
            ListOfPatients.Clear();

            using (HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                foreach (var eachPatient in hospitalNewDB.Patients)
                {
                    ListOfPatients.Add(new Patients() { PatientName = eachPatient.PatientName, PatientAdresses = eachPatient.PatientAdresses, PatientAge = eachPatient.PatientAge, PatientPhone = eachPatient.PatientPhone, PatientDisease = eachPatient.PatientDisease, BloodGroup = eachPatient.BloodGroup, Gender = eachPatient.Gender, Diagnoses = eachPatient.Diagnoses, Doctors = eachPatient.Doctors });
                }
                dataGridPatient.ItemsSource = ListOfPatients;
            }
        }

        public void AddDiagnoses()
        {
            ChildDiagnoseWindow childDiagnoseWindow = new ChildDiagnoseWindow();
            childDiagnoseWindow.Show();


            DisplayDiagnoses();
        }

        public string ReturnActiveWindow()
        {
            string activeWindow = "";
            if (borderDiagnose.Visibility == Visibility.Visible)
            {
                activeWindow = "Diagnoses";
            }
            else if (borderDoctor.Visibility == Visibility.Visible)
            {
                activeWindow = "Doctors";
            }
            else if (borderPatient.Visibility == Visibility.Visible)
            {
                activeWindow = "Patients";
            }
            return activeWindow;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

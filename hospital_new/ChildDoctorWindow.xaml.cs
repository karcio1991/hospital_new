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
    /// Logika interakcji dla klasy ChildDoctorWindow.xaml
    /// </summary>
    public partial class ChildDoctorWindow : Window
    {
        public ChildDoctorWindow()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

            using (HospitalNewDBEntities2 hospitalNewDB = new HospitalNewDBEntities2())
            {
                int index = (hospitalNewDB.Doctors.ToList().Count() == 0) ? 0 : (hospitalNewDB.Doctors.ToList().Count() - 1);
                Doctors doctors = new Doctors()
                {
                    Id = index + 1,
                    DoctorName =  tbDoctorName.Text,
                    DoctorExp = int.Parse(tbDoctorExp.Text),
                    DoctorPassword = int.Parse(tbDoctorPassword.Text),
                    Diagnoses = null,
                    Patients = null,
                };
                hospitalNewDB.Doctors.Add(doctors);
                hospitalNewDB.SaveChanges();
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

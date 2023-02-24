using hospital_new.Model;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hospital_new
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           //Main();

        }

        //metody do ustawiania bazy danych
        public void Main()
        {
            

            var options = new DbContextOptionsBuilder<HospitalDataContext>()
                 .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;database=HospitalNewDB;Integrated Security=true;MultipleActiveResultSets=true")
                 .Options;

            using (var db = new HospitalDataContext(options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

            }
            

            /*var doctors = CreateFakeData();

            using (var db = new HospitalDataContext(options))
            {
                db.Doctors.AddRange(doctors);
                db.SaveChanges();
            }*/


        }

        public static IEnumerable<Doctor> CreateFakeData()
        {
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    DoctorName = "Jane Austen",Patients = new List<Patient>
                    {
                        new Patient{PatientName = "Emma",PatientAdresses ="Dluga"},
                        new Patient{PatientName = "Perusian",PatientAdresses ="Szczuczynska"},
                        new Patient{PatientName = "Mousfield",PatientAdresses ="Okrezna"}
                     }
                },
                new Doctor
                {
                    DoctorName = "Ian Fleming",Patients = new List<Patient>
                    {
                        new Patient{PatientName = "No",PatientAdresses ="Kwiatowa"},
                        new Patient{PatientName = "Goldfinger",PatientAdresses ="Zamkowa"},
                        new Patient{PatientName = "FromRussia",PatientAdresses ="Prosta"}
                     }
                }
            };

            return doctors;
        }

    }
}
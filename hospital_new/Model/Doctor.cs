using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_new.Model
{
    public class Doctor
    {
        public int? Id { get; set; }
        public string DoctorName { get; set; }

        public int DoctorExp { get; set; } //YearsOfExperience

        public int DoctorPassword { get; set; }

        public override string ToString()
        {
            return DoctorName;
        }

       //doktor ma wielu pacjentow
       public  ICollection<Patient> Patients { get; set; }

        //doktor moze miec wiele diagnoz
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public int DiagnosesId { get; internal set; }
    }
}

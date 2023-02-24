using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_new.Model
{

    public enum Gender { Male, Female };
    public enum BloodGroup { APlus, OPlus, BPlus, ABPlus, AMinus, OMinus, BMinus, ABMinus };


    public class Patient
    {

        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientAdresses { get; set; }

        public string PatientPhone { get; set; }

        public int PatientAge { get; set; }

        public Gender Gender { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public string PatientDisease { get; set; }






        public override string ToString()
        {
            return $"{PatientName} ({Id})";
        }

        //relacja pacjent - diagnoza
        public Diagnose Diagnose { get; set; }


        //relacja doktor - pacjent
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

    }
}

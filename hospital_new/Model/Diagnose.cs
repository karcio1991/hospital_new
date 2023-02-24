using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hospital_new.Model
{
    public class Diagnose
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }


        [Key]
        [Column(Order = 2)]
        public string Symptoms { get; set; }

        public string Diagnossis { get; set; }

        public string Medicines { get; set; }


        //relacja pacjent - diagnoza
        public Patient Patient { get; set; }
        
        public virtual Doctor Doctor { get; set; }
           


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace delopgave.Models
{
    public class Haandvaerker
    {
        public string HvAnsaettelsedatao { get; set; }
        public string HvEfternavn { get; set; }
        public string HvFagomraade { get; set; }
        public string HvFornavn { get; set; }
        [Key]
        public int HaandvaerkerId { get; set; }
        public ICollection<Vaerktoejskasse> Vaerker { get; protected set; }

        public Haandvaerker()
        {
            Vaerker = new List<Vaerktoejskasse>();
        }
    }
}

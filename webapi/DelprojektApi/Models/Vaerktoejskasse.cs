using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelprojektApi.Models
{
    public class Vaerktoejskasse
    {
        public string VtkAnskaffet { get; set; }
        public string VtkEjesAf { get; set; }
        public string VtkFabrikat { get; set; }
        public string VtkFarve{ get; set; }
        [Key]
        public int VtkId { get; set; }
        public string VtkModel { get; set; }
        public string VtkSerienummer { get; set; }
        public ICollection<Vaerktoej> Kasse { get; protected set; }

        public Vaerktoejskasse()
        {
            Kasse = new List<Vaerktoej>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelprojektApi.Models
{
    public class Vaerktoej
    {
        public string LiggerIvkt { get; set; }
        public string VtAnskaffet { get; set; }
        public string VtFabrikat { get; set; }
        [Key]
        public int VtId { get; set; }
        public string VtModel { get; set; }
        public string VtSerienr { get; set; }
        public string VtType { get; set; }
    }
}

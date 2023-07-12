using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE.Custom
{
    public class ProfessionalCustom
    {
        public string v_PersonId { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ProfessionName { get; set; }
        public DateTime? ContratoDesde { get; set; }
        public DateTime? ContratoHasta { get; set; }
    }
}

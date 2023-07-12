using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE.Custom
{
    public class VacationCustom
    {
        public string VacationId { get; set; }
        public string FullName { get; set; }
        public string DocNumber { get; set; }
        public string ProfessionName { get; set; }
        public DateTime? StartVacation { get; set; }
        public DateTime? EndVacation { get; set; }
    }
}

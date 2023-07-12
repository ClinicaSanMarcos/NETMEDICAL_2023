using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.UI
{
    public class PersonFinger
    {
        public byte[] b_FingerPrintTemplate { get; set; }
        public byte[] b_FingerPrintImage { get; set; }
        public string PersonName { get; set; }
        public string docNumber { get; set; }
    }
}

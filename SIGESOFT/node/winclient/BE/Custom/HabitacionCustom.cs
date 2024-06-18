using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE.Custom
{
    public class HabitacionCustom
    {
        public string Habitacion { get; set; }
        public string Estado { get; set; }
        public string v_HospHabitacionId { get; set; }
        public int i_HabitacionId { get; set; }

        public string Precio { get; set; }
        public string UsuarioCrea { get; set; }
        public int? UsuarioCreaId { get; set; }
        public DateTime? FechaCrea { get; set; }

        public string UsuarioActualiza { get; set; }
        public int? UsuarioActualizaId { get; set; }
        public DateTime? FechaActualiza { get; set; }

        public string Comentarios { get; set; }

    }
}

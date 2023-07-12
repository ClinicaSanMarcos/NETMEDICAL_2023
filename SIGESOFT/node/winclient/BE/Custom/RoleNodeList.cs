using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    public class RoleNodeList
    {
        public int i_SystemUserId { get; set; }
        public int i_NodeId { get; set; }
        public int i_RoleId { get; set; }  
        public string v_RoleName { get; set; }
        public string v_NodeName { get; set; }
      
    }

    public class NodeList
    {
        public int? i_NodeId { get; set; }
        public string v_Description { get; set; }
        public string v_GeographyLocationId { get; set; }
        public string v_GeographyLocationDescription { get; set; }
        public string v_NodeTypeName { get; set; }
        public DateTime? d_BeginDate { get; set; }
        public DateTime? d_EndDate { get; set; }

    }
}

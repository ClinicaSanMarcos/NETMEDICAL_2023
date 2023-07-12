using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    [DataContract]
    public class AutorizationList
    {
        [DataMember]
        public string V_Description { get; set; }
        [DataMember]
        public int? I_ParentId { get; set; }
        [DataMember]
        public int I_ApplicationHierarchyId { get; set; }
        [DataMember]
        public string V_Form { get; set; }
        [DataMember]
        public int? I_ApplicationHierarchyTypeId { get; set; }
        [DataMember]
        public string V_RoleName { get; set; }
        public int? i_RoleId { get; set; }
        public int? i_IsDeleted { get; set; }
        public int? i_IsNew { get; set; }
    }


    public class CategoryCustom
    {
        public int i_CategoryId { get; set; }
        public string v_CategoryName { get; set; }
        public List<ExamCustom> List { get; set; }
    }

    public class ExamCustom
    {
        public string v_ComponentId { get; set; }
        public string v_ComponentName { get; set; }
        public int? i_CategoryId { get; set; }
    }
}


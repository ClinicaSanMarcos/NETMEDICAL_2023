//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:53:38
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    [DataContract()]
    public partial class receta_campoporservicioResultDto
    {
        [DataMember()]
        public String ServicioId { get; set; }

        [DataMember()]
        public String Valor { get; set; }

        [DataMember()]
        public String NombreComponente { get; set; }

        [DataMember()]
        public String IdComponente { get; set; }

        [DataMember()]
        public String NombreCampo { get; set; }

        [DataMember()]
        public String IdCampo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_GroupId { get; set; }

        [DataMember()]
        public String ValorName { get; set; }

        public receta_campoporservicioResultDto()
        {
        }

        public receta_campoporservicioResultDto(String servicioId, String valor, String nombreComponente, String idComponente, String nombreCampo, String idCampo, Nullable<Int32> i_GroupId, String valorName)
        {
			this.ServicioId = servicioId;
			this.Valor = valor;
			this.NombreComponente = nombreComponente;
			this.IdComponente = idComponente;
			this.NombreCampo = nombreCampo;
			this.IdCampo = idCampo;
			this.i_GroupId = i_GroupId;
			this.ValorName = valorName;
        }
    }
}

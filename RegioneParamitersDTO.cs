
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TeamSystem.AlyCE.Services.Common.DTO;
using TeamSystem.AlyCE.Services.FW_Extendibility.DTO;

namespace TeamSystem.Alyante.Services.FI_GeneralData.DTO
{
    [DataContract(Namespace = "")]
    public class RegioneParametersDTO : BaseDTO
    {
        [DataMember]
        public List<int> keyRegione { get; set; }
        [DataMember]
        public bool flag { get; set; }
    }
}


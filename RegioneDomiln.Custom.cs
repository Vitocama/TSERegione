
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TeamSystem.AlyCE.Services.Common.DTO;

namespace TeamSystem.Alyante.Services.FI_GeneralData.DTO
{
   
    public partial class RegioneParametersDTO 

	{
        public List<int> keyRegione {  get; set; }
        public bool flag { get; set; }

	}


    public partial class RegioneDTOResult
    {
        public List<int> IdRegione { get; set; }
        
    }



}


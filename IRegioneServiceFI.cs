using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Common;
using TeamSystem.AlyCE.Common.Messages;


namespace TeamSystem.Alyante.FI_GeneralData.Service
{
    public interface IRegioneFIService : IServiceActivation
    {
        RegioneResult ActivaRegione(RegioneParameters parameters);

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Shared.Contracts.DomainModel;

namespace TeamSystem.Alyante.FI_GeneralData.Service
{
    public interface IRegioneFIService : IServiceActivation
    {
      
        public List<int> ActivaRegione(List<int>id,bool flag);

    }
}


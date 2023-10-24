using System;
using System.Collections.Generic;
using System.Linq;
using TeamSystem.Alyante.FI_GeneralData;
using TeamSystem.Alyante.FI_GeneralData.Service;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Common.Authentication;
using TeamSystem.AlyCE.Services.Common.Results;

namespace TeamSystem.Alyante.Services.FI_GeneralData.Managers
{
    public partial class RegioneFIManager
    { 

        public List<int> GetRegione(RegioneParametersDTO @params)
        {
            List<int> lista;

            if (@params == null)
                throw new ArgumentNullException("errore");

            try
            {

                ISession session = SessionData.Session;
                IBizFactory factory = new BizFactory(session);
                IRegioneFIService articoliFIService = factory.CreateService<IRegioneFIService>();
                lista = articoliFIService.ActivaRegione(@params.keyRegione, @params.flag);
            }
            catch (Exception ex)
            {
                Logger.Error("RegioneFIManager.ActivateIntercompanyAccounts => error thrown: '{0}'", ex.Message);
                Logger.Error(ex);
                throw;
            }

            return lista;



        }

    }
}


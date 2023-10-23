using System;
using System.Collections.Generic;
using System.Linq;
using TeamSystem.Alyante.FI_GeneralData;
using TeamSystem.Alyante.FI_GeneralData.Service;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Common.Authentication;
using TeamSystem.AlyCE.Common.Messages;
using TeamSystem.AlyCE.Services.Common.DTO;
using TeamSystem.AlyCE.Services.Common.Results;

namespace TeamSystem.Alyante.Services.FI_GeneralData.Managers
{
    public partial class RegioneFIManager
    { 

        public ApplicationResult GetRegione(RegioneParametersDTO @params)
        {
           

            if (@params == null)
                throw new ArgumentNullException("errore");

            

            try
            {

                ISession session = SessionData.Session;
                IBizFactory factory = new BizFactory(session);
                IRegioneFIService articoliFIService = factory.CreateService<IRegioneFIService>();
                RegioneParameters parametersMapped = Mapper.Map<RegioneParameters>(@params);
                RegioneResult res = articoliFIService.ActivaRegione(parametersMapped);
                MessageList messages = session.MessageBag.TakeMessages();
                
               

                if (messages.Any())
                { 
                    ValidateDTO validateDTO = ValidateDTO.Create(messages);

                    return new ApplicationResult(validateDTO);
                }
                return new ApplicationResult(new RegioneResultDTO() {Regione=res.Regione});

            }

            catch (Exception ex)
            {
                Logger.Error("RegioneFIManager.ActivateIntercompanyAccounts => error thrown: '{0}'", ex.Message);
                Logger.Error(ex);
                throw;
            }


            



        }

    }
}


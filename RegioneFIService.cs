using Microsoft.AspNetCore.Razor.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TeamSystem.Alyante.CO_GeneralData;
using TeamSystem.Alyante.FI_GeneralData;
using TeamSystem.Alyante.FI_GeneralData.Service;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Common;
using TeamSystem.AlyCE.Common.Authentication;
using TeamSystem.AlyCE.Common.Messages;

namespace TeamSystem.Alyante.Biz.FI_GeneralData
{
    public class RegioneFIService : IRegioneFIService
    {
        private ISession _session;
        private IBizFactory _factory;

        public RegioneResult ActivaRegione(RegioneParameters parameters)
        {
            List<int> listResult = new List<int>();

            IRegioneFIBiz regioneFIBiz = _factory.CreateBiz<IRegioneFIBiz>();
            SimpleSearchRequestInfo serchNode = new SimpleSearchRequestInfo(RegioneFI.Informations.EntitySetName);
            serchNode.AddSearch(RegioneFI.Informations.Regione, SearchComparer.In, parameters.keyRegione);

            List<RegioneFI> region = regioneFIBiz.Search(serchNode).Cast<RegioneFI>().ToList();

            List<int> regione = region.Select(x => (int)x.Regione).ToList();

            if (!region.Any())
            {
                _session.MessageBag.AddMessage(new Error(FI_GeneralData_MessageCodes.ErrorInsertCodeReplayRegion));
                return null;
            }

            if (parameters.flag == true)
            {
                IGeneralMasterDataCOBiz generalMasterDataCOBiz = _factory.CreateBiz<IGeneralMasterDataCOBiz>();

                SimpleSearchRequestInfo searchGENERALMASTER = new SimpleSearchRequestInfo(GeneralMasterDataCO.Informations.EntitySetName);

                SimpleSearchRequestInfo equalReg = new SimpleSearchRequestInfo(RegioneFI.Informations.EntitySetName);

                searchGENERALMASTER.AddSearch(GeneralMasterDataCO.Informations.RagSoAnag, SearchComparer.In, regioneFIBiz.Search(serchNode).Cast<RegioneFI>().Where(x => x.Ragsoc == (x.Ragsoc)).Select(x => x.Ragsoc).ToList());
                   
                   

                var dataTableAnagr = generalMasterDataCOBiz.Search(searchGENERALMASTER).Cast<GeneralMasterDataCO>().ToList();

                if (!dataTableAnagr.Any())
                {
                    _session.MessageBag.AddMessage(new Error(FI_GeneralData_MessageCodes.DoesNotExistCorresponds));
                    return null;
                }

                List<string> ragSocial = dataTableAnagr.Select(x => x.RagSoAnag).ToList();
                
                List<int>res =regioneFIBiz.Search(equalReg).Cast<RegioneFI>()
                    .Where(x=>ragSocial.Contains(x.Ragsoc))
                    .ToList()
                    .Select(x=>x.Regione)
                    .ToList();

                listResult.AddRange(res);
                RegioneResult listKeyRegion = new RegioneResult() { Regione = listResult };

                return listKeyRegion;
            }
            else
            {
                SimpleSearchRequestInfo searchHabitantes = new SimpleSearchRequestInfo(RegioneFI.Informations.EntitySetName);
                searchHabitantes.AddSearch(RegioneFI.Informations.Regione, SearchComparer.In, parameters.keyRegione);

                List<int> ListHabitant = regioneFIBiz.Search(searchHabitantes).Cast<RegioneFI>().Where(x => x.Abintanti > 1000).Select(x => x.Regione).ToList();

                if (!ListHabitant.Any())
                {
                    _session.MessageBag.AddMessage(new Error(FI_GeneralData_MessageCodes.ErrorInsertCodeReplayRegion));
                    return null;
                }
               
                listResult.AddRange(ListHabitant);
            }

            RegioneResult listKeyRegionresult = new RegioneResult() { Regione = listResult };

            return listKeyRegionresult;

        }

        public void SetSession(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _factory = new BizFactory(_session);

        }
    }
}


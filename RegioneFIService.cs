using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TeamSystem.Alyante.CO_GeneralData;
using TeamSystem.Alyante.FI_GeneralData;
using TeamSystem.Alyante.FI_GeneralData.Service;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Common;
using TeamSystem.AlyCE.Common.Authentication;


namespace TeamSystem.Alyante.Biz.FI_GeneralData
{
    public class RegioneFIService : IRegioneFIService
    {
        private ISession _session;
        private IBizFactory _factory;


        public List<int> ActivaRegione(List<int> id, bool flag)
        {
            IRegioneFIBiz regioneFIBiz = _factory.CreateBiz<IRegioneFIBiz>();


            SimpleSearchRequestInfo searchREGION = new SimpleSearchRequestInfo(RegioneFI.Informations.EntitySetName);
            SimpleSearchRequestInfo searchANAGGEN = new SimpleSearchRequestInfo(GeneralMasterDataCO.Informations.EntitySetName);


            searchREGION.AddSearch(RegioneFI.Informations.Regione, SearchComparer.NotEqual, null);
            searchANAGGEN.AddSearch(GeneralMasterDataCO.Informations.RagSoAnag, SearchComparer.NotEqual, null);


            var regionAbitant = regioneFIBiz.Search(searchREGION).Cast<RegioneFI>().ToList();
            var anaggen = regioneFIBiz.Search(searchANAGGEN).Cast<GeneralMasterDataCO>().ToList();
        

            List<int> regionKeyList = regionAbitant.Select(p =>(int)p.Regione).ToList();
            List<string> regionAnag = regionAbitant.Select(p => (string)p.Ragsoc).ToList();
            List<string> anaggerString=anaggen.Select(p=>(string)p.RagSoAnag).ToList();
            

            foreach (int item in id)
            {
                if (!regionKeyList.Contains(item))
                    return null;
            }


            bool coor = true;
           

            if (flag == true)
            {
                regionAnag[0] = "a";
                anaggerString[0] = "d";


            foreach (string item in regionAnag)
                {
                    if (anaggerString.Contains(item))
                    { coor = false;

                        break;
                    }
                }
                if (coor)
                {
                    return null;
                } 
            }

            if (flag == false) {

                var ab1000 = regionAbitant.Where(p => p.Abintanti > 1000);
                var regionkey=ab1000.Select(p=>p.Regione).ToList();


                return regionkey = regionkey.Select(p => (int)p).ToList();   
            }


            return regionKeyList;
        }

        public void SetSession(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _factory = new BizFactory(_session);


        }


    }
}


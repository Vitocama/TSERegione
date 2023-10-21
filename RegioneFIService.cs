using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using TeamSystem.Alyante.CO_GeneralData;
using TeamSystem.Alyante.FI_GeneralData;
using TeamSystem.Alyante.FI_GeneralData.Service;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.AlyCE.Biz;
using TeamSystem.AlyCE.Common;
using TeamSystem.AlyCE.Common.Authentication;
using TeamSystem.AlyCE.Common.Session;

namespace TeamSystem.Alyante.Biz.FI_GeneralData
{
    public class RegioneFIService : IRegioneFIService
    {
        private ISession _session;
        private IBizFactory _factory;

        public List<int> ActivaRegione(List<int> id, bool flag)
        {
           if((flag.Equals(false) && id.Any())){
                
            return null;
            }
           
            IRegioneFIBiz regioneFIBiz = _factory.CreateBiz<IRegioneFIBiz>();

            SimpleSearchRequestInfo searchNodes = new SimpleSearchRequestInfo(RegioneFI.Informations.EntitySetName);
            
            foreach(int index in id) 

            searchNodes.AddSearch(RegioneFI.Informations.Regione,SearchComparer.NotEqual,index);


           var e = regioneFIBiz.Search(searchNodes).Cast<RegioneFI>().ToList();
           
            List<int> ids = new List<int>();
            ids.AddRange(e.Select(x => (int)x.Regione));





            return ids;
        }

        public void SetSession(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _factory = new BizFactory(_session);
        }

      
    }
}

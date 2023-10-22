using TeamSystem.AlyCE.Common.Messages;
using TeamSystem.AlyCE.Services.Controllers;
using TeamSystem.AlyCE.Services.Common.Attributes;
using TeamSystem.AlyCE.Shared;
using TeamSystem.Alyante.Services.FI_GeneralData.DTO;
using TeamSystem.Alyante.Services.FI_GeneralData.Managers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using TeamSystem.AlyCE.Services.Common.Results;
using System.Globalization;
using System.Collections.Generic;

namespace TeamSystem.Alyante.Services.FI_GeneralData.Controllers
{

    public partial class RegioneFIController
    {
        public const string cittaOp = "citta";
        [HttpPost(cittaOp)]
        [SwaggerOperation(Summary = "citta", Description = "cittaoq")]
        [SwaggerResponse(StatusCodes.Status200OK, "tutto ok", typeof(List<int>))]
        public IActionResult GetRegione([FromBody, SwaggerRequestBody("attivato paraemntro", Required = true)] RegioneParametersDTO @params)
        {
            if (@params == null)
            {
                return BadRequest("regna il nulla");
            }

         List<int> result = Manager.GetRegione(@params);
      

            return StatusCode(StatusCodes.Status200OK, result);


        }



    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpendituresController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;

        public ExpendituresController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        [HttpGet]
        [Route("allExpenditures")]
        public async Task<IActionResult> GetAllExpenditures()
        {
            var expenditures = await _expenditureService.GetAllExpenditures();

            if (!expenditures.Any())
            {
                return NotFound("We did not find any expenditure");
            }

            return Ok(expenditures);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetExpenditure")]
        public async Task<IActionResult> GetExpenditureById(int id)
        {
            var expenditure = await _expenditureService.GetExpenditureById(id);
            if (expenditure == null)
            {
                return NotFound("We did not find any income");
            }
            return Ok(expenditure);
        }

        [HttpPost]
        [Route("createexpenditure")]
        public async Task<IActionResult> CreateExpenditure(ExpenditureRequestModel model)
        {
            var expenditure = await _expenditureService.CreateExpenditure(model);
            return Ok(expenditure);
        }

        [HttpPut]
        [Route("updateexpenditure")]
        public async Task<IActionResult> UpdateExpenditure(ExpenditureUpdateRequestModel model)
        {
            var updatedExpenditure = await _expenditureService.UpdateExpenditure(model);
            return Ok(updatedExpenditure);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteExpenditure")]
        public async Task<IActionResult> DeleteExpenditure(int id)
        {
            var expenditure= await _expenditureService.DeleteExpenditure(id);
            return Ok(expenditure);
        }
    }
}

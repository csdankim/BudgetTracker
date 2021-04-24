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
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        /*[HttpGet]
        [Route("allIncomes")]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();

            if (!incomes.Any())
            {
                return NotFound("We did not find any income");
            }

            return Ok(incomes);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetIncome")]
        public async Task<IActionResult> GetIncomeById(int id)
        {
            var user = await _incomeService.GetIncomeById(id);
            if (user == null)
            {
                return NotFound("We did not find any income");
            }
            return Ok(user);
        }*/

        [HttpPost]
        [Route("createincome")]
        public async Task<IActionResult> CreateIncome(IncomeRequestModel model)
        {
            var income = await _incomeService.CreateIncome(model);
            return Ok(income);
        }

        [HttpPut]
        [Route("updateincome")]
        public async Task<IActionResult> UpdateIncome(IncomeUpdateRequestModel model)
        {
            var updatedIncome = await _incomeService.UpdateIncome(model);
            return Ok(updatedIncome);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteIncome")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var income = await _incomeService.DeleteIncome(id);
            return Ok(income);
        }
    }
}

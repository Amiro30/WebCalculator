using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCalculator.Models;
using WebCalculator.Interfaces;

namespace WebCalculator.Controllers
{
    [Route("api/v1/calc")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly CalcContext _context;
        private readonly ICalculator _calculator;

        public CalculatorController(CalcContext context, ICalculator calculator)
        {
            _context = context;
            _calculator = calculator;
        }

        /// <summary>
        /// Get all records of calculations in current session
        /// </summary>
        /// <returns></returns>
        [HttpGet("history")]
        public Task<List<HistoryItem>> GetHistory()
        {
            return _context.History.ToListAsync();
        }


        /// <summary>
        /// Find record by it's ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("history/{id}")]
        public async Task<ActionResult<HistoryItem>> GetHistoryItem(int id)
        {
            var operation = await _context.History.FindAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return operation;
        }


        /// <summary>
        /// Execute Method
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "FirstNumber": "2",
        ///        "SecondNumber": "3",
        ///        "OperationType": "+"
        ///     }
        ///
        /// </remarks>  
        /// <returns>result of operation</returns>
        [HttpPost("execute")]
        public async Task<decimal> Execute(decimal a, decimal b, OperationType type)
        {
            var result = _calculator.Execute(a, b, type);

            var item = new HistoryItem
            {
                Left = a,
                Right = b,
                Type = type
            };

            _context.History.Add(item);

            await _context.SaveChangesAsync();

            return result;
        }


        [HttpDelete("history/{id}")]
        public async Task<ActionResult<HistoryItem>> DeleteOperation(int id)
        {
            var operation = await _context.History.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            _context.History.Remove(operation);
            await _context.SaveChangesAsync();

            return operation;
        }
    }
}

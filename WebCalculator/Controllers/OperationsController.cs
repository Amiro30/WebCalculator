using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCalculator.Models;
using WebCalculator.Interfaces;

namespace WebCalculator.Controllers
{
    [Route("api/Operations")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly CalcContext _context;
        private readonly ITransactionBuilder _builder;

        public OperationsController(CalcContext context, ITransactionBuilder builder)
        {
            _context = context;
            _builder = builder;
        }

        /// <summary>
        /// Get all records of calculations in current session
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operation>>> GetOperations()
       {
            return await _context.Operations.ToListAsync();
        }

        /// <summary>
        /// Find record by it's ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Operation>> GetOperation(int id)
        {
            var operation = await _context.Operations.FindAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return operation;
        }


        /// <summary>
        /// Calculate (operation type: +,-,*,/)
        /// </summary>
        /// <param name="operation"></param>
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
        [HttpPost("Calculate")]
        public async Task<ActionResult<Operation>> CalculateOperation(Operation operation)
        {
            _builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }



        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operation>> DeleteOperation(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();

            return operation;
        }

        private bool OperationExists(int id)
        {
            return _context.Operations.Any(e => e.Id == id);
        }
    }
}

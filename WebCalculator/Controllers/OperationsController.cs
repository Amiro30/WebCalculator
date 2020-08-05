using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCalculator.Models;
using WebCalculator.Service;

namespace WebCalculator.Controllers
{
    [Route("api/Operations")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly CalcContext _context;
        private TransactionBuilder builder = new TransactionBuilder();

        public OperationsController(CalcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all records of calculations in current session
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetOperations()
       {
            return await _context.Operations.ToListAsync();
        }

        // GET: api/Operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetOperation(int id)
        {
            var operation = await _context.Operations.FindAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return operation;
        }
        

        /// <summary>
        /// Addition 
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
        /// <returns>Sum</returns>
        [HttpPost("Add")]
        public async Task<ActionResult<Transaction>> AddOperation(Transaction operation)
        {
            builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }
        /// <summary>
        /// Subtraction
        /// </summary>
        /// <param name="operation"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "FirstNumber": "10",
        ///        "SecondNumber": "5",
        ///        "OperationType": "-"
        ///     }
        ///
        /// </remarks>  
        /// <returns>Result of substraction</returns>
        [HttpPost("Sub")]
        public async Task<ActionResult<Transaction>> SubOperation(Transaction operation)
        {
            builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }
        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="operation"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "FirstNumber": "2",
        ///        "SecondNumber": "2",
        ///        "OperationType": "*"
        ///     }
        ///
        /// </remarks>  
        /// <returns>Mult result</returns>
        [HttpPost("Mult")]
        public async Task<ActionResult<Transaction>> MultOperation(Transaction operation)
        {
            builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }
        /// <summary>
        /// Division
        /// </summary>
        /// <param name="operation"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "FirstNumber": "10",
        ///        "SecondNumber": "2",
        ///        "OperationType": "/"
        ///     }
        ///
        /// </remarks>  
        /// <returns>Div result</returns>
        [HttpPost("Div")]
        public async Task<ActionResult<Transaction>> DivOperation(Transaction operation)
        {
            builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }



        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteOperation(int id)
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

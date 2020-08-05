using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetOperations()
        {
            return await _context.Operations.ToListAsync();
        }

        // GET: api/Operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetOperation(long id)
        {
            var operation = await _context.Operations.FindAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return operation;
        }

        // PUT: api/Operations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperation(long id, Transaction operation)
        {
            if (id != operation.Id)
            {
                return BadRequest();
            }

            _context.Entry(operation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost("Add")]
        public async Task<ActionResult<Transaction>> AddOperation(Transaction operation)
        {
            builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }

        [HttpPost("Sub")]
        public async Task<ActionResult<Transaction>> SubOperation(Transaction operation)
        {
            builder.TransactionCreate(operation);

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperation), new { id = operation.Id }, operation);
        }



        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteOperation(long id)
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

        private bool OperationExists(long id)
        {
            return _context.Operations.Any(e => e.Id == id);
        }
    }
}

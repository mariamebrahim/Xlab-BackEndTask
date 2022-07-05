using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Xlab_Task.Data;
using Xlab_Task.Models;

namespace Xlab_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly SalesDbContext _context;

        public InvoicesController(SalesDbContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
          if (_context.Invoices == null)
          {
              return NotFound();
          }
            return await _context.Invoices.ToListAsync();
        }

        //Get invoice details
        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<sp_GetInvoiceByIDResult>>> GetInvoice(int id)
        {
            var empRecord = _context.GetInvoiceByID.FromSqlInterpolated($"EXECUTE [dbo].[sp_GetInvoiceByID] {id}").ToList();
            return empRecord;
        }


        //Update Invoice
        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> UpdateInvoice( Invoice invoice)
        {
            _context.Invoices.FromSqlInterpolated($"EXECUTE [dbo].[sp_UpdateInvoice] {invoice.Invoice_ID},{invoice.Client_Name},{invoice.Invoice_Date}").ToList();
            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoices.FromSqlInterpolated($"EXECUTE [dbo].[sp_CreateAnewInvoice] {invoice.Client_Name},{invoice.Invoice_Date}").ToList();
            return NoContent();
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            _context.Invoices.FromSqlInterpolated($"EXECUTE [dbo].[sp_deleteInvoice] {id}").ToList();
            return NoContent();

        }

        private bool InvoiceExists(int id)
        {
            return (_context.Invoices?.Any(e => e.Invoice_ID == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xlab_Task.Data;
using Xlab_Task.Models;

namespace Xlab_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoice_DetailController : ControllerBase
    {
        private readonly SalesDbContext _context;

        public Invoice_DetailController(SalesDbContext context)
        {
            _context = context;
        }

        // GET: api/Invoice_Detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice_Detail>>> GetInvoice_Details()
        {
          if (_context.Invoice_Details == null)
          {
              return NotFound();
          }
            return await _context.Invoice_Details.ToListAsync();
        }

        // GET: api/Invoice_Detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<sp_GetInvoiceTotalsResult>>> GetInvoice_Detail(int id)
        {
            var invTotalRecord = _context.GetInvoiceTotals.FromSqlInterpolated($"EXECUTE [dbo].[sp_GetInvoiceTotals] {id}").ToList();
            return invTotalRecord;
        }


        //Update invoice Items
        // PUT: api/Invoice_Detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutInvoice_Detail( Invoice_Detail invoice_Detail)
        {
            _context.Invoice_Details.FromSqlInterpolated($"EXECUTE [dbo].[sp_UpdateInvoiceItems] {invoice_Detail.Invoice_ID},{invoice_Detail.Product_ID},{invoice_Detail.Product_Price},{invoice_Detail.Product_Quantity}").ToList();
            return NoContent();
        }

        // POST: api/Invoice_Detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice_Detail>> PostInvoice_Detail(Invoice_Detail invoice_Detail)
        {
            _context.Invoice_Details.FromSqlInterpolated($"EXECUTE [dbo].[sp_InsertItemsIntoInvoice] {invoice_Detail.Invoice_ID},{invoice_Detail.Product_ID},{invoice_Detail.Product_Price},{invoice_Detail.Product_Quantity}").ToList();
            return NoContent();
        }

        // DELETE: api/Invoice_Detail/5
        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice_Detail(Invoice_Detail invoice_Detail)
        {
            _context.Invoice_Details.FromSqlInterpolated($"EXECUTE [dbo].[sp_DeleteItemInvoice] {invoice_Detail.Invoice_ID},{invoice_Detail.Product_ID}").ToList();
            return NoContent();

        }

        private bool Invoice_DetailExists(int id)
        {
            return (_context.Invoice_Details?.Any(e => e.Invoice_ID == id)).GetValueOrDefault();
        }
    }
}

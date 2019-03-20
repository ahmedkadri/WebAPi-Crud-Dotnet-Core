using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context ;
        }

        // GET api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetails(int id)
        {
            var paymentDeatil = await _context.PaymentDetails.FindAsync(id);

            if(paymentDeatil == null)
            {
                return NotFound();
            }

            return paymentDeatil;
        }

        // POST api/PaymentDetail
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetails" , new { id = paymentDetail.PMId } , paymentDetail);
        }

        //PUT: api/PaymentDetail/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDetail>> PutPaymentDetail(int id,PaymentDetail paymentDetail)
        {
            if( id != paymentDetail.PMId )
            {
                return BadRequest();
            }
            _context.Entry(paymentDetail).State = EntityState.Modified;

            
           await _context.SaveChangesAsync();
          
            return NoContent();
        }


         //DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if(paymentDetail == null )
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetail);
           
            await _context.SaveChangesAsync();

            return paymentDetail;
        }
    }
}
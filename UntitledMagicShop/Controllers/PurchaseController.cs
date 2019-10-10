using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UntitledMagicShop.Core.Application_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        // GET api/values?
        [HttpGet]
        public ActionResult<IEnumerable<Purchase>> Get()
        {

                return _purchaseService.ReadAllPurchases();
            
        }
        // POST api/values
        [HttpPost]
        public ActionResult<Purchase> Post([FromBody] Purchase sale)
        {
            if (sale.Items.Count == 0)
                return BadRequest("Purchase has to containt atleast one item");
            try
            {
                var newPurchase = _purchaseService.createPurchase(sale);
                if (newPurchase != null)
                    return Ok(newPurchase);
                else
                    return BadRequest("Purchase creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
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
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        private bool IsValid(Item item, out String msg)
        {
            msg = "";
            if (item == null)
                msg = "Request has to containt item field";
            if (item.Name.Length == 0)
                msg = "Item first name can not be empty";
            return msg.Length == 0;
        }

        public ItemsController(IItemService service)
        {
            _itemService = service;
        }
        /* GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return Ok(_itemService.ReadAll());
        }*/



        // GET api/values?
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get([FromQuery] Filter filter)
        {

            if (_itemService.listAllItems() == null)
            {
                BadRequest("Item list is empty");
                return NotFound();
            }

            else
            {
                if(filter.CurrentPage < 0 || filter.ItemPrPage < 0)  return BadRequest("Current page and items per apge has to be at least 0");
                
            }
                return _itemService.GetFilteredItems(filter).ToList();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item item)
        {
            String message = "";
            if (!IsValid(item, out message))
            {
                return BadRequest(message);
            }
            try
            {
                var newItem = _itemService.createItem(item);
                if (newItem != null)
                    return Ok(newItem);
                else
                    return BadRequest("Item creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Item> Put(int id, [FromBody] Item item)
        {
            String message = "";

            if (id != item.ID)
                return BadRequest("Item id does not match");

            try
            {
                var updatedItem = _itemService.updateItem(item);
                if (updatedItem != null)
                    return Ok(updatedItem);
                else
                    return BadRequest("Item update failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Item> Delete(int id)
        {
            try
            {
               Item deletedItem = _itemService.deleteItem(id);
                return Ok(deletedItem);
            }
            catch (Exception ex)
            {
                return BadRequest("Error deleting item");
            }
        }
    }
}
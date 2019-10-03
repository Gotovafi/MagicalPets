using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetApp.Core.ApplicationService;
using PetApp.Core.Entity;

namespace Petweeb.UI.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_ownerService.GetFileteredOwners(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("id skal være søtrre end 0");
            return _ownerService.FindOwnerById(id);
        }


        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("har bruge for et name");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("");
            }
            return _ownerService.CreateAOwner(owner);

        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner Owner)
        {
            if (id < 1 || id != Owner.Id)
            {
                return BadRequest("de 2 id må være det samme");
            }
            return Ok(_ownerService.UpdadteOwner(Owner));
        }

        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var pet = _ownerService.DeletOwner(id);
            if (pet == null)
            {
                return StatusCode(404, "fandt ikke id på pet " + id);
            }

            return Ok($"pet with Id: {id} er slette");
        }
    }
}
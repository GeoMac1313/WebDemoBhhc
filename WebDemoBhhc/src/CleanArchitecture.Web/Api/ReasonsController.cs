using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Web.ApiModels;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonsController : Controller
    {
        private readonly IRepository _repository;

        public ReasonsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Reasons
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.ListAll<Reason>().Select(ReasonDTO.FromReason);

            return Ok(items);
        }

        // GET: api/Reasons/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            //Reason testThis = _repository.GetById<Reason>(id);


            var item = ReasonDTO.FromReason(_repository.GetById<Reason>(id));
            return Ok(item);
        }

        // POST: api/Reasons
        [HttpPost]
        public IActionResult Post([FromBody] ReasonDTO item)
        {
            var newReason = new Reason()
            {
                Description = item.Description,
                LastChangedBy = "Some User",
                LastChangedDateTime = DateTime.Now
            };
            _repository.Add(newReason);
            return Ok(ReasonDTO.FromReason(newReason));
        }

        // PUT: api/Reasons/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {

            var reason = _repository.GetById<Reason>(id);
            reason.Description = value;
            reason.LastChangedBy = "Some User";
            reason.LastChangedDateTime = DateTime.Now;

            _repository.Update(reason);

            return Ok(ReasonDTO.FromReason(reason));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var reasonToDelete = _repository.GetById<Reason>(id);

            _repository.Delete(reasonToDelete);
        }
    }
}

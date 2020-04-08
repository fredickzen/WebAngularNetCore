using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;

namespace Northwind.WebApi.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id) {
            return Ok(_unitOfWork.Costumer.GetById(id));
        }
        [HttpGet]
        [Route("GetPaginateCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginateCustomer(int page, int rows)
        {
            return Ok(_unitOfWork.Costumer.CustomerPagedList(page,rows));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Costumer.Insert(customer));
        }
        [HttpPut]
        public IActionResult Put([FromBody]Customer customer) {
            if (ModelState.IsValid && _unitOfWork.Costumer.Update(customer))
            {
                return Ok( new { Mesage ="The customer is Updated"});
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody]Customer customer)
        {
            if (customer.Id > 0) 
                return Ok(_unitOfWork.Costumer.Delete(customer));
            return BadRequest();

        }
    }
}
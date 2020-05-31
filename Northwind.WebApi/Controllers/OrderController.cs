using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.UnitOfWork;

namespace Northwind.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Order.GetOrderById(id));
        }
        [HttpGet]
        [Route("GetPaginateOrder/{page:int}/{rows:int}")]
        public IActionResult GetPaginateSupplier(int page, int rows)
        {
            // Para probar errores
            //throw new Exception("Error interno");
            return Ok(_unitOfWork.Order.getPaginatedOrder(page, rows));
        }
    }
}
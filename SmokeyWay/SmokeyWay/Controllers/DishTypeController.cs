using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace SmokeyWay.Controllers
{
    [Route("api/dishTypes")]
    [ApiController]
    public class DishTypeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public DishTypeController()
        {

        }
    }
}

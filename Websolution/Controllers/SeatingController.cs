using System.Web.Http;
using Services.Interface;
using Websolution.Controllers.Base;
using Ambient.Context.Interfaces;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/seating")]
    public class SeatingController : BaseApiController
    {
        private readonly ISeatingService _seatingService;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public SeatingController(
            ISeatingService seatingService,
            IDbContextScopeFactory contextScopeFactory
        ) {
            _seatingService = seatingService;
            _contextScopeFactory = contextScopeFactory;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var seating = _seatingService.GetAll();
                return Ok(seating);
            }
        }

        [HttpGet]
        [Route("removefromtable")]
        public IHttpActionResult RemovePersonFromTable(int personId)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var result = _seatingService.RemovePersonFromTable(personId);

                if (result)
                {
                    return Ok();
                }

                return NotFound();
            }
        }

        [HttpGet]
        [Route("addtotable")]
        public IHttpActionResult AddPersonToTable(int personId, int tableId)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var result = _seatingService.AddPersonToTable(personId, tableId);

                if (result)
                {
                    return Ok();
                }

                return NotFound();
            }
        }
    }
}

using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;
using Ambient.Context.Interfaces;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/personGroup")]
    public class PersonGroupController : BaseApiController
    {
        private readonly IPersonGroupService _personGroupService;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public PersonGroupController(
            IPersonGroupService personGroupService,
            IDbContextScopeFactory contextScopeFactory
        ) {
            _personGroupService = personGroupService;
            _contextScopeFactory = contextScopeFactory;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var personGroups = _personGroupService.GetAll();
                return Ok(personGroups);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var personGroup = _personGroupService.GetById(id);
                return Ok(personGroup);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(PersonGroupModel model)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var personGroup = _personGroupService.Add(model);
                return Ok(personGroup);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(PersonGroupModel model)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var personGroup = _personGroupService.Update(model);
                return Ok(personGroup);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                _personGroupService.Delete(id);
                return Ok();
            }
        }
    }
}

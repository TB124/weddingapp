using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;
using Ambient.Context.Interfaces;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/person")]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public PersonController(
            IPersonService personService,
            IDbContextScopeFactory contextScopeFactory
        ) {
            _personService = personService;
            _contextScopeFactory = contextScopeFactory;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var persons = _personService.GetAll();
                return Ok(persons);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var person = _personService.GetById(id);
                return Ok(person);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(PersonModel model)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var person = _personService.Add(model);
                return Ok(person);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(PersonModel model)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var person = _personService.Update(model);
                return Ok(person);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                _personService.Delete(id);
                return Ok();
            }
        }
    }
}

using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/person")]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            var persons = _personService.GetAll();
            return Ok(persons);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            var person = _personService.GetById(id);
            return Ok(person);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(PersonModel model)
        {
            var person = _personService.Add(model);
            return Ok(person);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(PersonModel model)
        {
            var person = _personService.Update(model);
            return Ok(person);
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _personService.Delete(id);
            return Ok();
        }
    }
}

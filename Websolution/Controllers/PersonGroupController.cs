using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/personGroup")]
    public class PersonGroupController : BaseApiController
    {
        private readonly IPersonGroupService _personGroupService;

        public PersonGroupController(IPersonGroupService personGroupService)
        {
            _personGroupService = personGroupService;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            var personGroups = _personGroupService.GetAll();
            return Ok(personGroups);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            var personGroup = _personGroupService.GetById(id);
            return Ok(personGroup);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(PersonGroupModel model)
        {
            var personGroup = _personGroupService.Add(model);
            return Ok(personGroup);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(PersonGroupModel model)
        {
            var personGroup = _personGroupService.Update(model);
            return Ok(personGroup);
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _personGroupService.Delete(id);
            return Ok();
        }
    }
}

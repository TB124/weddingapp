using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/table")]
    public class TableController : BaseApiController
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            var tables = _tableService.GetAll();
            return Ok(tables);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            var table = _tableService.GetById(id);
            return Ok(table);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(TableModel model)
        {
            var table = _tableService.Add(model);
            return Ok(table);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(TableModel model)
        {
            var table = _tableService.Update(model);
            return Ok(table);
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _tableService.Delete(id);
            return Ok();
        }
    }
}

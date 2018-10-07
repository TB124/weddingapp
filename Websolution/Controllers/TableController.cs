using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;
using Ambient.Context.Interfaces;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/table")]
    public class TableController : BaseApiController
    {
        private readonly ITableService _tableService;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public TableController(
            ITableService tableService,
            IDbContextScopeFactory contextScopeFactory
        ) {
            _tableService = tableService;
            _contextScopeFactory = contextScopeFactory;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var tables = _tableService.GetAll();
                return Ok(tables);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var table = _tableService.GetById(id);
                return Ok(table);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(TableModel model)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var table = _tableService.Add(model);
                return Ok(table);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(TableModel model)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var table = _tableService.Update(model);
                return Ok(table);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                _tableService.Delete(id);
                return Ok();
            }
        }
    }
}

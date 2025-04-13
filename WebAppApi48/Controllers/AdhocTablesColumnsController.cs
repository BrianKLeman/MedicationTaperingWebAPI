using DataAccessLayer;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    
    
    [RoutePrefix("Api/AdhocTables/{adhoctableid}/Columns")]
    public class AdhocTableColumnsController : ApiController
    {        
        public AdhocTableColumnsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IAdhocColumnDataAccess)) as IAdhocColumnDataAccess;
        }

        private IAuthService authService;
        private IAdhocColumnDataAccess dataAccess;
        
        [Route("")]
        public IHttpActionResult Get([FromUri]string adhoctableid)
        {
            return base.Ok(dataAccess.GetColumns(int.Parse(adhoctableid)));
        }

        [Route("{columnName}")]
        public IHttpActionResult Post([FromUri]string adhoctableid, [FromUri]string columnName)
        {
            return base.Ok(new { AdhocTableRowId = dataAccess.CreateColumn(int.Parse(adhoctableid), columnName) });
        }

        [Route("{columnId}")]
        public IHttpActionResult Delete([FromUri]string adhoctableid, [FromUri]string columnId)
        {
            return base.Ok(dataAccess.DeleteColumn(int.Parse(adhoctableid), int.Parse(columnId)));
        }
    }    
}

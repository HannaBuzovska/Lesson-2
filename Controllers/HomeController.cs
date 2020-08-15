using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OWINWebApi.Controllers
{
    public class HomeController: ApiController
    {
        public IEnumerable<int> GetValues()
        {
            return Enumerable.Range(0,10);
        }
    }
}
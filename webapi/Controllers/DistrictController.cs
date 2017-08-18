using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/district")]
    public class DistrictController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            var data = db.districts.Select(s => new { s.DISTRICT_CODE, s.DISTRICT_NAME }).Take(1000).ToList();
            return Json(data);
        }
        [Route("api/district/{input}")]
        [AllowAnonymous]
        public dynamic GetDistrict(string input)
        {
            var data = db.village2010.Where(w => w.TAM_T.Contains(input)).Select(s => new { s.TAM_CODE, s.TAM_T, s.AMP_T, s.PROV_T }).Take(5).ToList();
            return Json(data);
        }

    }
}
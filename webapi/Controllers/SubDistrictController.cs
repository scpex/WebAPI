using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/subdistrict")]
    public class SubDistrictController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            var data = db.districts.Select(s => new { s.DISTRICT_CODE, s.DISTRICT_NAME }).Take(1000).ToList();
            return Json(data);
        }
        [Route("api/subdistrict/{input}")]
        [AllowAnonymous]
        public dynamic GetSubDistrict(string input)
        {
            var data = db.TAMBONs.Where(w => w.TAMBON_T.Contains(input)).Select(s => new { s.AD_LEVEL, s.TA_ID, s.TAMBON_T, s.TAMBON_E, s.AM_ID, s.AMPHOE_T, s.AMPHOE_E, s.CH_ID, s.CHANGWAT_T, s.CHANGWAT_E, s.LAT, s.LONG }).ToList();
            return Json(data);
        }

    }
}
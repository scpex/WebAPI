using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/hospital")]
    public class HospitalController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            string[] data = { "MainHospitalCode", "OldCode", "ShortName", "FullName", "HospitalType2Name", "Description", "Address", "DistrictName", "ProvinceName", "RegionName", "Telephone","Fax" };
            return Json(data);
        }
        [Route("api/hospital/code/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic HospitalCode(string input)
        {
            var data = db.HOSPITALs.Where(w => w.MainHospitalCode.Equals(input)).Select(s => new { s.MainHospitalCode, s.OldCode, s.ShortName, s.FullName, s.HospitalType2Name, s.Description, s.Address, s.DistrictName, s.ProvinceName, s.RegionName, s.Telephone, s.Fax }).ToList();
            return Json(data);
        }
        [Route("api/hospital/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic Hospital(string input)
        {
            var data = db.HOSPITALs.Where(w => w.ShortName.Contains(input)).Select(s => new { s.MainHospitalCode, s.OldCode, s.ShortName, s.FullName, s.HospitalType2Name, s.Description, s.Address, s.DistrictName, s.ProvinceName, s.RegionName, s.Telephone, s.Fax }).ToList();
            return Json(data);
        }
    }
}
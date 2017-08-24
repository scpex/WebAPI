using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/people")]
    public class PeopleController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic GetAllPeople()
        {
            string[] data = { "ID_Number", "PreName", "Firstame", "LastName", "District_Registry", "Province_Registry" };
            return Json(data);
        }
        [Route("api/people/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic id(string id)
        {
            if (id.Length != 13)
            {
                return Json("ID Incorrect!!!");
            }
            int i = 11 - (((Convert.ToInt32(id.Substring(0, 1)) * 13)
                + (Convert.ToInt32(id.Substring(1, 1)) * 12)
                + (Convert.ToInt32(id.Substring(2, 1)) * 11)
                + (Convert.ToInt32(id.Substring(3, 1)) * 10)
                + (Convert.ToInt32(id.Substring(4, 1)) * 9)
                + (Convert.ToInt32(id.Substring(5, 1)) * 8)
                + (Convert.ToInt32(id.Substring(6, 1)) * 7)
                + (Convert.ToInt32(id.Substring(7, 1)) * 6)
                + (Convert.ToInt32(id.Substring(8, 1)) * 5)
                + (Convert.ToInt32(id.Substring(9, 1)) * 4)
                + (Convert.ToInt32(id.Substring(10, 1)) * 3)
                + (Convert.ToInt32(id.Substring(11, 1)) * 2)) % 11);
            int j = Convert.ToInt32(id.Substring(12, 1));
            if (j != i)
            {
                return Json("Number Incorrect!!!");
            }
            else
            {
                string codeA = id.Substring(1, 4);
                string codeP = id.Substring(1, 2);

                //var reg_data = db.amphurs.Where(w => w.AMPHUR_CODE == codeA).Select(s => new { s.AMPHUR_NAME}).Take(10).ToList();
                //var data = db.person_th.Where(w=>w.id1==id).Select(s=>new { s.id1,s.pname,s.fname,s.lname}).Take(10).ToList();

                var q = from ps in db.person_th
                        join a in db.amphurs on codeA equals a.AMPHUR_CODE
                        join p in db.provinces on codeP equals p.PROVINCE_CODE
                        select new
                        {
                            ID_Number = ps.id1,
                            PreName = ps.pname,
                            Firstame = ps.fname,
                            LastName = ps.lname,
                            District_Registry = a.AMPHUR_NAME,
                            Province_Registry = p.PROVINCE_NAME
                        };
                var info = q.Where(w => w.ID_Number == id).ToList();
                return Json(info);
            }
        }
    }
}
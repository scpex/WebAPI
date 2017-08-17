using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;   
namespace webapi.Controllers
{
    [Route("api/thaiid")]
    public class ThaiIDController : ApiController
    {
        private thailandEntities db = new thailandEntities();

        [HttpGet]
        [AllowAnonymous]
        public dynamic ID(string id)
        {
            
            if (id.Length != 13)
            {
                return "ID Incorrect!!!";
            }
            int i = 11-(((Convert.ToInt32(id.Substring(0, 1)) * 13)
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
                + (Convert.ToInt32(id.Substring(11, 1)) * 2))%11);
            int j = Convert.ToInt32(id.Substring(12, 1));
            if (j != i)
            {
                return "Number Incorrect!!!";
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
                            psid = ps.id1,
                            pspname = ps.pname,
                            psfname = ps.fname,
                            pslname = ps.lname,
                            aname = a.AMPHUR_NAME,
                            pname = p.PROVINCE_NAME
                        };
                var info = q.Where(w => w.psid == id).ToList();
                return Json(info);
            }
        }
    }
}

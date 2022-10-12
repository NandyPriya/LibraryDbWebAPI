using library_BAL;
using library_helper;
using librarydbinwebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace librarydbinwebapi.Controllers
{
    public class MemberController : ApiController
    {
        // GET api/<controller>
        Helper helper = null;
        public MemberController()
        {
            helper = new Helper();
        }
        [Route("GetAllMems")]
        public List<MemberModel> GetMemberList()
        {
            //return new string[] { "value1", "value2" };

            List<BAL> empbal = new List<BAL>(); empbal = helper.ShowMemberList();
            List<MemberModel> emps = new List<MemberModel>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new MemberModel { Memberid = item.Memberid, Membername = item.Membername, Accopendate = item.Accopendate, Maxbooksallowed = item.Maxbooksallowed, Penaltyamt = item.Penaltyamt });
            }
            return emps;
            // GET api/<controller>/5
        }

[Route("Findmembyid/{id}")]
        public MemberModel GetMemberByID(int id)
        {
            BAL empbal = new BAL();
            empbal = helper.SearchMember(id);
            MemberModel emp = new MemberModel();
            emp.Memberid = empbal.Memberid;
            emp.Membername = empbal.Membername;
            emp.Accopendate= empbal.Accopendate;
            emp.Maxbooksallowed= empbal.Maxbooksallowed;
            emp.Penaltyamt = empbal.Penaltyamt;
            
            return emp;

        }
        [Route("Addmem")]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] MemberModel empdata)
        {
            BAL empbal = new BAL();
            empbal.Memberid = empdata.Memberid;
            empbal.Membername = empdata.Membername;
            empbal.Accopendate = empdata.Accopendate;
            empbal.Maxbooksallowed = empdata.Maxbooksallowed;
            empbal.Penaltyamt = empdata.Penaltyamt;



            bool ans = helper.addmember(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // PUT api/<controller>/5
        [Route("Updatemembyid/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] MemberModel empdata)
        {
            BAL empbal = new BAL();
            empbal.Memberid = empdata.Memberid;
            empbal.Membername = empdata.Membername;
            empbal.Accopendate = empdata.Accopendate;
            empbal.Maxbooksallowed = empdata.Maxbooksallowed;
            empbal.Penaltyamt = empdata.Penaltyamt;
           
            bool ans = helper.editmember(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("Deletemembyid/{id}")]
        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            bool ans = helper.RemoveMember(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}
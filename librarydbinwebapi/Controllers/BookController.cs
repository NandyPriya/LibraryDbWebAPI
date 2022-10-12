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
    public class BookController : ApiController
    {
        Helper helper = null;
        public BookController()
        {
            helper = new Helper();
        }
        [Route("GetAllEmps")]
        public List<BookModel> GetBookList()
        {
            //return new string[] { "value1", "value2" };

            List<BAL> empbal = new List<BAL>(); empbal = helper.ShowBookList();
            List<BookModel> emps = new List<BookModel>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new BookModel { Book_no = item.Book_no, Book_name = item.Book_name, Author = item.Author, Cost = item.Cost, Category = item.Category,Availability=item.Availability});
            }
            return emps;

        }
        [Route("FindEmp/{id}")]
        
        public BookModel GetBookByID(int id)
        {
            BAL empbal = new BAL();
            empbal = helper.SearchBook(id);
            BookModel emp = new BookModel();
            emp.Book_no = empbal.Book_no;
            emp.Book_name = empbal.Book_name;
            emp.Author = empbal.Author;
            emp.Cost = empbal.Cost;
            emp.Category = empbal.Category;
            emp.Availability = empbal.Availability;
            return emp;
            
        }
        [Route("AddEmp")]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] BookModel empdata)
        {
            BAL empbal = new BAL();
            empbal.Book_no = empdata.Book_no;
            empbal.Book_name = empdata.Book_name;
            empbal.Author = empdata.Author;
            empbal.Cost = empdata.Cost;
            empbal.Category = empdata.Category;
            empbal.Availability = empdata.Availability;

            bool ans = helper.addbook(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("UpdateEmp/{id}")]
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] BookModel empdata)
        {
            BAL empbal = new BAL();
            empbal.Book_no = empdata.Book_no;
            empbal.Book_name = empdata.Book_name;
            empbal.Author = empdata.Author;
            empbal.Cost = empdata.Cost;
            empbal.Category = empdata.Category;
            empbal.Availability = empdata.Availability;
            bool ans = helper.editbook( empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
       [Route("DeleteEmp/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool ans = helper.RemoveBook(id);
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
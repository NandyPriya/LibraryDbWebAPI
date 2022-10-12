using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace librarydbinwebapi.Models
{
    public class BookModel
    {
        private int _bookno;

        public int Book_no
        {
            get { return _bookno; }
            set { _bookno = value; }
        }
        private string _bookname;

        public string Book_name
        {
            get { return _bookname; }
            set { _bookname = value; }
        }
        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        private double _cost;

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        private string _category;

        public string Category
        {
            get { return _category; }
            set
            {
                if ((value.Length > 10) || (string.IsNullOrEmpty(value)))
                {
                    throw new Exception("Category too long.. it should not exceed 10 chars");
                }
                else
                {
                    _category = value;
                }
                _category = value;
            }
        }
        private int _availability;

        public int Availability
        {
            get { return _availability; }
            set { _availability = value; }
        }

    }
}
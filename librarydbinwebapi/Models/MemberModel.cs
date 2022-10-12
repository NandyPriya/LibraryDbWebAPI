using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace librarydbinwebapi.Models
{
    public class MemberModel
    {
        private int _memberid;

        public int Memberid
        {
            get { return _memberid; }
            set { _memberid = value; }
        }
        private string _membername;

        public string Membername
        {
            get { return _membername; }
            set { _membername = value; }
        }
        private DateTime _accopendate;

        public DateTime Accopendate
        {
            get { return _accopendate; }
            set { _accopendate = value; }
        }
        private int _maxbooksallowed;

        public int Maxbooksallowed
        {
            get { return _maxbooksallowed; }
            set { _maxbooksallowed = value; }
        }
        private int _penaltyamt;

        public int Penaltyamt
        {
            get { return _penaltyamt; }
            set { _penaltyamt = value; }
        }

    }
}
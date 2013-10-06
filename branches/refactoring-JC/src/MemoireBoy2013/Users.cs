using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoireBoy2013
{
    public class Users : PersonneClass
    {
        public Users() { }

        private Int32 UserID;
        public Int32 UserId
        {
            get { return UserID; }
            set { UserID = value; }
        }


        private Int32 persUserID;
        public Int32 persUserId
        {
            get { return persUserID; }
            set { persUserID = value; }
        }

        private Int32 droitsUSER;
        public Int32 droitsuser
        {
            get { return droitsUSER; }
            set { droitsUSER = value; }
        }


        private Int32 prefsUSER;
        public Int32 prefsuser
        {
            get { return prefsUSER; }
            set { prefsUSER = value; }
        }

        private string Login;
        public string login
        {
            get { return Login; }
            set { Login = value; }
        }


        private string PassWord;
        public string password
        {
            get { return PassWord; }
            set { PassWord = value; }
        }



    }
}

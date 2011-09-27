using System;

namespace CCSkype
{
    public class UserNotKnowException : Exception
    {
        public UserNotKnowException(string username) : base(username)
        {            
        }
    }
}
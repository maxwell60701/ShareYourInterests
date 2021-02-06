using System;

namespace ShareYourInterests.Entity
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string EmailAddress{ get; set; }

        public string PhoneNumber{ get; set; }
    }
}

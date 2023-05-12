using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Permissions;

// Copyright (c) 2023 Yesalt Lasterson
// Read LICENCE.txt

namespace Permissions
{
    internal class User
    {
        protected internal Password? EncyptedPass { get; private set; }
        public string? Name { get; private set; }
        public SecurityRights Rights { get; private set; }
        public User(Password password, ID iD) 
        {
            
        }
    }
}

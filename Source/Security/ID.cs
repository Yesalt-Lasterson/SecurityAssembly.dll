using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Permissions;
using Windows.Security.Authentication.OnlineId;

// Copyright (c) 2023 Yesalt Lasterson
// Read LICENCE.txt

namespace Permissions
{
    internal class ID
    {
        internal int[] Id { get; private set; }
        public ID(SecurityRights rights, string name)
        {
            Id = SecurityRights.WantID(rights, name);
        }
        public int[] RequestID()
        {
            return Id;
        }
    }
}

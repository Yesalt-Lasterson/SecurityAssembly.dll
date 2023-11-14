using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            EncyptedPass = password;
            Rights = iD;
            Name = ConvertIDToUserName(iD);
        }
        public static string ConvertIDToUserName(ID id)
        {
            StringBuilder sb = new();
            string stringID;
            int[] iD = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (id != null && iD.Length >= 10)
            {
                iD = id.RequestID();
                for(int i = 9; i < iD.Length; i++)
                {
                    sb.Append(iD[i]);
                }
                stringID = sb.ToString();
                byte[] byteASCHIIID = Encoding.UTF8.GetBytes(stringID);
                stringID = Encoding.ASCII.GetString(byteASCHIIID);
                return stringID;
            }
            else
            {                    
                string nameThing = "John Doe";
                try
                {
                    ID raiseEvent = new(true);
                }
                catch(IDException e)
                {
                    Console.WriteLine($"Security.dll Permissions namespace ERROR: IDEXCEPTION:{e}\nIf u are a developer this was caused by ID being null somehow best to use code step!");
                }
                return nameThing;
            }
        }
    }
}

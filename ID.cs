using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Permissions;

// Copyright (c) 2023 Yesalt Lasterson
// Read LICENCE.txt

namespace Permissions
{
    /// <summary>
    /// The ID class for easy passing of variables between programs!
    /// </summary>
    public class ID
    {
        /// <summary>
        /// The Event that is raized when ID is null!
        /// </summary>
        public event EventHandler? IDNULLFLAGED;
        internal int[] Id { get; private set; }
        /// <summary>
        /// What makes an ID
        /// </summary>
        /// <param name="rights">the SecurityRights Variable required to mkae an ID</param>
        /// <param name="name">the extra info required to make an identifier for ID</param>
        public ID(SecurityRights rights, string name) => Id = SecurityRights.WantID(rights, name);
        /// <summary>
        /// If the ID failed Use To raise Event and Throw Exception
        /// </summary>
        /// <param name="failed">if false will make ID all zeros</param>
        /// <exception cref="IDException">The aforementioned Exception!</exception>
        public ID(bool failed)
        {
            if(failed)
            {
                if (IDNULLFLAGED != null)
                {
                    IDNULLFLAGEDEventArgs e = new(this, IDNULLFLAGED);
                    IDNULLFLAGED.Invoke(this, e);
                }
                Id = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, -127 };
                throw new IDException();
            }
            else
            {
                Id = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                return;
            }
        }    

        /// <summary>
        /// It gives u ID
        /// </summary>
        /// <returns>Returns ID int[]</returns>
        public int[] RequestID()
        {
            return Id;
        }
    }
    /// <summary>
    /// What happens when Event is raised!
    /// </summary>
    public class IDNULLFLAGEDEventArgs : EventArgs
    {
        EventHandler Handler { get; set; }
        object Sender { get; set; }
        /// <summary>
        /// The actual Things that Happen
        /// </summary>
        /// <param name="sender">Who sended it</param>
        /// <param name="handler">The event</param>
        public IDNULLFLAGEDEventArgs(object sender, EventHandler handler)
        {
            EventArgs eventArgs = new();
            Handler = handler;
            Sender = sender;
#pragma warning disable CA1303
            Console.WriteLine("ID HAS BEEN NULL");
#pragma warning restore CA1303
            handler?.Invoke(this, eventArgs);
        }
    }
    /// <summary>
    /// This Exception Is thrown when ID is null ID cannot be null
    /// </summary>
    public class IDException : Exception
    {
        /// <summary>
        /// The default constructor of IDException
        /// </summary>
        public IDException() => Console.WriteLine($"ID Check Turned NULL!\nID Can't be NULL\n{new ArgumentNullException()}");
        /// <summary>
        /// Constructor of IDException that takes a custom message
        /// </summary>
        /// <param name="message">The Message</param>
        public IDException(string message) => Console.WriteLine(message);
        /// <summary>
        /// Constructor that takes custom message and innerexception
        /// </summary>
        /// <param name="message">The Message</param>
        /// <param name="innerException">Another Exception!</param>
        public IDException(string message, Exception innerException) => Console.WriteLine(message, innerException);

    }
}

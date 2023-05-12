using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Windows.UI.Composition;
using System.Runtime.CompilerServices;
using Permissions;
using WinRT;

// Copyright (c) 2023 Yesalt Lasterson
// Read LICENCE.txt

namespace Permissions
{
    /// <summary>
    ///  Contains values that the enum PermissionLvl is supposed to have.
    /// </summary>
    public interface IPermssionsLevel
    {
        /// <summary>
        /// This is the Property Suspended corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl Suspended { get; set; }
        /// <summary>
        /// This is the Property Untrusted corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl Untrusted { get; set; }
        /// <summary>
        /// This is the Property Member corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl Member { get; set; }
        /// <summary>
        /// This is the Property MVP corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl MVP { get; set; }
        /// <summary>
        /// This is the Property Master corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl Master { get; set; }
        /// <summary>
        /// This is the Property Mod corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl Moderator { get; set; }
        /// <summary>
        /// This is the Property Admin corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl Admin { get; set; }
        /// <summary>
        /// This is the Property OWNER corresponding to the values in the enum PermissionLvl
        /// </summary>
        public PermissionLvl OWNER { get; set; }
    }
    /// <summary>
    /// Provides Variables needed to be compatible with the SecurityRights Struct
    /// </summary>
    public interface IPermissionsCompatible
    {
        /// <summary>
        /// This is the variable needed to declare a SecurityRights instance
        /// </summary>
        SecurityRights Rights { get; set; }
        /// <summary>
        /// Variable needed for the HasRequiredPermissions Method
        /// </summary>
        PermissionLvl MinimumPermssionLvl { get; set; }
    }
    /// <summary>
    /// ME WARN U
    /// </summary>
    public class MVPException : Exception
    {
        /// <summary>
        /// eh
        /// </summary>
        public MVPException()
        {
        }
        /// <summary>
        /// IT STILL SAME
        /// </summary>
        /// <param name="message">Y U NO LISTEN</param>
        public MVPException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// also Eh
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">the other exception</param>
        public MVPException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message + " " + innerException);
        }
    }
    /// <summary>
    /// The SecurityRights Struct that contains all of the code needed to check for permissions with one Parameter from you
    /// </summary>
    public struct SecurityRights : IEquatable<SecurityRights>
    {
        private PermissionLvl PermLvl { get; set; }
        private bool Open { get; set; } = true;
        private bool Read { get; set; } = false;
        private bool Write { get; set; } = false;
        private bool Manage { get; set; } = false;
        private bool VIPPrivalleges { get; set; } = false;
        private bool ModPrivalleges { get; set; } = false;
        private bool IsAdmin { get; set; } = false;
        private bool FullControl { get; set; } = false;
        /// <summary>
        /// The Constructor of SecurityRights To let all of it's properties have values for Variable to be usefull
        /// </summary>
        /// <param name="PermissionsLevel">Is the value that you provided</param>
        public SecurityRights(PermissionLvl PermissionsLevel)
        {
            PermLvl = PermissionsLevel;
            switch (PermLvl)
            {
                case PermissionLvl.Suspended:
                    {
                        Open = false;
                        break;
                    }
                case PermissionLvl.Untrusted:
                    {
                        break;
                    }
                case PermissionLvl.Member:
                    {
                        Open = true;
                        Read = true;
                        break;
                    }
                case PermissionLvl.Master:
                    {
                        Open = true;
                        Read = true;
                        VIPPrivalleges = true;
                        break;
                    }
                case PermissionLvl.Moderator:
                    {
                        Open = true;
                        Read = true;
                        ModPrivalleges = true;
                        break;
                    }
                case PermissionLvl.Admin:
                    {
                        Open = true;
                        Read = true;
                        VIPPrivalleges = true;
                        IsAdmin = true;
                        break;
                    }
                case PermissionLvl.OWNER:
                    {
                        FullControl = true;
                        break;
                    }
            }
        }
        /// <summary>
        /// This is to be able to turn an ID to a SecurityRights instance
        /// </summary>
        /// <param name="rawData">The RAW Data</param>
        public SecurityRights(bool[] rawData)
        {
            if(rawData == null)
            {
                bool[] ifNullValue = { Open, Read, Write, Manage, VIPPrivalleges, ModPrivalleges, IsAdmin, FullControl };
                rawData = ifNullValue;
            }
            for (int i = 0; i < rawData.Length; i++)
            {

            }
        }
        /// <summary>
        /// If u wat to be in the safe side also allows enum called PermissionLvl
        /// </summary>
        /// <param name="PermissionsLevel">Is the value that you provided</param>
        public static SecurityRights ToSecurityRights(PermissionLvl PermissionsLevel) => new(PermissionsLevel);
        /// <summary>
        /// Makes Code Simpler by allowing to declare variable by string
        /// </summary>
        /// <param name="PermissionsLevel">Is the value that you provided</param>
        public static SecurityRights ToSecurityRights(string PermissionsLevel) => new((PermissionLvl)Enum.Parse(typeof(PermissionLvl), PermissionsLevel, true));
        /// <summary>
        /// This Is like ToSecurityRights() but fancier and make variables even better!
        /// </summary>
        /// <param name="PermissionLevel">This is a local variable that reflects the value given by You!</param>
        public static implicit operator SecurityRights(PermissionLvl PermissionLevel) => new(PermissionLevel);
        /// <summary>
        /// This is like the other SecurityRights but for strings so u can input STRINGS!
        /// </summary>
        /// <param name="PermissionLevel">its also a local var that reflects your input!</param>
        public static implicit operator SecurityRights(string PermissionLevel) => new((PermissionLvl)Enum.Parse(typeof(PermissionLvl), PermissionLevel, true));
        /// <summary>
        /// This Does all the equals that
        /// </summary>
        /// <param name="obj">it is the object in question</param>
        /// <returns>returns false or true if everything it checks checks out</returns>
        public override bool Equals(object? obj)
        {
            if (obj is SecurityRights rights)
            {
                return PermLvl == rights.PermLvl &&
                       Open == rights.Open &&
                       Read == rights.Read &&
                       Write == rights.Write &&
                       Manage == rights.Manage &&
                       VIPPrivalleges == rights.VIPPrivalleges &&
                       ModPrivalleges == rights.ModPrivalleges &&
                       IsAdmin == rights.IsAdmin &&
                       FullControl == rights.FullControl;
            }
            return false;
        }
        /// <summary>
        /// Equals cousin
        /// </summary>
        /// <param name="other">other stuff</param>
        /// <returns>returns if everything checks out again</returns>
        public bool Equals(SecurityRights other)
        {
            return PermLvl == other.PermLvl &&
                   Open == other.Open &&
                   Read == other.Read &&
                   Write == other.Write &&
                   Manage == other.Manage &&
                   VIPPrivalleges == other.VIPPrivalleges &&
                   ModPrivalleges == other.ModPrivalleges &&
                   IsAdmin == other.IsAdmin &&
                   FullControl == other.FullControl;
        }
        /// <summary>
        /// hacker hashes
        /// </summary>
        /// <returns>returns the hash</returns>
        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(PermLvl);
            hash.Add(Open);
            hash.Add(Read);
            hash.Add(Write);
            hash.Add(Manage);
            hash.Add(VIPPrivalleges);
            hash.Add(ModPrivalleges);
            hash.Add(IsAdmin);
            hash.Add(FullControl);
            return hash.ToHashCode();
        }
        /// <summary>
        /// It is equality
        /// </summary>
        /// <param name="left">the left operand</param>
        /// <param name="right">the right operand</param>
        /// <returns></returns>
        public static bool operator ==(SecurityRights left, SecurityRights right)
        {
            return left.Equals(right);
        }
        /// <summary>
        /// it is not equal operator
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        /// <returns></returns>
        public static bool operator !=(SecurityRights left, SecurityRights right)
        {
            return !(left == right);
        }

        /// <summary>
        /// This is an Array to Give all of the values of SecurityRights's Properties
        /// </summary>
        /// <returns>Returns All The Properties of SecurityRights</returns>
        public bool[] ToArray()
        {
            return new[] { FullControl, IsAdmin, ModPrivalleges, VIPPrivalleges, Open, Read, Write, Manage };
        }
        /// <summary>
        /// Determines whether the current SecurityRights object meets the specified requirements.
        /// </summary>
        /// <param name="minimumPermissionLevel">The minimum required Permissions level.</param>
        /// <param name="requiredPermissions">An array of required permission values.</param>
        /// <param name="blockedPermissionLevels">An array of blocked permission levels.</param>
        /// <returns>True if the current SecurityRights object meets the specified requirements; otherwise, false.</returns>
        public bool HasRequiredPermissions(PermissionLvl minimumPermissionLevel, bool[]? requiredPermissions = null, params PermissionLvl[] blockedPermissionLevels)
        {
            if (FullControl) return true;
            if (!Open) return false;
            if ((int)PermLvl < (int)minimumPermissionLevel) return false;
            if (!blockedPermissionLevels.Contains(PermissionLvl.Suspended) && PermLvl == PermissionLvl.Suspended) return false;
            if (blockedPermissionLevels.Contains(PermLvl)) return false;
            if (requiredPermissions != null && !requiredPermissions.SequenceEqual(ToArray().Take(requiredPermissions.Length))) return false;
            if (PermLvl == PermissionLvl.MVP) throw new MVPException("U USED MVP I TOLD U EXCEPTION WOULD HAPPEN!");
            return true;
        }
        /// <summary>
        /// This is if u want ID
        /// </summary>
        /// <param name="rights">The SecurityRights instance required to make ID</param>
        /// <param name="Name">The name o user</param>
        /// <returns></returns>
        public static int[] WantID(SecurityRights rights, string Name)
        {
            bool[] permissions = rights.ToArray();
            int[] permissionsID = Array.Empty<int>();
            int[] nameID = Array.Empty<int>();
            int[] PermLvl = (int[])Enum.GetValues(typeof(PermissionLvl));
            for (int i = 0; i < permissions.Length; i++)
            {
                permissionsID[i] = permissions[i] ? 1 : 0;
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytenameID = encoding.GetBytes(Name).ToArray();
            for (int i = 0; i < bytenameID.Length; i++)
            {
                nameID[i] = bytenameID[i].As<int>();
            }
            int[] ID = new int[nameID.Length + PermLvl.Length + permissionsID.Length];
            Array.Copy(permissionsID, 0, ID, 0, permissionsID.Length);
            Array.Copy(PermLvl, 0, ID, permissionsID.Length, PermLvl.Length);
            Array.Copy(nameID, 0, ID, permissionsID.Length + PermLvl.Length, nameID.Length);
            return ID;
        }
        /// <summary>
        /// The ToString Method so it actually returns something good
        /// </summary>
        /// <returns>PermLvl the Permission Level of the object or The enum</returns>
        public override string ToString() => $"{PermLvl}";
    }
    static class SecurityRightsExtension
    {
        public static PermissionLvl ToPermissionLvl(this SecurityRights rights)
        {
            PermissionLvl lvl = (PermissionLvl)Enum.ToObject(typeof(PermissionLvl), rights);
            return lvl;
        }
    }
    /// <summary>
    /// This is an Enum that contains All the possible values that SecurityRights can have
    /// </summary>
    public enum PermissionLvl : int
    {
        /// <summary>
        /// This is the Suspended value and means user BANNED
        /// </summary>
        Suspended,
        /// <summary>
        /// This is the Untrusted value and means user is Untrusted or SUS
        /// </summary>
        Untrusted,
        /// <summary>
        /// This is the Member value and is the most common
        /// </summary>
        Member,
        /// <summary>
        /// This is the MVP value and is a Tier above Member but is unused dont use or exception
        /// </summary>
        MVP,
        /// <summary>
        /// This is the Master value and is actually a Tier above member and contains VIP Privillages
        /// </summary>
        Master,
        /// <summary>
        /// This is the Mod value I think u know what it is moderator...
        /// </summary>
        Moderator,
        /// <summary>
        /// ADMIN TIME
        /// </summary>
        Admin,
        /// <summary>
        /// Dangerous Use With Caution...
        /// </summary>
        OWNER
    }
}
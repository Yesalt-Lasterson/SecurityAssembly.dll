using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using Permissions;
using System.Security;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Data;
using System.Diagnostics.CodeAnalysis;

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
		public MVPException() {}
		/// <summary>
		/// IT STILL SAME
		/// </summary>
		/// <param name="message">Y U NO LISTEN</param>
		public MVPException(string message) : base(message) => Console.WriteLine(message);
		/// <summary>
		/// also Eh
		/// </summary>
		/// <param name="message">message</param>
		/// <param name="innerException">the other exception</param>
		public MVPException(string message, Exception innerException) : base(message, innerException) => Console.WriteLine(message + " " + innerException);
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
		/// The constructor that accepts ID as a valid SecurityRights Instance
		/// </summary>
		/// <param name="rawData">The ID</param>
		/// <exception cref="IDException">Happens When ID is null because It shouldn't be null under any circumstances memory error.</exception>
		public SecurityRights(ID rawData)
		{
			if(rawData == null)
			{
				throw new IDException();
			}
			int[] data = rawData.RequestID();
			FromID(data);
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
		/// Let's u make a SecurityRights Instance with ID!
		/// </summary>
		/// <param name="iD">The ID</param>
		/// <returns>An ID</returns>
		public static SecurityRights ToSecurityRights(ID iD) => new(iD);
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
		/// Makes it so that u can provide ID and it work
		/// </summary>
		/// <param name="iD">The ID</param>
		public static implicit operator SecurityRights(ID iD) => new(iD);
		/// <summary>
		/// This Does all the equals that
		/// </summary>
		/// <param name="obj">it is the object in question</param>
		/// <returns>returns false or true if everything it checks checks out</returns>

		public override readonly bool Equals(object? obj)
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
		public readonly bool Equals(SecurityRights other)
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
		public override readonly int GetHashCode()
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
		public static bool operator ==(SecurityRights left, SecurityRights right) => left.Equals(right);
		/// <summary>
		/// it is not equal operator
		/// </summary>
		/// <param name="left">left operand</param>
		/// <param name="right">right operand</param>
		/// <returns></returns>
		public static bool operator !=(SecurityRights left, SecurityRights right) => !(left == right);

		/// <summary>
		/// This is an Array to Give all of the values of SecurityRights's Properties
		/// </summary>
		/// <returns>Returns All The Properties of SecurityRights</returns>
		public readonly bool[] ToArray() => new[] { FullControl, IsAdmin, ModPrivalleges, VIPPrivalleges, Open, Read, Write, Manage };
		/// <summary>
		/// Determines whether the current SecurityRights object meets the specified requirements.
		/// </summary>
		/// <param name="minimumPermissionLevel">The minimum required Permissions level.</param>
		/// <param name="requiredPermissions">An array of required permission values.</param>
		/// <param name="blockedPermissionLevels">An array of blocked permission levels.</param>
		/// <returns>True if the current SecurityRights object meets the specified requirements; otherwise, false.</returns>
		public readonly bool HasRequiredPermissions(PermissionLvl minimumPermissionLevel, bool[]? requiredPermissions = null, params PermissionLvl[] blockedPermissionLevels)
		{
			if (PermLvl == PermissionLvl.BLACKLISTED) return false;
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
			ASCIIEncoding encoding = new();
			byte[] bytenameID = encoding.GetBytes(Name).ToArray();
			for (int i = 0; i < bytenameID.Length; i++)
			{
                nameID[i] = bytenameID[i];
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
		public override readonly string ToString() => $"{PermLvl}";
		/// <summary>
		/// This is the method that turns ID to SecurityRights
		/// </summary>
		/// <param name="RawData">The ID</param>
		/// <exception cref="IDException">Happens If it detects its null which Should not happen!</exception>
		public void FromID(int[] RawData)
		{
			if(RawData == null)
			{
				throw new IDException();
			}
			FullControl = RawData[0] == 1;
			IsAdmin = RawData[1] == 1;
			ModPrivalleges = RawData[2] == 1;
			VIPPrivalleges = RawData[3] == 1;
			Open = RawData[4] == 1;
			Read = RawData[5] == 1;
			Write = RawData[6] == 1;
			Manage = RawData[7] == 1;
			PermLvl = (PermissionLvl)Enum.ToObject(typeof(PermissionLvl), RawData[8]);
		}
	}
	/// <summary>
	/// This is the customizable version of SecurityRights!
	/// It allows for total customization.
	/// </summary>
	public class CustomSecurityRights
	{
		/// <summary>
		/// This Dictionary holds all the groups that have been created
		/// </summary>
		public static Dictionary<string, Group> Groups { get; private set; } = new();
		/// <summary>
		/// This Dictionary holds all the rights that have been created
		/// </summary>
		public static Dictionary<string, Right> RightsList { get; private set; } = new();
		/// <summary>
		/// The currently selected group to be the primary group.
		/// </summary>
		public static Group? ActiveGroup { get; private set; }
		/// <summary>
		/// The ToString() method overidden to match the requirements of CustomSecurityRights
		/// </summary>
		/// <returns>It returns the primary group</returns>
		public override string ToString() => $"{ActiveGroup}";
        /// <summary>
        /// This class holds all the methods to compare CustomSecurityRights!
        /// </summary>
#pragma warning disable CA1034 // Nested types should not be visible
        public sealed class Comparison
#pragma warning restore CA1034 // Nested types should not be visible
        {
			/// <summary>
			/// Method to compare two groups together
			/// </summary>
			/// <param name="groupName">The parameter used for comparason</param>
			/// <returns>Returns true or false depending if the ActiveGroup matching the selected group.</returns>
			public static bool CheckGroup(string groupName)
			{
				if (groupName == null)
					return false;
				if (ActiveGroup == null)
					return false;
				if (!Groups.ContainsKey(groupName))
					return false;
				if (ActiveGroup.Name != groupName)
					return false;
				return true;
			}
			/// <summary>
			/// Method to compare two groups together and see if it equals one of the blocked groups.
			/// </summary>
			/// <param name="groupName">Used to compare ActiveGroup</param>
			/// <param name="blockedGroups">All groups that ActiveGroup shouldn't be.</param>
			/// <returns>True or False if ActiveGroup matches all conditions</returns>
			public static bool CheckGroup(string groupName, string[] blockedGroups)
			{
				if (groupName == null)
					return false;
				if (ActiveGroup == null)
					return false;
				if (blockedGroups.Any(bGroup => bGroup == ActiveGroup.Name))
					return false;
				if (!Groups.ContainsKey(groupName))
					return false;
				if (ActiveGroup.Name != groupName)
					return false;
				return true;
			}
			/// <summary>
			/// Method to compare ActiveGroup and groupName, and if it equals an excemption group, then if it is part of one of the blocked groups.
			/// </summary>
			/// <param name="groupName">The group used to compare ActiveGroup</param>
			/// <param name="excemptGroups">Groups Excempt from Checking</param>
			/// <param name="blockedGroups">Groups not allowed to proceed</param>
			/// <returns>True or False if ActiveGroup equals, is excempt, or is blocked.</returns>
			public static bool CheckGroup(string groupName, string[] excemptGroups , string[] blockedGroups)
			{
				if (ActiveGroup == null)
					return false;
				if(excemptGroups.Any(eGroups => eGroups == ActiveGroup.Name))
					return true;
				if (groupName == null)
					return false;
				if (blockedGroups.Any(bGroups => bGroups == ActiveGroup.Name))
					return false;
				if (!Groups.ContainsKey(groupName))
					return false;
				if (ActiveGroup.Name != groupName)
					return false;
				return true;
			}
			/// <summary>
			/// Method that compares all of the ActiveGroup rights to a right.
			/// </summary>
			/// <param name="rightName">The right to compare to ActiveGroup</param>
			/// <returns>true if one Matches; false if it doesn't</returns>
			public static bool CheckRight(string rightName)
			{
				if (rightName == null)
					return false;
				if (ActiveGroup == null)
					return false;
				if (!RightsList.ContainsKey(rightName))
					return false;
				if (!ActiveGroup.Rights.ContainsKey(rightName))
					return false;
				return true;
			}
			/// <summary>
			/// Method that compares all of the ActiveGroup rights to an array of rights.
			/// </summary>
			/// <param name="rightName">Rights to compare to ActiveGroup</param>
			/// <returns>true if all of them match; else false.</returns>
			public static bool CheckRight(string[] rightName)
			{
				if (rightName == null)
					return false;
				if (ActiveGroup == null)
					return false;
				if (rightName != RightsList.Keys.ToArray()) 
					return false;
				if (rightName != ActiveGroup.Rights.Keys.ToArray())
						return false;
				return true;
			}
			/// <summary>
			/// Method that compares all of the ActiveGroup rights to an array of rights and blocked rights.
			/// </summary>
			/// <param name="rightName">Rights to compare to ActiveGroup.</param>
			/// <param name="blockedRights">BlockedRights to compare to ActiveGroup</param>
			/// <returns>true if all rights match and no blockedrights match; else false.</returns>
			public static bool CheckRight(string[] rightName, string[] blockedRights)
			{
				if (rightName == null)
					return false;
				if (ActiveGroup == null)
					return false;
				if (blockedRights == null)
					return false;
				if (blockedRights == ActiveGroup.Rights.Keys.ToArray())
					return false;
				if (rightName != RightsList.Keys.ToArray())
					return false;
				if (rightName != ActiveGroup.Rights.Keys.ToArray())
					return false;
				return true;
			}
			/// <summary>
			/// Method that compares all of the ActiveGroup rights to a right and blocked rights.
			/// </summary>
			/// <param name="rightName">A right to compare to ActiveGroup</param>
			/// <param name="blockedRights">BlockedRight to compare to ActiveGroup</param>
			/// <returns>true if it matches without any blocked rights; else false.</returns>
			public static bool CheckRight(string rightName, string[] blockedRights)
			{
				if (rightName == null)
					return false;
				if (ActiveGroup == null)
					return false;
				if (blockedRights == null)
					return false;
				if (blockedRights == ActiveGroup.Rights.Keys.ToArray())
					return false;
				if (!RightsList.ContainsKey(rightName))
					return false;
				if (!ActiveGroup.Rights.ContainsKey(rightName))
					return false;
				return true;
			}
			/// <summary>
			/// Method that compares all of the ActiveGroup rights to an array of rights unless excempt or blocked.
			/// </summary>
			/// <param name="rightName">Rights to compare to ActiveGroup</param>
			/// <param name="excemptRights">Rights that excempt ActiveGroup</param>
			/// <param name="blockedRights">Rights that block ActiveGroup</param>
			/// <returns>true if all rights match and no blocked rights match unless if a excempt right matches; else false.</returns>
			public static bool CheckRight(string[] rightName, string[] excemptRights, string[] blockedRights)
			{
				if (ActiveGroup == null)
					return false;
				if (excemptRights == ActiveGroup.Rights.Keys.ToArray())
					return true;
				if (rightName == null)
					return false;
				if (blockedRights == ActiveGroup.Rights.Keys.ToArray())
					return false;
				if (rightName != RightsList.Keys.ToArray())
					return false;
				if (rightName != ActiveGroup.Rights.Keys.ToArray())
					return false;
				return true;
			}
			/// <summary>
			/// Method that compares all of the ActiveGroup rights to a right unless excempt or blocked.
			/// </summary>
			/// <param name="rightName">Rights to compare to ActiveGroup</param>
			/// <param name="excemptRights">Rights that excempt ActiveGroup</param>
			/// <param name="blockedRights">Rights that block ActiveGroup</param>
			/// <returns>true if all rights match and no blocked rights match unless if a excempt right matches; else false.</returns>
			public static bool CheckRight(string rightName, string[] excemptRights, string[] blockedRights)
			{
				if (ActiveGroup == null)
					return false;
				if (excemptRights == ActiveGroup.Rights.Keys.ToArray())
					return true;
				if (rightName == null)
					return false;
				if (blockedRights == ActiveGroup.Rights.Keys.ToArray())
					return false;
				if (!RightsList.ContainsKey(rightName))
					return false;
				if (!ActiveGroup.Rights.ContainsKey(rightName))
					return false;
				return true;
			}
			/// <summary>
			/// Method to compare AccessLevels using RightType
			/// </summary>
			/// <param name="rightType">Required RightType</param>
			/// <returns>true if ActiveGroup meets RightType; else false.</returns>
			public static bool CheckAccessLevel(RightType rightType)
			{
				if (ActiveGroup == null)
					return false;
				if (ActiveGroup.RightType != rightType)
					return false;
				return true;
			}
			/// <summary>
			/// Method to compare AccessLevels using Legacy version
			/// </summary>
			/// <param name="legacyRightType">Required PermissionLevel</param>
			/// <returns>true if ActiveGroup meets PermissionLevel; else false.</returns>
			public static bool CheckAccessLevel(PermissionLvl legacyRightType)
			{
				if (ActiveGroup == null)
					return false;
				if (ActiveGroup.LegacyRightType != legacyRightType)
					return false;
				return true;
			}
		}
        /// <summary>
        /// The class that contains all the relevant data surrounding Groups.
        /// </summary>
#pragma warning disable CA1034 // Nested types should not be visible
        public class Group
#pragma warning restore CA1034 // Nested types should not be visible
        {
			/// <summary>
			/// The name of the group.
			/// </summary>
			public string Name { get; private set; }
			/// <summary>
			/// The access level of the group.
			/// </summary>
			public RightType RightType { get; private set; } = RightType.Member;
			/// <summary>
			/// The permission level of the group.
			/// </summary>
			public PermissionLvl LegacyRightType { get; private set; }
			/// <summary>
			/// A group's rights.
			/// </summary>
			public Dictionary<string, Right> Rights { get; private set; } = new();
			/// <summary>
			/// Constructor of Group to make new groups.
			/// </summary>
			/// <param name="name">Name of this group.</param>
			/// <param name="rightType">The access level of this group.</param>
			/// <param name="legacyRightType">The permission level of this group.</param>
			public Group(string name, RightType rightType, PermissionLvl legacyRightType)
			{
				Name = name;
				RightType = rightType;
				LegacyRightType = legacyRightType;
				Groups.Add(Name, this);
			}
			/// <summary>
			/// Method to add a right to this group.
			/// </summary>
			/// <param name="right">The name of the right you want to add to this group.</param>
			/// <exception cref="ArgumentException">This exception is triggered when you provide a null or wrong name of right!</exception>
			public void AddRight(string right)
			{
				Right? value = null;
				if(RightsList.ContainsKey(right)) 
					RightsList.TryGetValue(right, out value);
				if (value == null) 
					throw new ArgumentException("Invaild Argument: Argument does not correspond with any key in RightsList!");
				Rights.Add(right, value);
			}
			/// <summary>
			/// Method to remove a right from this group.
			/// </summary>
			/// <param name="right">The name of the right you wat to remove from this group.</param>
			/// <exception cref="ArgumentException">This exception is triggered when you provide a null or wrong name of right!</exception>
			public void RemoveRight(string right)
			{
				if (!RightsList.ContainsKey(right)) 
					throw new ArgumentException("Could not remove key: Key does not exist!");
				Rights.Remove(right);
			}
			/// <summary>
			/// Method to make this method the primary group!
			/// </summary>
			public void MakeActiveGroup()
			{
				ActiveGroup = this;
			}
			/// <summary>
			/// Removes group from the global groups dictionary and removes all info pertaining to this group. Cannot be undone.
			/// </summary>
			public void RemoveGroup()
			{
				if (ActiveGroup != null && ActiveGroup.Name == Name)
					ActiveGroup = null;
				Groups.Remove(Name);
				Rights.Clear();
				Name = string.Empty;
				RightType = RightType.Member;
				LegacyRightType = PermissionLvl.Member;
			}
			/// <summary>
			/// Removes removed rights from the dictioinary from all groups.
			/// </summary>
			/// <param name="group">Group you want to update</param>
			/// <exception cref="ArgumentException">This exception is triggered when you provide a null or wrong name of group!</exception>
			public static void UpdateRights(Group group)
			{
				foreach(var right in RightsList.Keys)
				{
#pragma warning disable CA1853
					if (group == null)
						throw new ArgumentException("Invalid Argument: Group Cannot Be Null!");
					if (!RightsList.ContainsKey(right))
						group.Rights.Remove($"{right}");
#pragma warning restore CA1853
				}
			}
			/// <summary>
			/// Override to the method ToString().
			/// </summary>
			/// <returns>The name of the group.</returns>
			public override string ToString() => $"{Name}";
		}
        /// <summary>
        /// The class where all data pertaining to rights goes.
        /// </summary>
#pragma warning disable CA1034 // Nested types should not be visible
        public class Right
#pragma warning restore CA1034 // Nested types should not be visible
        {
			/// <summary>
			/// The name of the right.
			/// </summary>
			public string Name { get; private set; }
			/// <summary>
			/// The total hazard level of the right.
			/// </summary>
			public HazardLevel HazardsLevels { get; private set; }
			/// <summary>
			/// Constructor of Right, is where you can create new rights.
			/// </summary>
			/// <param name="name">Name of right.</param>
			/// <param name="hazardLevel">Total hazard level of right.</param>
			public Right(string name, HazardLevel hazardLevel)
			{
				Name = name;
				HazardsLevels = hazardLevel;
				if (!RightsList.ContainsKey(name))
					RightsList.Add(Name, this);
			}
			/// <summary>
			/// Deletes a right from the global rights dictionary and removes all refrences from methods and removes all data with instance of right.
			/// </summary>
			public void DeleteRight()
			{
				RightsList.Remove(Name);
				Name = string.Empty;
				HazardsLevels.Clear();
				foreach (var group in Groups.Values)
				{
					Group.UpdateRights(group);
				}
			}
			/// <summary>
			/// overrides the ToString() method.
			/// </summary>
			/// <returns>The name of this right.</returns>
			public override string ToString() => $"{Name}";
		}
        /// <summary>
        /// This is where HazardLevel get's calculated.
        /// </summary>
#pragma warning disable CA1034 // Nested types should not be visible
        public struct HazardLevel : IEquatable<HazardLevel>
#pragma warning restore CA1034 // Nested types should not be visible
        {
			/// <summary>
			/// The authentication needed to run a command.
			/// </summary>
			public sbyte WarningLevel { get; private set; } = 0;
			/// <summary>
			/// The level of access needed to use a right; if not met requires elevation.
			/// </summary>
			public sbyte AccessLevel { get; private set; } = 0;
			/// <summary>
			/// The ability to elevate no matter if you have the rule or not.
			/// </summary>
			public bool RuleElevationAlways { get; private set; } = false;
			/// <summary>
			/// Grants access to all rules even if not given.
			/// </summary>
			public bool RuleBypassEnabled { get; private set; } = false;
			/// <summary>
			/// Constructor of hazard level.
			/// </summary>
			/// <param name="warningLevel">The authentication needed to run a command.</param>
			/// <param name="accessLevel">The level of access needed to use a right; if not met requires elevation.</param>
			/// <param name="ruleElevationAlways">The ability to elevate no matter if you have the rule or not.</param>
			/// <param name="ruleBypassEnabled">Grants access to all rules even if not given.</param>
			public HazardLevel(sbyte warningLevel, sbyte accessLevel, bool ruleElevationAlways, bool ruleBypassEnabled)
			{
				WarningLevel = warningLevel;
				AccessLevel = accessLevel;
				RuleElevationAlways = ruleElevationAlways;
				RuleBypassEnabled = ruleBypassEnabled;
			}
			/// <summary>
			/// Resets all values to their default state.
			/// </summary>
			public void Clear()
			{
				WarningLevel = 0; AccessLevel = 0; RuleElevationAlways = false; RuleBypassEnabled = false;
			}
			/// <summary>
			/// Overrides the method ToString().
			/// </summary>
			/// <returns>This instance's WarningLevel, AccessLevel, RuleElevationAlways boolean, and RuleBypassEnabled flag</returns>
			public override readonly string ToString() => $"WarnLevel: {WarningLevel}, Access: {AccessLevel}, ElevationBypass: {RuleElevationAlways}, RuleBypass: {RuleBypassEnabled}.";
			/// <summary>
			/// ...
			/// </summary>
			/// <param name="obj">...</param>
			/// <returns>...</returns>
			public override readonly bool Equals(object? obj)
			{
				if (obj is HazardLevel other)
				{
					return Equals(other);
				}
				return false;
			}
			/// <summary>
			/// ...
			/// </summary>
			/// <param name="other">...</param>
			/// <returns>...</returns>
			public readonly bool Equals(HazardLevel other)
			{
				return WarningLevel == other.WarningLevel &&
					   AccessLevel == other.AccessLevel &&
					   RuleElevationAlways == other.RuleElevationAlways &&
					   RuleBypassEnabled == other.RuleBypassEnabled;
			}
			/// <summary>
			/// ...
			/// </summary>
			/// <returns>...</returns>
			public override readonly int GetHashCode()
			{
				HashCode hash = new();
				hash.Add(WarningLevel);
				hash.Add(AccessLevel);
				hash.Add(RuleElevationAlways);
				hash.Add(RuleBypassEnabled);
				return hash.ToHashCode();
			}
			/// <summary>
			/// ...
			/// </summary>
			/// <param name="left">...</param>
			/// <param name="right">...</param>
			/// <returns>...</returns>
			public static bool operator ==(HazardLevel left, HazardLevel right)
			{
				return left.Equals(right);
			}
			/// <summary>
			/// ...
			/// </summary>
			/// <param name="left">...</param>
			/// <param name="right">...</param>
			/// <returns>...</returns>
			public static bool operator !=(HazardLevel left, HazardLevel right)
			{
				return !(left == right);
			}
		}
		/// <summary>
		/// Fixed values that the RightType can be
		/// </summary>
		public enum RightType : int
		{
			/// <summary>
			/// Default
			/// </summary>
			Member = 0,
			/// <summary>
			/// Special Person
			/// </summary>
			VIP = 1,
			/// <summary>
			/// Someone that is trusted
			/// </summary>
			Privillaged = 2,
			/// <summary>
			/// A moderator
			/// </summary>
			Moderator = 3,
			/// <summary>
			/// An Admin
			/// </summary>
			Administrator = 4,
			/// <summary>
			/// Max Privillages
			/// </summary>
			Owner = 5
		}
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
		/// BLACKLISTED!!!
		/// </summary>
		BLACKLISTED = -127,
		/// <summary>
		/// This is the Suspended value and means user BANNED
		/// </summary>
		Suspended = -2,
		/// <summary>
		/// This is the Untrusted value and means user is Untrusted or SUS
		/// </summary>
		Untrusted = -1,
		/// <summary>
		/// This is the Member value and is the most common
		/// </summary>
		Member = 0,
		/// <summary>
		/// This is the MVP value and is a Tier above Member but is unused dont use or exception
		/// </summary>
		MVP = 1,
		/// <summary>
		/// This is the Master value and is actually a Tier above member and contains VIP Privillages
		/// </summary>
		Master = 2,
		/// <summary>
		/// This is the Mod value I think u know what it is moderator...
		/// </summary>
		Moderator = 3,
		/// <summary>
		/// ADMIN TIME
		/// </summary>
		Admin = 4,
		/// <summary>
		/// Dangerous Use With Caution...
		/// </summary>
		OWNER = 5
	}
}
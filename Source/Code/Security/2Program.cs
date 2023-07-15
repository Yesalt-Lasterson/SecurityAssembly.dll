// Decompiled with JetBrains decompiler
// Type: Permissions.SecurityRights
// Assembly: Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=56e1fe12a856d2a1
// MVID: 3909B7DE-59AF-41C6-A001-650F52410ADB
// Assembly location: C:\highFolder\Permissions\ver 1.0.0.0\Security.dll
// XML documentation location: C:\highFolder\Permissions\ver 1.0.0.0\Security.xml

using System;
using System.Collections.Generic;
using System.Linq;


#nullable enable
namespace Permissions
{
  /// <summary>
  /// The SecurityRights Struct that contains all of the code needed to check for permissions with one Parameter from you
  /// </summary>
  public struct SecurityRights : IEquatable<SecurityRights>
  {
    private PermissionLvl PermLvl { get; set; }

    private bool Open { get; set; }

    private bool Read { get; set; }

    private bool Write { get; set; }

    private bool Manage { get; set; }

    private bool VIPPrivalleges { get; set; }

    private bool ModPrivalleges { get; set; }

    private bool IsAdmin { get; set; }

    private bool FullControl { get; set; }

    /// <summary>
    /// The Constructor of SecurityRights To let all of it's properties have values for Variable to be usefull
    /// </summary>
    /// <param name="PermissionsLevel">Is the value that you provided</param>
    public SecurityRights(PermissionLvl PermissionsLevel)
    {
      // ISSUE: reference to a compiler-generated field
      this.\u003COpen\u003Ek__BackingField = true;
      // ISSUE: reference to a compiler-generated field
      this.\u003CRead\u003Ek__BackingField = false;
      // ISSUE: reference to a compiler-generated field
      this.\u003CWrite\u003Ek__BackingField = false;
      // ISSUE: reference to a compiler-generated field
      this.\u003CManage\u003Ek__BackingField = false;
      // ISSUE: reference to a compiler-generated field
      this.\u003CVIPPrivalleges\u003Ek__BackingField = false;
      // ISSUE: reference to a compiler-generated field
      this.\u003CModPrivalleges\u003Ek__BackingField = false;
      // ISSUE: reference to a compiler-generated field
      this.\u003CIsAdmin\u003Ek__BackingField = false;
      // ISSUE: reference to a compiler-generated field
      this.\u003CFullControl\u003Ek__BackingField = false;
      this.PermLvl = PermissionsLevel;
      switch (this.PermLvl)
      {
        case PermissionLvl.Suspended:
          this.Open = false;
          break;
        case PermissionLvl.Member:
          this.Open = true;
          this.Read = true;
          break;
        case PermissionLvl.Master:
          this.Open = true;
          this.Read = true;
          this.VIPPrivalleges = true;
          break;
        case PermissionLvl.Moderator:
          this.Open = true;
          this.Read = true;
          this.ModPrivalleges = true;
          break;
        case PermissionLvl.Admin:
          this.Open = true;
          this.Read = true;
          this.VIPPrivalleges = true;
          this.IsAdmin = true;
          break;
        case PermissionLvl.OWNER:
          this.FullControl = true;
          break;
      }
    }

    /// <summary>
    /// If u wat to be in the safe side also allows enum called PermissionLvl
    /// </summary>
    /// <param name="PermissionsLevel">Is the value that you provided</param>
    public static SecurityRights ToPermission(PermissionLvl PermissionsLevel) => new SecurityRights(PermissionsLevel);

    /// <summary>
    /// Makes Code Simpler by allowing to declare variable by string
    /// </summary>
    /// <param name="PermissionsLevel">Is the value that you provided</param>
    public static SecurityRights ToPermission(string PermissionsLevel) => new SecurityRights((PermissionLvl) Enum.Parse(typeof (PermissionLvl), PermissionsLevel, true));

    /// <summary>This Does all the equals that</summary>
    /// <param name="obj">it is the object in question</param>
    /// <returns>returns false or true if everything it checks checks out</returns>
    public override bool Equals(object? obj) => obj is SecurityRights securityRights && this.PermLvl == securityRights.PermLvl && this.Open == securityRights.Open && this.Read == securityRights.Read && this.Write == securityRights.Write && this.Manage == securityRights.Manage && this.VIPPrivalleges == securityRights.VIPPrivalleges && this.ModPrivalleges == securityRights.ModPrivalleges && this.IsAdmin == securityRights.IsAdmin && this.FullControl == securityRights.FullControl;

    /// <summary>Equals cousin</summary>
    /// <param name="other">other stuff</param>
    /// <returns>returns if everything checks out again</returns>
    public bool Equals(SecurityRights other) => this.PermLvl == other.PermLvl && this.Open == other.Open && this.Read == other.Read && this.Write == other.Write && this.Manage == other.Manage && this.VIPPrivalleges == other.VIPPrivalleges && this.ModPrivalleges == other.ModPrivalleges && this.IsAdmin == other.IsAdmin && this.FullControl == other.FullControl;

    /// <summary>hacker hashes</summary>
    /// <returns>returns the hash</returns>
    public override int GetHashCode()
    {
      HashCode hashCode = new HashCode();
      hashCode.Add<PermissionLvl>(this.PermLvl);
      hashCode.Add<bool>(this.Open);
      hashCode.Add<bool>(this.Read);
      hashCode.Add<bool>(this.Write);
      hashCode.Add<bool>(this.Manage);
      hashCode.Add<bool>(this.VIPPrivalleges);
      hashCode.Add<bool>(this.ModPrivalleges);
      hashCode.Add<bool>(this.IsAdmin);
      hashCode.Add<bool>(this.FullControl);
      return hashCode.ToHashCode();
    }

    /// <summary>It is equality</summary>
    /// <param name="left">the left operand</param>
    /// <param name="right">the right operand</param>
    /// <returns></returns>
    public static bool operator ==(SecurityRights left, SecurityRights right) => left.Equals(right);

    /// <summary>it is not equal operator</summary>
    /// <param name="left">left operand</param>
    /// <param name="right">right operand</param>
    /// <returns></returns>
    public static bool operator !=(SecurityRights left, SecurityRights right) => !(left == right);

    /// <summary>
    /// This is an Array to Give all of the values of SecurityRights's Properties
    /// </summary>
    /// <returns>Returns All The Properties of SecurityRights</returns>
    public bool[] ToArray() => new bool[8]
    {
      this.FullControl,
      this.IsAdmin,
      this.ModPrivalleges,
      this.VIPPrivalleges,
      this.Open,
      this.Read,
      this.Write,
      this.Manage
    };

    /// <summary>
    /// Determines whether the current SecurityRights object meets the specified requirements.
    /// </summary>
    /// <param name="minimumPermissionLevel">The minimum required Permissions level.</param>
    /// <param name="requiredPermissions">An array of required permission values.</param>
    /// <param name="blockedPermissionLevels">An array of blocked permission levels.</param>
    /// <returns>True if the current SecurityRights object meets the specified requirements; otherwise, false.</returns>
    public bool HasRequiredPermissions(
      PermissionLvl minimumPermissionLevel,
      bool[]? requiredPermissions = null,
      params PermissionLvl[] blockedPermissionLevels)
    {
      if (!this.Open || this.FullControl || this.PermLvl < minimumPermissionLevel || !((IEnumerable<PermissionLvl>) blockedPermissionLevels).Contains<PermissionLvl>(PermissionLvl.Suspended) && this.PermLvl == PermissionLvl.Suspended || ((IEnumerable<PermissionLvl>) blockedPermissionLevels).Contains<PermissionLvl>(this.PermLvl) || requiredPermissions != null && !((IEnumerable<bool>) requiredPermissions).SequenceEqual<bool>(((IEnumerable<bool>) this.ToArray()).Take<bool>(requiredPermissions.Length)))
        return false;
      if (this.PermLvl == PermissionLvl.MVP)
        throw new MVPException("U USED MVP I TOLD U EXCEPTION WOULD HAPPEN!");
      return true;
    }
  }
}

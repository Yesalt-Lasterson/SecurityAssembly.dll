// Decompiled with JetBrains decompiler
// Type: Permissions.IPermssionsLevel
// Assembly: Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=56e1fe12a856d2a1
// MVID: 3909B7DE-59AF-41C6-A001-650F52410ADB
// Assembly location: C:\highFolder\Permissions\ver 1.0.0.0\Security.dll
// XML documentation location: C:\highFolder\Permissions\ver 1.0.0.0\Security.xml

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
    PermissionLvl Suspended { get; set; }

    /// <summary>
    /// This is the Property Untrusted corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl Untrusted { get; set; }

    /// <summary>
    /// This is the Property Member corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl Member { get; set; }

    /// <summary>
    /// This is the Property MVP corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl MVP { get; set; }

    /// <summary>
    /// This is the Property Master corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl Master { get; set; }

    /// <summary>
    /// This is the Property Mod corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl Moderator { get; set; }

    /// <summary>
    /// This is the Property Admin corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl Admin { get; set; }

    /// <summary>
    /// This is the Property OWNER corresponding to the values in the enum PermissionLvl
    /// </summary>
    PermissionLvl OWNER { get; set; }
  }
}

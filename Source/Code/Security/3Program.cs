// Decompiled with JetBrains decompiler
// Type: Permissions.PermissionLvl
// Assembly: Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=56e1fe12a856d2a1
// MVID: 3909B7DE-59AF-41C6-A001-650F52410ADB
// Assembly location: C:\highFolder\Permissions\ver 1.0.0.0\Security.dll
// XML documentation location: C:\highFolder\Permissions\ver 1.0.0.0\Security.xml

namespace Permissions
{
  /// <summary>
  /// This is an Enum that contains All the possible values that SecurityRights can have
  /// </summary>
  public enum PermissionLvl
  {
    /// <summary>This is the Suspended value and means user BANNED</summary>
    Suspended,
    /// <summary>
    /// This is the Untrusted value and means user is Untrusted or SUS
    /// </summary>
    Untrusted,
    /// <summary>This is the Member value and is the most common</summary>
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
    /// <summary>ADMIN TIME</summary>
    Admin,
    /// <summary>Dangerous Use With Caution...</summary>
    OWNER,
  }
}

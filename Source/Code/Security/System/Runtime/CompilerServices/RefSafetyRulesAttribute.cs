// Decompiled with JetBrains decompiler
// Type: System.Runtime.CompilerServices.RefSafetyRulesAttribute
// Assembly: Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=56e1fe12a856d2a1
// MVID: 3909B7DE-59AF-41C6-A001-650F52410ADB
// Assembly location: C:\highFolder\Permissions\ver 1.0.0.0\Security.dll
// XML documentation location: C:\highFolder\Permissions\ver 1.0.0.0\Security.xml

using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
  [CompilerGenerated]
  [Embedded]
  [AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
  internal sealed class RefSafetyRulesAttribute : Attribute
  {
    public readonly int Version;

    public RefSafetyRulesAttribute([In] int obj0) => this.Version = obj0;
  }
}

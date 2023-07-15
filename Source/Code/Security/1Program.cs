// Decompiled with JetBrains decompiler
// Type: Permissions.MVPException
// Assembly: Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=56e1fe12a856d2a1
// MVID: 3909B7DE-59AF-41C6-A001-650F52410ADB
// Assembly location: C:\highFolder\Permissions\ver 1.0.0.0\Security.dll
// XML documentation location: C:\highFolder\Permissions\ver 1.0.0.0\Security.xml

using System;


#nullable enable
namespace Permissions
{
  /// <summary>ME WARN U</summary>
  public class MVPException : Exception
  {
    /// <summary>eh</summary>
    public MVPException()
    {
    }

    /// <summary>IT STILL SAME</summary>
    /// <param name="message">Y U NO LISTEN</param>
    public MVPException(string message)
      : base(message)
    {
      Console.WriteLine(message);
    }

    /// <summary>also Eh</summary>
    /// <param name="message">message</param>
    /// <param name="innerException">the other exception</param>
    public MVPException(string message, Exception innerException)
      : base(message, innerException)
    {
      Console.WriteLine(message + " " + innerException?.ToString());
    }
  }
}

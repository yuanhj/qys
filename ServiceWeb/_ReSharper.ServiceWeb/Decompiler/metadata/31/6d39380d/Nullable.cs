// Type: System.Nullable`1
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime;

namespace System
{
  [__DynamicallyInvokable]
  [Serializable]
  public struct Nullable<T> where T : struct
  {
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    [__DynamicallyInvokable]
    public Nullable(T value);
    [__DynamicallyInvokable]
    public static implicit operator T?(T value);
    [__DynamicallyInvokable]
    public static explicit operator T(T? value);
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    [__DynamicallyInvokable]
    public T GetValueOrDefault();
    [__DynamicallyInvokable]
    public T GetValueOrDefault(T defaultValue);
    [__DynamicallyInvokable]
    public override bool Equals(object other);
    [__DynamicallyInvokable]
    public override int GetHashCode();
    [__DynamicallyInvokable]
    public override string ToString();
    [__DynamicallyInvokable]
    public bool HasValue { [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; }
    [__DynamicallyInvokable]
    public T Value { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable] get; }
  }
}

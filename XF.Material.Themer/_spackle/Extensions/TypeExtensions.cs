//using System;
//using System.Linq;
//using System.Reflection;

//namespace Spackle.Extensions
//{
//  public static class TypeExtensions
//  {
//    public static bool IsEnumType(this Type type)
//    {
//      return type.GetTypeInfo().IsEnum;
//    }

//    public static bool IsClassType(this Type type)
//    {
//      return type.GetTypeInfo().IsClass;
//    }

//    public static bool IsPrimitiveType(this Type type)
//    {
//      return type.GetTypeInfo().IsPrimitive;
//    }

//    public static bool IsIntegralType(this Type type)
//    {
//      return new[] {typeof (byte), typeof (sbyte), typeof (short), typeof (ushort),
//        typeof (int), typeof (uint), typeof (long), typeof (ulong)}.Contains(type);
//    }
//  }
//}
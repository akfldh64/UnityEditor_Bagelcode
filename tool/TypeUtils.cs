using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace akfldh64
{

public static class TypeUtils
{
	public static object ChangeType(object value, Type type)
	{
		if (value == null || type == null) return null;
		try
		{
			return Convert.ChangeType(value, type);
		}
		catch
		{
			// throw new System.InvalidOperationException(string.Format("Value not convert from {0} to {1}", value.GetType().ToString(), type.ToString()));
			return null;
		}
	}

	public static Type GetType(string TypeName)
	{
		var type = Type.GetType(TypeName);
		if (type != null)
		{
			return type;
		}

		if (TypeName.Contains( "." ))
		{
			string[] arr = TypeName.Split('.');
			var tailTypeName = arr[arr.Length - 1];

			var assemblyName = TypeName.Substring(0, TypeName.IndexOf(tailTypeName) - 1);

			var assembly = Assembly.Load(assemblyName);
			if (assembly == null)
			{
				return null;
			}

			type = assembly.GetType(TypeName);
			if (type != null)
			{
				return type;
			}
		}

		return null;
	}
}

}

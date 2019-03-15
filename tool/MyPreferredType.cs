using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace akfldh64
{

public static class MyPreferredType
{
	private static List<Type> options = new List<Type>();

	static MyPreferredType()
	{
		Update();
	}

	public static List<Type> List
	{
		get { return options; }
	}

	public static Type Find(int index)
	{
		return options.ElementAtOrDefault(index);
	}

	public static void Update()
	{
		options.Clear();
		string path = Application.dataPath + "/PreferredTypes.typePrefs";
		using (StreamReader sr = File.OpenText(path))
		{
			string line;
			while ((line = sr.ReadLine()) != null) 
			{
				if (line.Contains("\""))
				{
					string[] strs = line.Split(',');
					string typeName = strs[0].Replace("\"", "").Replace(" ", "");
					options.Add(TypeUtils.GetType(typeName));
				}
			}
		}
	}
}

}

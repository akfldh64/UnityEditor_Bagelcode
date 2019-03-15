using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace akfldh64.Editor
{

public class MyEditorUtils
{
	[MenuItem("akfldh64/Utils/Update MyPreferredType")]
	public static void UpdateMyPreferredType()
	{
		MyPreferredType.Update();
	}
}

}

#endif

using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

public class ClearBlackboardVariable : MonoBehaviour 
{
	[ContextMenu("Clear Blackboard")]
	public void ClearBlackboardAtChild ()
	{
		var childCount = transform.childCount;
		for (int i = 0; i < childCount; ++i) {
			var child = transform.GetChild(i);
			IBlackboard bb = child.GetComponent<Blackboard>();

			if (bb != null) {
				List<string> variableNameList = new List<string>();
				foreach(var pair in bb.variables) {
					variableNameList.Add(pair.Key);
				}
				foreach(var name in variableNameList) {
					bb.RemoveVariable(name);
				}
			}
		}
	}
}

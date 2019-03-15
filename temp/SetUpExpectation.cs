using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpExpectation : MonoBehaviour {

	[ContextMenu("Do")]
	void Do () 
	{
		for (int i = 2; i < transform.childCount; ++i)
		{
			var child = transform.GetChild(i);
			var anchor = child.GetChild(0);
			var expectation = anchor.GetChild(5);

			Debug.Log(child.name);
			Debug.Log(anchor.name);
			Debug.Log(expectation.name);

			var newExpectation = new GameObject().AddComponent<RectTransform>();

			newExpectation.transform.SetParent(anchor);
			newExpectation.localScale = Vector3.one;
			newExpectation.localPosition = Vector3.zero;
			newExpectation.gameObject.name = "Expectation";
			expectation.transform.SetParent(newExpectation.transform);
		}
	}
}

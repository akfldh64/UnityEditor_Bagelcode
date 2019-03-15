using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAnimationStateHash : MonoBehaviour {

	public string stateName = "";

	[ContextMenu("Get Hash")]
	void DoAction()
	{
		var hashName = Animator.StringToHash(stateName);
		Debug.Log(hashName);
	}
}

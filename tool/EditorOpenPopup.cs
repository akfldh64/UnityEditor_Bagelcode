using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlotMaker;

#if UNITY_EDITOR

using UnityEditor;

namespace akfldh64.Editor
{

public class EditorOpenPopup : EditorWindow
{
	private SceneInfoObject sceneInfoObject;
	private Stack<GameObject> popupStack = new Stack<GameObject>();

	void OnGUI()
	{
		sceneInfoObject = (SceneInfoObject)EditorGUILayout.ObjectField("Scene Asset", sceneInfoObject, typeof(ScriptableObject), false);

		if (GUILayout.Button("Open Popup"))
		{
			if (sceneInfoObject != null)
			{
				SceneInfo sceneInfo = sceneInfoObject.GetSceneInfo();
				if (Application.isPlaying)
				{
					GameObject obj = SceneManager.LoadScene(GameObject.Find("Popup Manager").transform, sceneInfo);
					popupStack.Push(obj);

					obj.SetActive(false);
					obj.SetActive(true);

					PopupManager.Instance.Open(obj);
				}
				else
				{
					SceneManager.LoadSceneInEditor(GameObject.Find("Popup Manager").transform, sceneInfo);
				}
			}
		}

		if (Application.isPlaying)
		{
			if (GUILayout.Button("Close Popup"))
			{
				if (popupStack.Count != 0)
				{
					GameObject obj = popupStack.Pop();
					Animator ani = obj.GetComponent<Animator>();
					if (ani != null && hasCloseAnimation(ani))
					{
						ani.SetTrigger("Close");
						PopupManager.Instance.Close(obj);
					}
				}
			}

			if (GUILayout.Button("Clear"))
			{
				while (popupStack.Count != 0)
				{
					GameObject obj = popupStack.Pop();
					PopupManager.Instance.Close(obj);
					Object.DestroyImmediate(obj);
				}
			}
		}
	}

	private bool hasCloseAnimation(Animator ani)
	{
		var parameterList = ani.parameters;
		foreach (var param in parameterList)
		{
			if (param.name == "Close") return true;
		}
		return false;
	}
}

}

#endif
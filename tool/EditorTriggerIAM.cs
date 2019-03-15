using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BagelCode;
using BagelCode.ClientModels;
using SlotMaker;

#if UNITY_EDITOR
using UnityEditor;

namespace akfldh64.Editor
{

public class EditorTriggerIAM : EditorWindow 
{
	public InAppMessageTriggerType triggerType = InAppMessageTriggerType.UNKNOWN;
	public int id;

	void OnGUI()
	{
		triggerType = (InAppMessageTriggerType)EditorGUILayout.EnumPopup("Type", triggerType);
		if (triggerType == InAppMessageTriggerType.UNKNOWN)
		{
			id = EditorGUILayout.IntField("ID", id);
		}

		if (GUILayout.Button("Trigger") && Application.isPlaying)
		{
			if (triggerType != InAppMessageTriggerType.UNKNOWN)
			{
				IAMRouter.Instance.TriggerIAM(triggerType, null, "");
			}
			else
			{
				IAMRouter.Instance.TriggerIAMByID(triggerType, id, null, "");
			}
		}
	}
}

}

#endif

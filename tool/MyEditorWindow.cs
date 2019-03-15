using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

namespace akfldh64.Editor
{

public class MyEditorWindow : EditorWindow
{
	private static EditorEventSimulator eventSimulatorWindow;
	private static EditorTriggerIAM triggerIAMWindow;
	private static EditorOpenPopup openPopupWindow;

	[MenuItem("akfldh64/EventSimulator")]
	public static void OnEventSenderWindow()
	{
		eventSimulatorWindow = (EditorEventSimulator)EditorWindow.GetWindow(typeof(EditorEventSimulator), false, "Event Simulator");
		eventSimulatorWindow.Show();
	}

	[MenuItem("akfldh64/IAMTrigger")]
	public static void OnTriggerIAMWindow()
	{
		triggerIAMWindow = (EditorTriggerIAM)EditorWindow.GetWindow(typeof(EditorTriggerIAM), false, "IAM Trigger");
		triggerIAMWindow.Show();
	}

	[MenuItem("akfldh64/OpenPopup")]
	public static void OpenPopupWindow()
	{
		openPopupWindow = (EditorOpenPopup)EditorWindow.GetWindow(typeof(EditorOpenPopup), false, "Open Popup");
		openPopupWindow.Show();
	}
}

}

#endif

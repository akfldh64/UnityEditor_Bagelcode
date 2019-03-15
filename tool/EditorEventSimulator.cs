using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion;
using SlotMaker;

#if UNITY_EDITOR
using UnityEditor;

namespace akfldh64.Editor
{

public class EditorEventSimulator : EditorWindow
{
    public string eventName;

    private int       typeIndex;
    private int       eventTypeIndex;
    private object    value = new System.Object();

    public void OnGUI()
    {
        eventName = EditorGUILayout.TextField("Event Name", eventName);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Event Type", GUILayout.Width(145));
        eventTypeIndex = EditorGUILayout.Popup(eventTypeIndex, MyEventType.typeList.ToArray());
        EditorGUILayout.EndHorizontal();

        DrawValueProperty(typeIndex);

        if(GUILayout.Button("Send Event"))
        {
            var eventData = TypeUtils.ChangeType(value, MyPreferredType.Find(typeIndex));
            string eventKey = MyEventType.typeList[eventTypeIndex];
            string eventType = MyEventType.typeDict[eventKey];

            if (string.Equals("Default", eventType))
            {
                EventSender.SendGlobalEvent(eventName, eventData);
            }
            else
            {
                EventSender.Dispatch(eventType, eventName, eventData);
            }

        }
    }

    private void DrawValueProperty(int index)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Value Type", GUILayout.Width(145));
        index = EditorGUILayout.Popup(index, GetTypeArray());
        EditorGUILayout.EndHorizontal();

        Type type = MyPreferredType.Find(index);
        if (type.IsEnum)
        {
            var obj = System.Activator.CreateInstance(type);
            value = EditorGUILayout.EnumPopup("Value", (System.Enum)GetValue(index, obj));
        }
        else if (type.IsPrimitive || type == typeof(string))
        {
            value = EditorGUILayout.TextField("Value", GetValue(index, "").ToString());
        }
        else
        {
            // etc..
        }

        typeIndex = index;
    }

    private object GetValue(int newIndex, object defaultValue)
    {
        if (defaultValue.GetType() != value.GetType() || newIndex != typeIndex)
        {
            value = defaultValue;
        }
        return value;
    }

    public static string[] GetTypeArray()
    {
        List<Type> typeList = MyPreferredType.List;
        string[] strArr = Array.ConvertAll(typeList.ToArray(), new Converter<Type, string>( (element) => { return element.ToString(); } ));
        return strArr;
    }
}

}

#endif


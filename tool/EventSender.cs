using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

using SlotMaker;

namespace akfldh64
{

public static class EventSender
{
	private static MethodInfo eventMethod = null;
	private static MethodInfo eventMethodGeneric = null;

	private static void Initialize()
	{
		var methods = typeof(Graph).GetMethods(BindingFlags.Public | BindingFlags.Static);
		for (int i = 0; i < methods.Length; ++i)
		{
			if (string.Equals(methods[i].Name, "SendGlobalEvent"))
			{
				if (methods[i].GetGenericArguments().Length == 1)
				{
					eventMethodGeneric = methods[i];
				}
				else
				{
					var p = methods[i].GetParameters();
					Type type = p[0].ParameterType;

					if (Type.Equals(type, typeof(string)))
					{
						eventMethod = methods[i];
					}
				}
			}
		}		
	}

	static EventSender()
	{
		Initialize();
	}

	public static void Dispatch(string eventType, string eventName, object value = null)
	{
		EventData eventData = InstantiateEventData(eventName, value);
		MessageDispatcher.Dispatch(eventType, eventData);
	}

	public static void SendGlobalEvent(string eventName, object value = null)
	{
		MethodInfo mi = eventMethod;
		if (value != null)
		{
			mi = eventMethodGeneric.MakeGenericMethod(value.GetType());
			mi.Invoke(null, new object[]{eventName, value});
		}
		else
		{
			mi.Invoke(null, new object[]{eventName});
		}
	}

	private static EventData InstantiateEventData(string eventName, object value = null)
	{
		if (value == null)
		{
			return new EventData(eventName);
		}

		Type generic = typeof(EventData<>);
		Type eventDataType = generic.MakeGenericType(value.GetType());
		return (EventData)System.Activator.CreateInstance(eventDataType, eventName, value);
	}
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace akfldh64
{

public class MyEventType : MonoBehaviour
{
	public static List<string> typeList;
	public static Dictionary<string, string> typeDict;

	static MyEventType()
	{
		typeList = new List<string>()
		{
			"DEFAULT",
			"ON_WIN_EVENT",
			"ON_SLOT_EVENT",
			"ON_SOUND_EVENT",
			"ON_CREDIT_EVENT",
			"ON_META_UI_EVENT",
			"ON_SYSTEM_EVENT",
			"ON_CONTENT_EVENT",
			"ON_PASSIVE_EVENT",
			"ON_SYMBOL_EVENT",
			"ON_CONTENT_UI_EVENT",
			"ON_LONG_POLL_EVENT",
			"ON_SLOT_DETAIL_EVENT",
			"ON_SPINBUTTON_EVENT",
			"ON_CONTENT_UI_DETAIL_EVENT"
		};
		typeDict = new Dictionary<string, string>()
		{				
			{"DEFAULT", "Default"},
			{"ON_WIN_EVENT", "OnWinEvent"},
			{"ON_SLOT_EVENT", "OnSlotEvent"},
			{"ON_SOUND_EVENT", "OnSoundEvent"},
			{"ON_CREDIT_EVENT", "OnCreditEvent"},
			{"ON_META_UI_EVENT", "OnMetaUIEvent"},
			{"ON_SYSTEM_EVENT", "OnSystemEvent"},
			{"ON_CONTENT_EVENT", "OnContentEvent"},
			{"ON_PASSIVE_EVENT", "OnPassiveEvent"},
			{"ON_SYMBOL_EVENT", "OnSymbolEvent"},
			{"ON_CONTENT_UI_EVENT", "OnContentUIEvent"},
			{"ON_LONG_POLL_EVENT", "OnLongPollEvent"},
			{"ON_SLOT_DETAIL_EVENT", "OnSlotDetailEvent"},
			{"ON_SPINBUTTON_EVENT", "OnSpinButtonEvent"},
			{"ON_CONTENT_UI_DETAIL_EVENT", "OnContentUIDetailEvent"}
		};
	}
}

}

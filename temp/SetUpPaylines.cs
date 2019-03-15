using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SlotMaker;

public class SetUpPaylines : MonoBehaviour {

	[ContextMenu("Do")]
	void Setup()
	{
		for (int i = 0; i < transform.childCount; ++i)
		{
			Transform child = transform.GetChild(i);
			Transform anchor = child.GetChild(0);
			Transform slotArea = anchor.GetChild(4);
			Transform slotMachine = slotArea.GetChild(0);

			SlotMachineMovement movement = slotMachine.gameObject.GetComponent<SlotMachineMovement>();
			SlotMachineEventForwarder forwarder = slotMachine.gameObject.GetComponent<SlotMachineEventForwarder>();

			movement.spinTime = 10f;

			movement.onPrepareStoppedReel.RemoveAllListeners();

			// movement.onPrepareStoppedReel.AddListener(new UnityAction<int>(forwarder.OnPrepareStoppedReel));
			// movement.onStoppedSlotMachine.AddListener(new UnityAction(forwarder.OnStoppedSlotMachine));

			// SlotMachineEventForwarder oldForwarder = slotMachine.gameObject.GetComponent<SlotMachineEventForwarder_Line>();
			// DestroyImmediate(oldForwarder);
			// slotMachine.gameObject.AddComponent<SlotMachineEventForwarder>();
		}
		
	}
}

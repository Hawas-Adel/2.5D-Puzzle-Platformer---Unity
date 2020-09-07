using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Trigger), typeof(Collider))]
public class PressurePlateTrigger : MonoBehaviour
{
	private Trigger Trigger;
	private void Awake() => Trigger = GetComponent<Trigger>();
	private void OnTriggerEnter(Collider other)
	{
		if (Trigger.NoOfCollidersOnTrigger == 0)
		{
			Trigger._OnTriggerEnter?.Invoke();
		}
		Trigger.NoOfCollidersOnTrigger = Mathf.Max(0, Trigger.NoOfCollidersOnTrigger + 1);
	}
	private void OnTriggerExit(Collider other)
	{
		Trigger.NoOfCollidersOnTrigger = Mathf.Max(0, Trigger.NoOfCollidersOnTrigger - 1);
		if (Trigger.NoOfCollidersOnTrigger == 0)
		{
			Trigger._OnTriggerExit?.Invoke();
		}
	}
}

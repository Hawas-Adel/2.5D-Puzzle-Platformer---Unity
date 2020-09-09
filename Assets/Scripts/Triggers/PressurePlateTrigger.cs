using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Trigger), typeof(Collider))]
public class PressurePlateTrigger : MonoBehaviour
{
	private Trigger Trigger;
	private int NoOfCollidersOnTrigger = 0;
	private void Awake() => Trigger = GetComponent<Trigger>();
	private void OnTriggerEnter(Collider other)
	{
		if (NoOfCollidersOnTrigger == 0)
		{
			Trigger.OnTriggerON?.Invoke();
		}
		NoOfCollidersOnTrigger = Mathf.Max(0, NoOfCollidersOnTrigger + 1);
	}
	private void OnTriggerExit(Collider other)
	{
		NoOfCollidersOnTrigger = Mathf.Max(0, NoOfCollidersOnTrigger - 1);
		if (NoOfCollidersOnTrigger == 0)
		{
			Trigger.OnTriggerOFF?.Invoke();
		}
	}
}

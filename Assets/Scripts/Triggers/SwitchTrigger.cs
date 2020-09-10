using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Trigger), typeof(Collider))]
[SelectionBase]
public class SwitchTrigger : MonoBehaviour
{
	public bool IsActive = false;

	private Trigger Trigger;
	private void Awake() => Trigger = GetComponent<Trigger>();

	public void OnClick()
	{
		IsActive = !IsActive;
		if (IsActive)
		{
			Trigger.OnTriggerON?.Invoke();
		}
		else
		{
			Trigger.OnTriggerOFF?.Invoke();
		}
	}
}

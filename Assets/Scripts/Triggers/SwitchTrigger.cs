using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Trigger), typeof(Collider))]
[SelectionBase]
public class SwitchTrigger : MonoBehaviour
{
	[SerializeReference] private TransformLerp Lever = default;
	public bool IsActive = false;

	private Trigger Trigger;
	private void Awake() => Trigger = GetComponent<Trigger>();

	private void Start()
	{
		if (IsActive)
		{
			Lever.DoorStateInterpolant = 1;
		}
		else
		{
			Lever.DoorStateInterpolant = 0;
		}
	}

	public void OnClick()
	{
		IsActive = !IsActive;
		if (IsActive)
		{
			Trigger.OnTriggerON?.Invoke();
			StartCoroutine(Lever.SmoothDoorInterpolentChange(1));
		}
		else
		{
			Trigger.OnTriggerOFF?.Invoke();
			StartCoroutine(Lever.SmoothDoorInterpolentChange(0));
		}
	}

	private void Reset() => Lever = GetComponentInChildren<TransformLerp>();
}

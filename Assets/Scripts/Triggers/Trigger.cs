using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Trigger : MonoBehaviour
{
	public UnityEvent OnTriggerON;
	public UnityEvent OnTriggerOFF;

	private void Reset() => gameObject.layer = 9;

	public void DebugTrigger(bool IsEnter)
	{
		if (IsEnter)
		{
			Debug.Log($"{name} -> ON");
		}
		else
		{
			Debug.Log($"{name} -> OFF");
		}
	}
}

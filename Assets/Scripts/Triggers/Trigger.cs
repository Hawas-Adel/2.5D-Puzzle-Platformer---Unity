using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Trigger : MonoBehaviour
{
	public UnityEvent _OnTriggerEnter;
	public UnityEvent _OnTriggerExit;

	[System.NonSerialized] public int NoOfCollidersOnTrigger = 0;

	private void Reset() => gameObject.layer = 9;

	public void DebugCollision(bool IsEnter)
	{
		if (IsEnter)
		{
			Debug.Log($"{name} Entered");
		}
		else
		{
			Debug.Log($"{name} Exited");
		}
	}
}

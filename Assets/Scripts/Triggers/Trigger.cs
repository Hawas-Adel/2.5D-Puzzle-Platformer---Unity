using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
	public UnityEvent _OnTriggerEnter;
	public UnityEvent _OnTriggerExit;

	private int NoOfCollidersOnTrigger = 0;

	private void Reset() => gameObject.layer = 9;

	private void OnTriggerEnter(Collider other)
	{
		if (NoOfCollidersOnTrigger == 0)
		{
			_OnTriggerEnter?.Invoke();
		}
		NoOfCollidersOnTrigger = Mathf.Max(0, NoOfCollidersOnTrigger + 1);
	}
	private void OnTriggerExit(Collider other)
	{
		NoOfCollidersOnTrigger = Mathf.Max(0, NoOfCollidersOnTrigger - 1);
		if (NoOfCollidersOnTrigger == 0)
		{
			_OnTriggerExit?.Invoke();
		}
	}

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

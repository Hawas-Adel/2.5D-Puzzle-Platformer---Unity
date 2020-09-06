using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LocksManager))]
public abstract class AbstractLock : MonoBehaviour
{
	public LockState LockState = LockState.Locked;
	private void OnEnable() => GetComponent<LocksManager>().Locks.Add(this);
	private void OnDisable() => GetComponent<LocksManager>().Locks.Remove(this);
}

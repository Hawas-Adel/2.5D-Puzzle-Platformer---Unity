using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class LocksManager : MonoBehaviour
{
	[System.NonSerialized] public List<AbstractLock> Locks = new List<AbstractLock>();

	public LockState LockState
	{
		get
		{
			var LockStates = Locks.GroupBy(L => L.LockState);
			if (LockStates.Count() == 0)
			{
				Debug.LogWarning("LockManager can't find any locks attached");
				return LockState.UnLocked;
			}
			else if (LockStates.Count() == 1)
				return LockStates.ElementAt(0).Key;
			else
				return LockState.Locked;
		}
	}
}
public enum LockState { Locked, UnLocked }

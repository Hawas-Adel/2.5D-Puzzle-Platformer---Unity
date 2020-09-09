using UnityEngine;

[RequireComponent(typeof(LocksManager))]
public class LockByTrigger : AbstractLock
{
	[SerializeReference] private Trigger Trigger = default;
	private void Start()
	{
		Trigger.OnTriggerON.AddListener(() => LockState = LockState.UnLocked);
		Trigger.OnTriggerOFF.AddListener(() => LockState = LockState.Locked);
	}
}

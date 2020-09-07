using UnityEngine;

[RequireComponent(typeof(LocksManager))]
public class LockByTrigger : AbstractLock
{
	[SerializeReference] private Trigger Trigger = default;
	private void Start()
	{
		Trigger._OnTriggerEnter.AddListener(() => LockState = LockState.UnLocked);
		Trigger._OnTriggerExit.AddListener(() => LockState = LockState.Locked);
	}
}

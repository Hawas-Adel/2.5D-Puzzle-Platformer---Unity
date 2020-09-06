using OneLine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LockByInventoryItem : AbstractLock
{
	[SerializeField] [OneLine] private InventoryItemSlot RequiredItem = default;
	[SerializeField] private Vector3 HalfExtents = 0.5f * Vector3.one;

	private void LateUpdate()
	{
		var InventoryInRange = Physics.OverlapBox(transform.position, HalfExtents, transform.rotation)
			.ToList().Find(Coll => Coll.GetComponent<Inventory>() != null)?.GetComponent<Inventory>();
		var IIS = InventoryInRange?.Items.Find(_IIS => _IIS.Item == RequiredItem.Item && _IIS.Count >= RequiredItem.Count);
		if (IIS != null)
		{
			LockState = LockState.UnLocked;
			IIS.Count -= RequiredItem.Count;
			InventoryInRange.CleanInventory();
			enabled = false;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, HalfExtents * 2);
	}
}

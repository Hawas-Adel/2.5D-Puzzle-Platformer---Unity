using OneLine;
using UnityEngine;

[RequireComponent(typeof(LockByInventoryItemAreaDetection))]
public class LockByInventoryItem : AbstractLock
{
	[SerializeField] [OneLine] private InventoryItemSlot RequiredItem = default;

	private LockByInventoryItemAreaDetection AreaDetection;
	private void Start() => AreaDetection = GetComponent<LockByInventoryItemAreaDetection>();

	private void LateUpdate()
	{
		var IIS = AreaDetection.InventoryInRange?.Items.Find(_IIS => _IIS.Item == RequiredItem.Item && _IIS.Count >= RequiredItem.Count);
		if (IIS != null)
		{
			LockState = LockState.UnLocked;
			IIS.Count -= RequiredItem.Count;
			AreaDetection.InventoryInRange.CleanInventory();
			enabled = false;
		}
	}
}

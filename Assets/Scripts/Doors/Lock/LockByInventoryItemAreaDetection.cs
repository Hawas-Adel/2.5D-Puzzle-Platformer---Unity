using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LocksManager))]
public class LockByInventoryItemAreaDetection : MonoBehaviour
{
	public Vector3 HalfExtents = Vector3.one;

	public Inventory InventoryInRange { get; private set; }

	private void Update() => InventoryInRange = Physics.OverlapBox(transform.position, HalfExtents, transform.rotation)
			.ToList().Find(Coll => Coll.GetComponent<Inventory>() != null)?.GetComponent<Inventory>();

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, HalfExtents * 2);
	}
}

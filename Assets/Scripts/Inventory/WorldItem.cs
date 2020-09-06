using Candlelight;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[DisallowMultipleComponent]
[SelectionBase]
public class WorldItem : MonoBehaviour
{
	[SerializeReference] [PropertyBackingField] [DisableIf("IsPlaying")] private InventoryItem _Item;
	private bool IsPlaying() => Application.isPlaying;

	public InventoryItem Item
	{
		get => _Item;
		private set
		{
			if (!Application.isPlaying)
			{
				_Item = value;
				foreach (Transform child in transform)
				{ DestroyImmediate(child.gameObject); }

				if (_Item != null)
				{
#if UNITY_EDITOR
					PrefabUtility.InstantiatePrefab(_Item.WorldModel, transform);
#endif
					name = $"[Item] : {Item.name}";
				}
				else
				{
					name = "[Item]";
				}

			}
			else
			{ Debug.LogError("Don't change Item during runtime"); }
		}
	}

	private void Reset()
	{
		Rigidbody RB = GetComponent<Rigidbody>();
		if (RB == null)
		{
			RB = gameObject.AddComponent<Rigidbody>();
		}
		RB.constraints = RigidbodyConstraints.FreezePositionZ
									   | RigidbodyConstraints.FreezeRotationX
									   | RigidbodyConstraints.FreezeRotationY;
	}
}

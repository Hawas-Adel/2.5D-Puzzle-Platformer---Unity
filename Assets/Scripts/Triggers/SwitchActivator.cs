using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAfter(typeof(MouseHoverMonitor))]
public class SwitchActivator : MonoBehaviour
{
	[SerializeField] [Min(0)] private float SwitchInteractionRange = 1.5f;

	private void OnEnable() => MouseHoverMonitor.Inst.OnMouseClickGameObject.AddListener(OnClick);
	private void OnDisable() => MouseHoverMonitor.Inst?.OnMouseClickGameObject.RemoveListener(OnClick);

	private void OnClick(GameObject GO)
	{
		if (Vector3.Distance(GO.transform.position, transform.position) <= SwitchInteractionRange
			&& GO.TryGetComponent(out SwitchTrigger SwTrgr))
		{
			SwTrgr.OnClick();
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan * 0.5f;
		Gizmos.DrawWireSphere(transform.position, SwitchInteractionRange);
	}
}

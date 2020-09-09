using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAfter(typeof(MouseHoverMonitor))]
public class SwitchActivator : MonoBehaviour
{
	private void OnEnable() => MouseHoverMonitor.Inst.OnMouseClickGameObject.AddListener(OnClick);
	private void OnDisable() => MouseHoverMonitor.Inst?.OnMouseClickGameObject.RemoveListener(OnClick);

	private void OnClick(GameObject GO)
	{
		if (GO.TryGetComponent(out SwitchTrigger SwTrg))
		{
			SwTrg.OnClick();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseHoverMonitor : MonoBehaviour
{
	private GameObject _GameObject;
	public GameObject GameObject
	{
		get => _GameObject;
		private set
		{
			if (_GameObject != value)
			{
				_GameObject = value;
				OnMouseHoverChange?.Invoke(_GameObject);
			}

		}
	}
	public UnityEvent<GameObject> OnMouseHoverChange;

	private Camera Cam;
	private InputActionsMap IAM;

	#region Singlton
	public static MouseHoverMonitor Inst { get; private set; }
	private void OnEnable()
	{
		if (Inst == null)
			Inst = this;
		else
		{
			Destroy(this);
			return;
		}
		IAM.Enable();
	}
	private void OnDisable()
	{
		if (Inst == this)
			Inst = null;
		IAM.Disable();
	}
	#endregion

	private void Awake()
	{
		IAM = new InputActionsMap();
		Cam = Camera.main;
	}

	private void LateUpdate()
	{
		Ray Ray = Cam.ScreenPointToRay(IAM.Pointer.Position.ReadValue<Vector2>());
		if (Physics.Raycast(Ray, out RaycastHit Hit, 20))
		{
			GameObject = Hit.collider.gameObject;
		}
		else
		{
			GameObject = null;
		}
	}

	public void DebugGO(GameObject GO) => Debug.Log(GO?.name);
}

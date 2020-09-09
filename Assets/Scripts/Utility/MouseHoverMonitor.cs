using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
	public UnityEvent<GameObject> OnMouseClickGameObject;

	private Camera Cam;

	#region Singlton
	public static MouseHoverMonitor Inst { get; private set; }
	private void OnEnable()
	{
		if (Inst == null)
			Inst = this;
		else
			Destroy(this);
	}
	private void OnDisable()
	{
		if (Inst == this)
			Inst = null;
	}
	#endregion

	private void Awake() => Cam = Camera.main;

	public void OnPosition(InputAction.CallbackContext CTX)
	{
		if (CTX.performed)
		{
			Ray Ray = Cam.ScreenPointToRay(CTX.ReadValue<Vector2>());
			if (Physics.Raycast(Ray, out RaycastHit Hit, 20))
			{
				GameObject = Hit.collider.gameObject;
			}
			else
			{
				GameObject = null;
			}
		}
	}

	public void OnClick(InputAction.CallbackContext CTX)
	{
		if (CTX.performed && GameObject != null)
		{
			OnMouseClickGameObject.Invoke(GameObject);
		}
	}

	public void DebugGO(GameObject GO) => Debug.Log(GO?.name);
}

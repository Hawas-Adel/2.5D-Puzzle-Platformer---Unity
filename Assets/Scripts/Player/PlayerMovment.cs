using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovment : MonoBehaviour
{
	[SerializeField] private Rigidbody RB = default;
	[SerializeField] private Transform LevelLayout = default;
	[Min(0)] public float MovmentSpeed = 5;
	[Min(0)] public Vector3 JumpVelocity = new Vector3(0, 5, 0);

	private float MovmentInput = 0;

	private void Reset() => RB = GetComponent<Rigidbody>();

	public void OnMovment(InputAction.CallbackContext CTX) => MovmentInput = CTX.ReadValue<float>();
	public void OnJump(InputAction.CallbackContext CTX)
	{
		if (CTX.performed)
		{
			RB.AddForce(JumpVelocity, ForceMode.Impulse);
		}
	}
	private void FixedUpdate()
	{
		RB.MovePosition(RB.transform.position + (LevelLayout.right * MovmentInput * MovmentSpeed * Time.fixedDeltaTime));
		if (MovmentInput != 0)
		{
			RB.transform.forward = LevelLayout.right * MovmentInput;
		}
	}
}

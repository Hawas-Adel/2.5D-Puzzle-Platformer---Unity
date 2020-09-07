using Candlelight;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLerp : MonoBehaviour
{
	[SerializeField] private TransformState StartTransform = default;
	[SerializeField] private TransformState EndTransform = default;

	[SerializeField] [PropertyBackingField(typeof(RangeAttribute), 0f, 1f)] private float _DoorStateInterpolant = 0;
	public float DoorStateInterpolant
	{
		get => _DoorStateInterpolant;
		set
		{
			_DoorStateInterpolant = Mathf.Clamp01(value);
			TransformState.Lerp(StartTransform, EndTransform, _DoorStateInterpolant).ToTransform(transform);
		}
	}

	[Button]
	private void SetStartTransform() => StartTransform.FromTransform(transform);
	[Button]
	private void SetEndTransform() => EndTransform.FromTransform(transform);
}

[System.Serializable]
public class TransformState
{
	public Vector3 Position;
	public Vector3 Rotation;
	public Vector3 Scale;

	public void FromTransform(Transform transform)
	{
		Position = transform.localPosition;
		Rotation = transform.rotation.eulerAngles;
		Scale = transform.localScale;
	}
	public void ToTransform(Transform transform)
	{
		transform.localPosition = Position;
		transform.rotation = Quaternion.Euler(Rotation);
		transform.localScale = Scale;
	}

	public static TransformState Lerp(TransformState A, TransformState B, float T) => new TransformState
	{
		Position = Vector3.Lerp(A.Position, B.Position, T),
		Rotation = Vector3.Lerp(A.Rotation, B.Rotation, T),
		Scale = Vector3.Lerp(A.Scale, B.Scale, T)
	};
}

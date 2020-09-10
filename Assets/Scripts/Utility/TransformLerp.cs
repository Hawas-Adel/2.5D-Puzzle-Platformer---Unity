using Candlelight;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLerp : MonoBehaviour
{
	[SerializeField] private TransformState StartTransform = default;
	[SerializeField] private TransformState EndTransform = default;

	[SerializeField] [PropertyBackingField(typeof(RangeAttribute), 0f, 1f)] private float _StateInterpolant = 0;
	public float StateInterpolant
	{
		get => _StateInterpolant;
		set
		{
			_StateInterpolant = Mathf.Clamp01(value);
			TransformState.Lerp(StartTransform, EndTransform, _StateInterpolant).ToTransform(transform);
		}
	}

	[SerializeField] private bool ResetOnStart = true;
	[SerializeField] [Min(0)] private float SlideSpeed = 1;

	private void Start()
	{
		if (ResetOnStart)
		{
			StateInterpolant = 0;
		}
	}

	private IEnumerator SmoothInterpolentChange(float TargetValue)
	{
		float InitialValue = StateInterpolant;
		for (float t = 0 ; t < 1 ; t += SlideSpeed * Time.deltaTime)
		{
			StateInterpolant = Mathf.Lerp(InitialValue, TargetValue, t);
			yield return null;
		}
		StateInterpolant = TargetValue;
		yield return null;
	}
	public void SlideToStartTransform() => StartCoroutine(SmoothInterpolentChange(0));
	public void SlideToEndTransform() => StartCoroutine(SmoothInterpolentChange(1));


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

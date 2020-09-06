using Candlelight;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] [BoxGroup("States")] private TransformState DoorClosedTransform = default;
	[SerializeField] [BoxGroup("States")] private TransformState DoorOpenedTransform = default;

	[SerializeField] [BoxGroup("Current State")] [PropertyBackingField] private DoorState _DoorState = DoorState.Closed;
	public DoorState DoorState
	{
		get => _DoorState; set
		{
			_DoorState = value;
			switch (value)
			{
				case DoorState.Closed:
					if (Application.isPlaying)
						StartCoroutine(SmoothDoorInterpolentChange(0, AnimationSpeed));
					else
						DoorStateInterpolant = 0;
					break;
				case DoorState.Open:
					if (Application.isPlaying)
						StartCoroutine(SmoothDoorInterpolentChange(1, AnimationSpeed));
					else
						DoorStateInterpolant = 1;
					break;
			}
		}
	}

	[SerializeField] [BoxGroup("Current State")] [PropertyBackingField(typeof(RangeAttribute), 0f, 1f)] private float _DoorStateInterpolant = 0;
	private float DoorStateInterpolant
	{
		//get => _DoorStateInterpolant;
		set
		{
			_DoorStateInterpolant = Mathf.Clamp01(value);
			TransformState.Lerp(DoorClosedTransform, DoorOpenedTransform, _DoorStateInterpolant).ToTransform(transform);
		}
	}

	[SerializeField] [Min(0)] [BoxGroup("Current State")] [Label("Open/Close Speed")] private float AnimationSpeed = 1;

	[Button]
	private void SetClosedTransform()
	{
		DoorClosedTransform.FromTransform(transform);
		_DoorState = DoorState.Closed;
	}
	[Button]
	private void SetOpenedTransform()
	{
		DoorOpenedTransform.FromTransform(transform);
		_DoorState = DoorState.Open;
	}

	private IEnumerator SmoothDoorInterpolentChange(float TargetValue, float Speed = 1)
	{
		float InitialValue = _DoorStateInterpolant;
		for (float t = 0 ; t < 1 ; t += Speed * Time.deltaTime)
		{
			DoorStateInterpolant = Mathf.Lerp(InitialValue, TargetValue, t);
			yield return null;
		}
		DoorStateInterpolant = Mathf.Lerp(InitialValue, TargetValue, 1);
		yield return null;
	}

	private LocksManager LocksManager;
	private void Start() => LocksManager = GetComponent<LocksManager>();

	private void LateUpdate()
	{
		if (LocksManager != null)
		{
			if (LocksManager.LockState == LockState.Locked && DoorState == DoorState.Open)
			{
				DoorState = DoorState.Closed;
			}
			else if (LocksManager.LockState == LockState.UnLocked && DoorState == DoorState.Closed)
			{
				DoorState = DoorState.Open;
			}
		}
	}
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

public enum DoorState { Closed, Open }

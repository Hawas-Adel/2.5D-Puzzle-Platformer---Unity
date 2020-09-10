using Candlelight;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private TransformLerp TransformLerp = default;
	[SerializeField] [PropertyBackingField] private DoorState _DoorState = DoorState.Closed;
	public DoorState DoorState
	{
		get => _DoorState;
		set
		{
			_DoorState = value;
			switch (value)
			{
				case DoorState.Closed:
					if (Application.isPlaying)
						TransformLerp.SlideToStartTransform();
					else
						TransformLerp.StateInterpolant = 0;
					break;
				case DoorState.Open:
					if (Application.isPlaying)
						TransformLerp.SlideToEndTransform();
					else
						TransformLerp.StateInterpolant = 1;
					break;
			}
		}
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

	private void Reset() => TransformLerp = GetComponent<TransformLerp>();
}

public enum DoorState { Closed, Open }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatesJauntyTools;

public class CameraController : Script, Subscriber
{
	[SerializeField] new Camera camera;

	[SerializeField] float moveDuration = 1f;
	[UnityEngine.Serialization.FormerlySerializedAs("movementCurve")][SerializeField] AnimationCurve moveCurve;
	Coroutine moveRoutine = null;
	public bool IsMoving => moveRoutine != null;


	public void Subscribe() => AreaManager.OnGoToArea += OnGoToArea;
	public void Unsubscribe() => AreaManager.OnGoToArea -= OnGoToArea;


	void OnGoToArea(Area area)
	{
		moveRoutine = StartCoroutine(MoveRoutine());


		IEnumerator MoveRoutine()
		{
			Vector3 startPosition = transform.position;

			for (float timer = 0f; timer <= moveDuration; timer += Time.deltaTime)
			{
				transform.position = Vector3.LerpUnclamped(startPosition, area.Position, moveCurve.Evaluate(timer / moveDuration));
				yield return null;
			}

			transform.position = area.Position;
		}
	}
}

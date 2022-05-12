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
			float endTime = Time.time + moveDuration;
			float timer = 0;

			while (Time.time < endTime)
			{
				timer += Time.deltaTime;
				transform.position = Vector3.LerpUnclamped(startPosition, area.Position, moveCurve.Evaluate(timer / moveDuration));
				yield return new WaitForEndOfFrame();
			}

			transform.position = area.Position;
		}
	}
}

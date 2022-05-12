using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatesJauntyTools;

public class CameraController : Script, Subscriber
{
	[SerializeField] new Camera camera;


	public void Subscribe() => AreaManager.OnGoToArea += OnGoToArea;
	public void Unsubscribe() => AreaManager.OnGoToArea -= OnGoToArea;


	void OnGoToArea(Area area)
	{
		Debug.Log($"Going to {area.name}");
	}
}

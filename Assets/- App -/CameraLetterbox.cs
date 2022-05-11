using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraLetterbox : MonoBehaviour
{
	new Camera camera;
	[SerializeField] Vector2 aspectRatio = new Vector2(16f, 9f);
	float AspectRatio => aspectRatio.x / aspectRatio.y;


	void Update()
	{
		camera ??= GetComponent<Camera>();

		if (camera == null)
		{
			Debug.LogWarning($"CameraLetterBox: No camera found on \"{name}\"");
			return;
		}

		// determine the game window's current aspect ratio
		float windowAspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float scaleHeight = windowAspect / AspectRatio;

		Rect rect = camera.rect;
		if (scaleHeight < 1.0f) // add horizontal bars
		{
			rect.width = 1.0f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;

			camera.rect = rect;
		}
		else // add vertical bars
		{
			float scalewidth = 1.0f / scaleHeight;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

		}
		camera.rect = rect;
	}
}

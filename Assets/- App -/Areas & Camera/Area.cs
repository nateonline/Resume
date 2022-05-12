using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatesJauntyTools;

public class Area : Script
{
	[ReadOnly] public AreaManager manager;

	public Vector3 Position => transform.position;


	[InspectorButton]
	public void GoHere() => manager?.GoTo(this);
}

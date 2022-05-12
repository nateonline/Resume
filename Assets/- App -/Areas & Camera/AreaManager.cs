using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NatesJauntyTools;

public class AreaManager : Script
{
	public static event Action<Area> OnGoToArea;


	List<Area> areas = new List<Area>();
	[SerializeField, ReadOnly] Area currentArea;


	void Awake()
	{
		InitializeAreas();
	}

	void InitializeAreas()
	{
		foreach (Area area in GetComponentsInChildren<Area>())
		{
			area.manager = this;
			areas.Add(area);
		}
		GoTo(areas[0]);
	}

	public void GoTo(Area newArea)
	{
		if (!areas.Contains(newArea)) areas.Add(newArea);
		currentArea = newArea;
		OnGoToArea?.Invoke(newArea);
	}
}

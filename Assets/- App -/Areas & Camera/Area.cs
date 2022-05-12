using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatesJauntyTools;

public class Area : Script
{
	[ReadOnly] public AreaManager manager;

	[Header("Nav Buttons")]
	[SerializeField] NavButton northButton;
	[SerializeField] NavButton eastButton;
	[SerializeField] NavButton southButton;
	[SerializeField] NavButton westButton;

	[Header("Nav Areas")]
	[SerializeField] Area northArea;
	[SerializeField] Area eastArea;
	[SerializeField] Area southArea;
	[SerializeField] Area westArea;

	public Vector3 Position => transform.position;


	void Awake()
	{
		SetupNav(northButton, northArea);
		SetupNav(eastButton, eastArea);
		SetupNav(southButton, southArea);
		SetupNav(westButton, westArea);


		void SetupNav(NavButton navButton, Area area)
		{
			if (area != null)
			{
				navButton.OnClick.AddListener(() => manager?.GoTo(area));
				navButton.Text = area.name;
			}
			else if (navButton != null)
			{
				navButton.SetActive(false);
			}
		}
	}


	[InspectorButton]
	public void GoHere() => manager?.GoTo(this);

	// public void GoNorth() => manager?.GoTo(northArea);
	// public void GoEast() => manager?.GoTo(eastArea);
	// public void GoSouth() => manager?.GoTo(southArea);
	// public void GoWest() => manager?.GoTo(westArea);
}

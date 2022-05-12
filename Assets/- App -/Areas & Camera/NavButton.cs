using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NavButton : MonoBehaviour
{
	[SerializeField] TMP_Text label;
	[SerializeField] Button button;


	public void SetActive(bool value) => gameObject.SetActive(value);

	public string Text
	{
		get => label.text;
		set => label.text = value;
	}

	public Button.ButtonClickedEvent OnClick => button.onClick;
}

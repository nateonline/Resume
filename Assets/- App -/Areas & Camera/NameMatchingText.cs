using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NatesJauntyTools;

[ExecuteAlways]
public class NameMatchingText : Script
{
	[SerializeField] GameObject target;
	string textAtLoad;


#if UNITY_EDITOR
	[Tooltip("(Editor ONLY) If true, the label will always match the name of the GameObject")]
	[SerializeField] bool alwaysMatchNameInEditor;

	void Awake()
	{
		if (alwaysMatchNameInEditor) { Text = target.name; }
		textAtLoad = Text;
	}

	void Update()
	{
		if (alwaysMatchNameInEditor && !Application.isPlaying && Text != target.name) Text = target.name;
	}
#endif


	[SerializeField] TMP_Text label;

	public string Text
	{
		get => label.text;
		set => label.text = value;
	}

	public void RevertText() => Text = textAtLoad;
}

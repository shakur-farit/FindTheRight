using System;
using StaticEvents;
using TMPro;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
	public TextMeshProUGUI _text;

	private void Awake()
	{
		StaticEventsHandler.OnDebug += DebugGame;
	}

	private void DebugGame(string text) => 
		_text.text = text;
}

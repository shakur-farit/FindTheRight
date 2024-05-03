using StaticEvents;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DebugingScript : MonoBehaviour
{
	public TextMeshProUGUI StateText;
	public TextMeshProUGUI UIRootIdText;

	private void Awake()
	{
		StaticEventsHandler.OnDebug += DebugStates;
		StaticEventsHandler.OnDebugUI += DebugUI;
	}

	private void DebugUI(string obj) => 
		UIRootIdText.text = obj;

	private void DebugStates(string textIn) => 
		StateText.text = textIn;
}

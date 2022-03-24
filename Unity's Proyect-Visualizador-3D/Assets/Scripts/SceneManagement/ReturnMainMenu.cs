using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMainMenu : MonoBehaviour
{
    [SerializeField] private LoadEventChannelSO onReturnButtonPress;
	[SerializeField] private GameSceneSO[] locationsToLoad;
	[SerializeField] private bool showLoadScreen;

	public void OnReturnButtonPress()
	{
		onReturnButtonPress.RaiseEvent(locationsToLoad, showLoadScreen);
	}
}

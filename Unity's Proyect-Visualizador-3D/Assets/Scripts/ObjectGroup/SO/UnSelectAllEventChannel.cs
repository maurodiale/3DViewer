using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/UnSelectAll Event")]
public class UnSelectAllEventChannel : ScriptableObject
{
    public UnityAction OnUnGroupAllRequested;

    public void RaiseEvent()
	{
		if (OnUnGroupAllRequested != null)
		{
			OnUnGroupAllRequested.Invoke();
		}
		else
		{
			Debug.LogWarning("An UnGroupAll signal has been triggered, but nobody picked it up.");
		}
	}
}

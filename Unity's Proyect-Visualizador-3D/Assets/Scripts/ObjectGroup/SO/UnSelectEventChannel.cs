using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Events/UnSelect Event")]
public class UnSelectEventChannel : ScriptableObject
{
    public UnityAction<GameObject> OnUnGroupRequested;

    public void RaiseEvent(GameObject obj)
	{
		
		if (OnUnGroupRequested != null)
		{
			OnUnGroupRequested.Invoke(obj);
		}
		else
		{
			Debug.LogWarning("An UnGroup signal has been triggered, but nobody picked it up.");
		}
		
		//OnUnGroupRequested?.Invoke(obj);
	}
}

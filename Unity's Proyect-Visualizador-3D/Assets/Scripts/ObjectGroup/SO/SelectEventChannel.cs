// Allows to connect gameObject geom with a Group Object

using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Select Event")]
public class SelectEventChannel : ScriptableObject
{
    public UnityAction<GameObject, Transform> OnGroupRequested;
	public void RaiseEvent(GameObject targetObject, Transform groupObject)
	{
		if (OnGroupRequested != null)
		{
			OnGroupRequested.Invoke(targetObject, groupObject);
		}
		else
		{
			Debug.LogWarning("A Group Obj is asking to join, but nobody picked it up.");
		}
	}
}

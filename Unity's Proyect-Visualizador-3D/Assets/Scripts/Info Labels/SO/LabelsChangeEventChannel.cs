using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Change Label Event")]
public class LabelsChangeEventChannel : ScriptableObject
{
    public UnityAction<string, string> OnChangeLabels;

    public void RaiseEvent(string name, string description)
    {
        if(OnChangeLabels != null)
            OnChangeLabels.Invoke(name, description);
        else
            Debug.Log("A change in labels is requested, but nobody picked it up.");
    }
}

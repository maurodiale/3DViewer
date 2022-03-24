using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Reset Event")]
public class ResetTransformEventChannel : ScriptableObject
{
    public UnityAction OnResetTransformRequested;

    public void RaiseEvent()
    {
        OnResetTransformRequested?.Invoke();
    }
}

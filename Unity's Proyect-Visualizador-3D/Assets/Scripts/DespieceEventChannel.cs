using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Despiece Event")]
public class DespieceEventChannel : ScriptableObject
{
    public UnityAction<float, float> OnDespieceRequested;

    public void RaiseEvent(float FactorDespiece, float timeToDespiece)
    {
        OnDespieceRequested?.Invoke(FactorDespiece, timeToDespiece);
    }
}
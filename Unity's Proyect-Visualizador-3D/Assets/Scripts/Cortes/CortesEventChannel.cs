using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Cortes Event")]
public class CortesEventChannel : ScriptableObject
{
    public UnityAction OnCortesStartRequested;

    public UnityAction OnCortesCancelRequested;

    public UnityAction OnCortesXYRequested;

    public UnityAction OnCortesXZRequested;

    public UnityAction OnCortesYZRequested;

    public void RaiseStartEvent()
    {
        OnCortesStartRequested?.Invoke();
    }

    public void RaiseCancelEvent()
    {
        OnCortesCancelRequested?.Invoke();
    }

    public void RaiseCorteXYEvent()
    {
        OnCortesXYRequested?.Invoke();
    }

    public void RaiseCorteXZEvent()
    {
        OnCortesXZRequested?.Invoke();
    }

    public void RaiseCorteYZEvent()
    {
        OnCortesYZRequested?.Invoke();
    }
}

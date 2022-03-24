using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AnimationEventChannel", menuName = "Events/Animation Event")]
public class AnimationEventChannel : ScriptableObject
{
    public UnityAction OnAnimationStartRequested;
    public UnityAction OnAnimationCancelRequested;
    public UnityAction OnAnimationPauseRequested;

    public void RaiseStartEvent()
    {
        OnAnimationStartRequested?.Invoke();
    }

    public void RaiseCancelEvent()
    {
        OnAnimationCancelRequested?.Invoke();
    }

    public void RaisePauseEvent()
    {
        OnAnimationPauseRequested?.Invoke();
    }
}

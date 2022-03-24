// https://forum.unity.com/threads/start-animation-on-mouse-click.442023/

using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private AnimationEventChannel AnimationRequest;
    
    private List<GameObject> objects;

    private Animator animator;

    private bool _isPause = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        AnimationRequest.OnAnimationStartRequested += StartAnimation;
        AnimationRequest.OnAnimationCancelRequested += CancelAnimation;
        AnimationRequest.OnAnimationPauseRequested += PauseAnimation;
    }

    private void Start()
    {
        objects = DataManager.GetObjects();
    }

    private void OnDisable()
    {
        AnimationRequest.OnAnimationStartRequested -= StartAnimation;
        AnimationRequest.OnAnimationCancelRequested -= CancelAnimation;
        AnimationRequest.OnAnimationPauseRequested -= PauseAnimation;
    }

    private void StartAnimation()
    {
        foreach (GameObject obj in objects)
        {
            obj.transform.SetParent(transform, true); // el true es para que el obj mantenga su posicion original
        }
        animator.Rebind();
        animator.SetTrigger("Active");
        _isPause = false;
    }

    private void CancelAnimation()
    {
        animator.SetTrigger("Active");
        foreach (GameObject obj in objects)
        {
            obj.transform.parent = null;
        }
        animator.Rebind();
        _isPause = true;

        animator.enabled = true; // si salimos con enabled=false, despues no vuelve a arrancar la anim
    }

    private void PauseAnimation()
    {
        // se puede pausar con speed = 0, pero me gusta más el comportamiento de enable
        if(_isPause)
        {
            animator.enabled = true;
            //animator.speed = 1;
            _isPause = false;
        }
        else
        {
            animator.enabled = false;
            //animator.speed = 0;
            _isPause = true;
        }
    }
}

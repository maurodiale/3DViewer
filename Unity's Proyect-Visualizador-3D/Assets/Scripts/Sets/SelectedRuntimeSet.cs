using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Sets/Selected Set")]
public class SelectedRuntimeSet : RuntimeSetSO<GameObject>
{
    // Pensaba mandar un evento cuando la lista se empezara a llenar para activar
    // el menu de grupos. Pero creo que es más sencillo hacer un update en
    // GUIcontroller viendo que la lista no sea nula. Cual es mejor?

    public enum Implementation // We define what should be doing with the selection
    {
        none,
        hide,
        rotate,
        translate,
    }

    public Implementation State; // deberiamos agregar setter y getter

    public UnityAction StartGroupMenuRequested;
    public UnityAction CancelGroupMenuRequested;
    public UnityAction<Implementation> StateChangeRequest;

    private void OnEnable()
    {
        Clear();
        State = Implementation.none;
    }

    public void MenuGroupsDisplayFlexEvent() => StartGroupMenuRequested?.Invoke();

    public void MenuGroupsDisplayNoneEvent() => CancelGroupMenuRequested?.Invoke();

    public void StateChangeEvent(Implementation state)
    {
        State = state;
        StateChangeRequest?.Invoke(state);
    }

    public void Clear()
    {
        if(Items.Count != 0)
            Items.Clear();
    }

    public Vector3 MiddlePoint()
    {
        if(Items.Count == 0)
            return Vector3.zero;
        
        Vector3 suma = new Vector3(0,0,0);
        int count = 0;
        foreach (var obj in Items)
        {
            if(obj.activeSelf)
            {
                suma += obj.transform.position;
                count++;
            }
        }
        return suma/count;
    }
}
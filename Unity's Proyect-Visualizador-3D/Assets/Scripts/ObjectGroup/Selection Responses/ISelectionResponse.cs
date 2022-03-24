using UnityEngine;

public interface ISelectionResponse
{
    void OnSelect(Selectable obj, Transform parent);
    void OnDeselect(Selectable obj);
}
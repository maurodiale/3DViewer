using UnityEngine;

public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    // Podriamos poner materiales de los assets
    //[SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material DefaultMaterial;

    public void OnSelect(Selectable obj, Transform parent)
    {
        obj.gameObject.transform.SetParent(parent);
        obj.meshRenderer.material.color = Color.green;
        obj._isGrouped = true;
    }

    public void OnDeselect(Selectable obj)
    {
        obj.gameObject.transform.SetParent(null);
        obj.meshRenderer.material.color = Color.white;
        obj._isGrouped = false;
    }
}

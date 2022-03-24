using UnityEngine;

public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private float OutlineWidth = 5;
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void OnSelect(Selectable obj, Transform parent)
    {
        obj.gameObject.transform.SetParent(parent);
        obj._isGrouped = true;

        if(outline != null) outline.OutlineWidth = OutlineWidth;
    }

    public void OnDeselect(Selectable obj)
    {
        obj.gameObject.transform.SetParent(null);
        obj._isGrouped = false;

        if(outline != null) outline.OutlineWidth = 0;
    }

    public void SetOutlineWidth(float num)
    {
        OutlineWidth = num;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool starDragging;

    // Update is called once per frame
    void Update()
    {
        if(starDragging){
            Debug.Log("Entro!");
            transform.position = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        starDragging = true;
        Debug.Log("OnPointerDown");
    }
    public void Test(){
        Debug.Log("OnPointerDown");
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        starDragging = false;
        Debug.Log("OnPointerUp");
    }
}

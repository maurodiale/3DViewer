using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Counter : MonoBehaviour
{
    private Label counterLabel;
    private Button counterButton;
    private VisualElement visualElement;
    private double count = 0;
    //private float displ;
    private void OnEnable()
    {
        //https://www.raywenderlich.com/6452218-uielements-tutorial-for-unity-getting-started
        //https://gamedev-resources.com/create-a-health-bar-that-hovers-over-the-player-with-ui-toolkit/
        //https://forum.unity.com/threads/uielements-runtime-popup-example.827565/
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        counterLabel = rootVisualElement.Q<Label>("counter-label");
        counterButton = rootVisualElement.Q<Button>("counter-button");
        //visualElement = rootVisualElement.Q<VisualElement>("visualElement-label");
        //visualElement.style.position = new StyleEnum<Position>(Position.Relative);

        //displ = float.Parse(visualElement.style.top.ToString());

        counterButton.RegisterCallback<ClickEvent>((e) => IncrementCounter(e));
        // MouseDownEvent: right & middle click button
        // ClickEvent: left click button
    }

    private void IncrementCounter(ClickEvent e)
    {
        
        //var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        //Debug.Log("style: "+rootVisualElement.style.height);
        //rootVisualElement.position += Vector3.up;
        //Debug.Log(rootVisualElement.position.heigh);
        //VisualElement label = new Label("Hello World! From C#");
        //rootVisualElement.Add(label);
        //visualElement.style.position = new StyleEnum<Position>(Position.Relative);
        //displ+=5f;
        //visualElement.style.top = new StyleLength(new Length(displ, LengthUnit.Percent));
        // https://forum.unity.com/threads/width-of-label.732476/
        //IResolvedStyle style = visualElement.resolvedStyle;
        //Debug.Log("IResolvedStyle :"+style.left);
        //rootVisualElement.style.display = DisplayStyle.None; None; // to hide it
            //DisplayStyle.Flex; // to show it
        Debug.Log($"Detecta: {e.clickCount}"); //Detecta uno pero lo llama dos veces
        //count +=.5 ; //hack to solve twice button clicked
        count ++;
        counterLabel.text = $"Count: {count}";
    }
}

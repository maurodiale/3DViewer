using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIController : MonoBehaviour
{
    // UMXL file
    [SerializeField] private VisualTreeAsset sourceAsset = default;

    //Fields to change scene
    [SerializeField] private LoadEventChannelSO onPlayButtonPress;
	[SerializeField] private GameSceneSO[] locationsToLoadInCorazon;
    [SerializeField] private GameSceneSO[] locationsToLoadInPrueba;
    [SerializeField] private GameSceneSO[] locationsToLoadInCasoDeEstudio;
	[SerializeField] private GameSceneSO[] locationsToLoadInCorazonAnimated;
    [SerializeField] private GameSceneSO[] locationsToLoadInV8Engine;
    [SerializeField] private GameSceneSO[] locationsToLoadInFusionReactor;
    [SerializeField] private GameSceneSO[] locationsToLoadInRadialEngine;
    [SerializeField] private GameSceneSO[] locationsToLoadInAirplaneEngine;
	[SerializeField] private bool showLoadScreen;

    //Fields to exit application
    [SerializeField] private VoidEventChannelSO onExitButtonPress;

    private UIDocument uiDocument;
    
    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        uiDocument.visualTreeAsset = sourceAsset;
    }

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        Button ButtonEstudio = root.Q<Button>("Button-estudio");
        Button ButtonCorazon = root.Q<Button>("Button-corazon");
        Button ButtonPrueba = root.Q<Button>("Button-prueba");
        Button ButtonCorazonAnimated = root.Q<Button>("Button-coranim");
        Button ButtonRadialEngine = root.Q<Button>("Button-radialengine");
        Button ButtonFusionReactor = root.Q<Button>("Button-fusionreactor");
        Button ButtonV8Engine = root.Q<Button>("Button-V8engine");
        Button ButtonAirplaneEngine = root.Q<Button>("Button-airplane");
        Button ButtonExit = root.Q<Button>("Button-exit");

        ButtonCorazon.RegisterCallback<ClickEvent>((e) => OnCorazonButtonPress());
        ButtonPrueba.RegisterCallback<ClickEvent>((e) => OnPruebaButtonPress());
        ButtonEstudio.RegisterCallback<ClickEvent>((e) => OnCasoEstudioButtonPress());
        ButtonRadialEngine.RegisterCallback<ClickEvent>((e) => OnRadialEngineButtonPress());
        ButtonFusionReactor.RegisterCallback<ClickEvent>((e) => OnFusionReactorButtonPress());
        ButtonV8Engine.RegisterCallback<ClickEvent>((e) => OnV8EngineButtonPress());
        ButtonAirplaneEngine.RegisterCallback<ClickEvent>((e) => OnAirplaneEngineButtonPress());
        ButtonCorazonAnimated.RegisterCallback<ClickEvent>((e) => OnCorazonAnimatedButtonPress());
        ButtonExit.RegisterCallback<ClickEvent>((e) => OnExitButtonPress());
    }

    public void OnCorazonButtonPress()
	{
		onPlayButtonPress.RaiseEvent(locationsToLoadInCorazon, showLoadScreen);
	}

    public void OnCorazonAnimatedButtonPress()
	{
		onPlayButtonPress.RaiseEvent(locationsToLoadInCorazonAnimated, showLoadScreen);
	}

    public void OnPruebaButtonPress()
	{
		onPlayButtonPress.RaiseEvent(locationsToLoadInPrueba, showLoadScreen);
	}

    public void OnCasoEstudioButtonPress()
    {
        onPlayButtonPress.RaiseEvent(locationsToLoadInCasoDeEstudio, showLoadScreen);
    }

    public void OnRadialEngineButtonPress()
    {
        onPlayButtonPress.RaiseEvent(locationsToLoadInRadialEngine, showLoadScreen);
    }

    public void OnV8EngineButtonPress()
    {
        onPlayButtonPress.RaiseEvent(locationsToLoadInV8Engine, showLoadScreen);
    }

    public void OnFusionReactorButtonPress()
    {
        onPlayButtonPress.RaiseEvent(locationsToLoadInFusionReactor, showLoadScreen);
    }

    public void OnAirplaneEngineButtonPress()
    {
        onPlayButtonPress.RaiseEvent(locationsToLoadInAirplaneEngine, showLoadScreen);
    }

    public void OnExitButtonPress()
    {
        onExitButtonPress.RaiseEvent();
    }
}

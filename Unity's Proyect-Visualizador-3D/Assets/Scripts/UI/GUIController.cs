// Tener en cuenta en que orden esta la jerarquía del archivo UXMl
// Puede hacer que botones no funcionen, OJO!

// IDEA: podriamos hacer un enum con estados (labels, cortes, animación, etc)
//  como "maquina de estados".
// formas de ocultar UI:
// https://forum.unity.com/threads/testing-performance-between-ui-toolkit-and-ugui.1060793/

using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GUIController : MonoBehaviour
{
    [SerializeField] private Texture2D play;

    [SerializeField] private Texture2D pause;

    //if we have mouse over UI this is true. We use this to cancel input in other sripts
    public static bool overUI = false; // podriamos poner setter y getter. Solo queremos quese modifique en este script y el resto lo lea
    
    // List of Selected objects
    [SerializeField] private SelectedRuntimeSet Set; // for activating Groups Menu

    // Events
    [SerializeField] private UnSelectAllEventChannel OnUnSelectAllRequest; // to unselect all when button cancel groups is pressed
    
    [SerializeField] private LabelsChangeEventChannel OnLabelsChangeRequest;

    [SerializeField] private CortesEventChannel OnCortesRequest;

    [SerializeField] private AnimationEventChannel OnAnimationRequest;

    // UMXL file
    [SerializeField] private VisualTreeAsset sourceAsset = default;

    // Fields to return to mainmenu scene
    [SerializeField] private LoadEventChannelSO onReturnButtonPress;
	[SerializeField] private GameSceneSO[] locationsToLoad;
	[SerializeField] private bool showLoadScreen;

    private UIDocument uiDocument;

    // Visual elements' screens of each menu.
    private VisualElement LabelsScreen;
    private VisualElement CortesScreen;
    private VisualElement GroupsScreen;
    private VisualElement AnimationScreen;

    // Fields for Labels
    private Label LabelLabelsTitle;
    private ScrollView ScrollViewLabels;
    private Label LabelDescription;
    public static bool isLabels = false;

    // Fields for Cortes
    public static bool isCortes = false;

    // Fields for Reset
    [SerializeField] private GroupImplementations GroupImplementations;

    // Animacion
    public static bool isAnimacion = false;
    private Button ButtonPauseAnimation; //para cambiar el label

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        uiDocument.visualTreeAsset = sourceAsset;
    }
    
    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;
        // For overUI
        VisualElement BackgroundGroups = root.Q<VisualElement>("Background-Groups");
        VisualElement BackgroundCortes = root.Q<VisualElement>("Background-Cortes");
        VisualElement BackgroundGeneral = root.Q<VisualElement>("Background-General");
        VisualElement BackgroundLabels = root.Q<VisualElement>("Label-list-container");
        VisualElement BackgroundAnimation = root.Q<VisualElement>("Background-Animation");
        // Menu's Screens
        LabelsScreen = root.Q<VisualElement>("Screen-Labels");
        CortesScreen = root.Q<VisualElement>("Screen-Cortes");
        GroupsScreen = root.Q<VisualElement>("Screen-Groups");
        AnimationScreen = root.Q<VisualElement>("Screen-Animation");
        // General Menu Buttons
        Button ButtonLabels = root.Q<Button>("Button-Labels");
        Button ButtonCortes = root.Q<Button>("Button-Cortes");
        Button ButtonAnimacion = root.Q<Button>("Button-Animacion");
        Button ButtonDespiece = root.Q<Button>("Button-Despiece");
        // Cortes menu buttons - totalmente aleatiorio los nombres y el plano de corte
        Button ButtonCancelCortes = root.Q<Button>("Cancel-Cortes");
        Button ButtonCortesXY = root.Q<Button>("Sagital");
        Button ButtonCortesXZ = root.Q<Button>("Coronal");
        Button ButtonCortesYZ = root.Q<Button>("Axial");
        // Groups menu buttons
        Button ButtonCancelGroups = root.Q<Button>("Button-Cancel-Groups");
        Button ButtonHideGroups = root.Q<Button>("Button-ocultar");
        Button ButtonTranslateGroups = root.Q<Button>("Button-trasladar");
        Button ButtonRotateGroups = root.Q<Button>("Button-rotar");
        // Labels menu buttons
        Button ButtonCancelLabels = root.Q<Button>("Button-Cancel-Labels");
        LabelLabelsTitle = root.Q<Label>("Label-title");
        ScrollViewLabels = root.Q<ScrollView>("List-etiquetas");
        // Reset button
        Button ButtonReset = root.Q<Button>("Button-Reset");
        // Animation
        Button ButtonCancelAnimation = root.Q<Button>("Button-Cancel-Animation");
        ButtonPauseAnimation = root.Q<Button>("Button-Pause");
        ButtonPauseAnimation.style.backgroundImage = pause;
        // Return main menu Button
        Button ButtonReturn = root.Q<Button>("Button-Return");

        // Callbacks
        // For overUI
        BackgroundCortes.RegisterCallback<MouseEnterEvent>((e) => overUI = true);
        BackgroundCortes.RegisterCallback<MouseLeaveEvent>((e) => overUI = false);
        BackgroundGroups.RegisterCallback<MouseEnterEvent>((e) => overUI = true);
        BackgroundGroups.RegisterCallback<MouseLeaveEvent>((e) => overUI = false);
        BackgroundGeneral.RegisterCallback<MouseEnterEvent>((e) => overUI = true);
        BackgroundGeneral.RegisterCallback<MouseLeaveEvent>((e) => overUI = false);
        BackgroundLabels.RegisterCallback<MouseEnterEvent>((e) => overUI = true);
        BackgroundLabels.RegisterCallback<MouseLeaveEvent>((e) => overUI = false);
        BackgroundAnimation.RegisterCallback<MouseEnterEvent>((e) => overUI = true);
        BackgroundAnimation.RegisterCallback<MouseLeaveEvent>((e) => overUI = false);
        // Labels
        ButtonLabels.RegisterCallback<ClickEvent>((e) => OnButtonLabels());
        ButtonCancelLabels.RegisterCallback<ClickEvent>((e) => OnCancelLabels());
        // Cortes
        ButtonCortes.RegisterCallback<ClickEvent>((e) => OnButtonCortes());
        ButtonCancelCortes.RegisterCallback<ClickEvent>((e) => OnCancelCortes());
        ButtonCortesXY.RegisterCallback<ClickEvent>((e) => {OnCortesRequest.RaiseCorteXYEvent();});
        ButtonCortesXZ.RegisterCallback<ClickEvent>((e) => {OnCortesRequest.RaiseCorteXZEvent();});
        ButtonCortesYZ.RegisterCallback<ClickEvent>((e) => {OnCortesRequest.RaiseCorteYZEvent();});
        // Groups
        ButtonTranslateGroups.RegisterCallback<ClickEvent>((e) => OnTranslateGroups());
        ButtonRotateGroups.RegisterCallback<ClickEvent>((e) => OnRotateGroups());
        ButtonHideGroups.RegisterCallback<ClickEvent>((e) => OnHideGroups());
        ButtonCancelGroups.RegisterCallback<ClickEvent>((e) => OnCancelGroups());
        // Animacion
        ButtonAnimacion.RegisterCallback<ClickEvent>((e) => OnAnimacion());
        ButtonCancelAnimation.RegisterCallback<ClickEvent>((e) => OnCancelAnimation());
        ButtonPauseAnimation.RegisterCallback<ClickEvent>((e) => OnPauseAnimation());
        // Despiece
        ButtonDespiece.RegisterCallback<ClickEvent>((e) => OnDespiece());
        // Reset
        ButtonReset.RegisterCallback<ClickEvent>((e) => OnReset());
        // Return
        ButtonReturn.RegisterCallback<ClickEvent>((e) => OnReturn());

        // Events
        Set.StartGroupMenuRequested += OnGroupDisplayFlex;
        Set.CancelGroupMenuRequested += OnGroupDisplayNone;
        OnLabelsChangeRequest.OnChangeLabels += PlaceInLabes;
    }

    private void OnDisable()
    {
        Set.StartGroupMenuRequested -= OnGroupDisplayFlex;
        Set.CancelGroupMenuRequested -= OnGroupDisplayNone;
        OnLabelsChangeRequest.OnChangeLabels -= PlaceInLabes;
    }

    // Callbacks

    // Labels
    private void OnButtonLabels()
    {
        OnCancelCortes();
        //https://forum.unity.com/threads/how-do-you-use-the-scrollview-from-the-ui-toolkit.890548/
        if(ScrollViewLabels.childCount > 0) return; //Si ya esta iniciado no hacemos nada
        OnCancelGroups();
        isLabels = true;
        LabelsScreen.style.display = DisplayStyle.Flex;
        LabelLabelsTitle.text = "";
        ScrollViewLabels.Add(InitScrollView()); // Lo agrega como child
    }

    private VisualElement InitScrollView()
    {
        VisualElement visualElement = new VisualElement();
        LabelDescription = new Label();
        LabelDescription.text = "Haga click sobre una geometría para más información";
        // Hacemos el style a mano aca como primera prueba. Deberiamos hacerlo en un 
        // css y en el uxml agregar un Label que despues metemos en este LavelDescription
        // habria que hacer no visible(hidden) y pos abs, desp aca lo cambiamos
        //LabelDescription.style.flexGrow = 1f; // necesario?
        LabelDescription.style.unityTextAlign = TextAnchor.MiddleCenter;
        LabelDescription.style.color = Color.white;
        LabelDescription.style.whiteSpace = WhiteSpace.Normal;
        LabelDescription.style.fontSize = 16;
        visualElement.Add(LabelDescription);
        visualElement.style.marginTop = 30;
        visualElement.style.marginBottom = 30;
        //visualElement.style.paddingBottom = 30;
        //visualElement.style.paddingTop = 30;
        return visualElement;
    }

    private void OnCancelLabels()
    {
        isLabels = false;
        LabelsScreen.style.display = DisplayStyle.None;
        ScrollViewLabels.Clear(); // si salimos de Labels limpiamos
    }

    // Reset
    private void OnReset()
    {
        GroupImplementations.Reset();
        OnCancelGroups();
    }

    // Cortes
    private void OnButtonCortes()
    {
        OnCancelLabels();
        OnReset();
        CortesScreen.style.display = DisplayStyle.Flex;
        OnCortesRequest.RaiseStartEvent();

        isCortes = true;
    }

    private void OnCancelCortes()
    {
        CortesScreen.style.display = DisplayStyle.None;
        OnCortesRequest.RaiseCancelEvent();

        isCortes = false;
    }

    // Groups

    private void OnTranslateGroups()
    {
        if(Set.State != SelectedRuntimeSet.Implementation.translate)
            Set.StateChangeEvent(SelectedRuntimeSet.Implementation.translate);
    }

    private void OnRotateGroups()
    {
        if(Set.State != SelectedRuntimeSet.Implementation.rotate)
            Set.StateChangeEvent(SelectedRuntimeSet.Implementation.rotate);
    }
    private void OnHideGroups()
    {
        Set.StateChangeEvent(SelectedRuntimeSet.Implementation.hide);
    }

    private void OnCancelGroups()
    {
        OnUnSelectAllRequest.RaiseEvent();
        Set.Clear();
        Set.StateChangeEvent(SelectedRuntimeSet.Implementation.none);
        GroupsScreen.style.display = DisplayStyle.None;
    }

    // Animacion

    private void OnAnimacion()
    {
        OnReset();
        AnimationScreen.style.display = DisplayStyle.Flex;
        isAnimacion = true;
        OnAnimationRequest.RaiseStartEvent();
    }

    private void OnPauseAnimation()
    {
        // cambiamos el texto en el boton
        //ButtonPauseAnimation.text = (ButtonPauseAnimation.text == "Pause")? ButtonPauseAnimation.text = "Resume": ButtonPauseAnimation.text = "Pause";
        ButtonPauseAnimation.style.backgroundImage = (ButtonPauseAnimation.style.backgroundImage == pause)? ButtonPauseAnimation.style.backgroundImage = play : ButtonPauseAnimation.style.backgroundImage = pause;

        OnAnimationRequest.RaisePauseEvent();
    }

    private void OnCancelAnimation()
    {
        //ButtonPauseAnimation.text = "Pause";
        ButtonPauseAnimation.style.backgroundImage = pause;
        OnAnimationRequest.RaiseCancelEvent();
        AnimationScreen.style.display = DisplayStyle.None;
        isAnimacion = false;
    }

    // Despiece

    private void OnDespiece()
    {
        if(isCortes || isAnimacion) return;
        OnReset();
        GroupImplementations.Despiece();
    }

    private void OnReturn()
    {
        onReturnButtonPress.RaiseEvent(locationsToLoad, showLoadScreen);
    }

    // Events

    public void OnGroupDisplayFlex()
    {
        GroupsScreen.style.display = DisplayStyle.Flex;
    }

    public void OnGroupDisplayNone()
    {
        GroupsScreen.style.display = DisplayStyle.None;
    }

    public void PlaceInLabes(string name, string description)
    {
        LabelLabelsTitle.text = name;
        LabelDescription.text = description;
    }
}
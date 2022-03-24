// https://learn.unity.com/tutorial/assets-resources-and-assetbundles#
// Basicamente dice que lo mejor es usar addresables, pero que resources para 
// prototipar esta bien.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIControllerv1 : MonoBehaviour
{
    // UMXL file
    [SerializeField] private VisualTreeAsset sourceAsset = default;
    //Fields to change scene
    [SerializeField] private LoadEventChannelSO onPlayButtonPress;
	[SerializeField] private bool showLoadScreen;
    //Fields to exit application
    [SerializeField] private VoidEventChannelSO onExitButtonPress;
    // Icono predeterminado para las especialidades
    [SerializeField] private Sprite m_DefaultItemIcon;
    // Campos que usamos para llenar el mainmenu
    private UIDocument uiDocument;
    private VisualElement m_ItemsTab;
    private VisualElement m_SubItemsTab;

    private ListView m_ItemListView;
    //private ListView m_SubItemListView;
    
    
    private float m_ItemHeight = 100;
    
    private static List<Especialidad> m_ItemDatabase = new List<Especialidad>(); // lista de especialidades
    //private static List<Contenido> m_SubItemDatabase = new List<Contenido>();
    // diccionarios para el manejo de los contenidos, tienen las mismas keys
    private Dictionary<string,List<Contenido>> m_SubItemDatabase = new Dictionary<string,List<Contenido>>(); //la key es el nombre de la especialidad
    private Dictionary<string,ListView> m_SubItemListView = new Dictionary<string,ListView>();
    
    private Dictionary<string,Button> m_ItemButton = new Dictionary<string,Button>();    

    // templates, les saco el static para poder iniciarlas en el inspector y no tener que usar resources
    [SerializeField] private VisualTreeAsset m_ItemRowTemplate; // template del VE que muestra la especialidad
    [SerializeField] private VisualTreeAsset m_SubItemRowTemplate; // template del VE que muestra los contenidos
    // Para marcar la especialidad activa
    private Especialidad m_activeItem;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        uiDocument.visualTreeAsset = sourceAsset;
    }

    private void Start()
    {
        // No creo que sea necesario que los templates se manejen así
        // Directamente los iniciamos en el inspector
        /*
        //Import the ListView Item Template
        //https://stackoverflow.com/questions/55479804/unity-the-name-assetdatabase-does-not-exist-in-the-current-context/55479867
        m_ItemRowTemplate = Resources.Load<VisualTreeAsset>("GUI/UXML/ItemRowTemplate");
        //Import the ListView Item Template
        m_SubItemRowTemplate = Resources.Load<VisualTreeAsset>("GUI/UXML/SubItemRowTemplate");
        */
    }

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;
        
        Button ButtonExit = root.Q<Button>("Salir");
        //Button ButtonCargar = root.Q<Button>("Button-cargar");

        ButtonExit.RegisterCallback<ClickEvent>((e) => OnExitButtonPress());
        //ButtonCargar.RegisterCallback<ClickEvent>((e) => OnCargar());

        // Load items especialidad (carreras)
        LoadAllItems2(); // inicializa la lista de especialidades

        m_ItemsTab = root.Q<VisualElement>("ItemsTab");
        m_SubItemsTab = root.Q<VisualElement>("SubItemsTab");
        
        GenerateItemListView(); // genera la lista de especialidades en pantalla
    }

    private void LoadAllItems2()
    {
        m_ItemDatabase.Clear(); //limpia la lista de especialidades
        m_SubItemDatabase.Clear(); //limpia el diccionario de contenidos
        
        int j=0;
        foreach(Especialidad g in Resources.LoadAll("ScriptableObjects",typeof(Especialidad)))
        {
            m_ItemDatabase.Add(g);

            List<Contenido> contenidos = new List<Contenido>();
            for(int i=0; i<m_ItemDatabase[j].Contenidos.Length; i++){
                
                contenidos.Add(Resources.Load<Contenido>("ScriptableObjects/"+m_ItemDatabase[j].name+"/"+m_ItemDatabase[j].Contenidos[i].name));
            }
            m_SubItemDatabase[m_ItemDatabase[j].Name] = contenidos;
            j++;
        }
    }

    private void LoadAllItems()
    {
        m_ItemDatabase.Clear(); //limpia la lista de especialidades

        #if UNITY_EDITOR_LINUX
            Debug.Log("Directiva Editor");
            string dir = "Assets/Resources/ScriptObjects"; 
            string extension = "*.asset";
            string[] files = Directory.GetFiles(dir,extension,SearchOption.TopDirectoryOnly).Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
        
            //or
            //List<string> files = new List<string>{"Nuclear", "Mecanica", "Medicina"};
            int j=0;
            foreach (string file in files)
            {
                m_ItemDatabase.Add(Resources.Load<Especialidad>("ScriptObjects/"+file));
                
                //Debug.Log(m_ItemDatabase[j].Name);    
                //Debug.Log(m_ItemDatabase[j].Contenidos.Length);    
                List<Contenido> contenidos = new List<Contenido>();
                for(int i=0; i<m_ItemDatabase[j].Contenidos.Length; i++){
                    
                    contenidos.Add(Resources.Load<Contenido>("ScriptObjects/"+m_ItemDatabase[j].Name+"/"+m_ItemDatabase[j].Contenidos[i].Name));
                    //Debug.Log("ScriptObjects/"+m_ItemDatabase[j].Name+"/"+m_ItemDatabase[j].Contenidos[i].Name);
                    //Debug.Log(contenidos[i]);
                    //Debug.Log(m_ItemDatabase[j].Contenidos[i]);
                }
                m_SubItemDatabase[m_ItemDatabase[j].Name] = contenidos;
                j++;
            }
            // Debug
            //foreach(string str in m_SubItemDatabase.Keys) {
                // Get the value for our Key.
                //List<Contenido> value = m_SubItemDatabase[str];
                //Debug.Log(value.Count);
            //}
            
        # elif UNITY_STANDALONE_LINUX
            //Funciona pero es ineficiente cargar todos los recursos (si la db es grande)
            Debug.Log("Directiva standaone LNX");

            foreach(Especialidad g in Resources.LoadAll("ScriptObjects",typeof(Especialidad)))             
            {
                m_ItemDatabase.Add(g);
            }

        # else 
        // To be implemented
        throw new Exception();            
        #endif

        //Debug.Log(m_SubItemDatabase.Count);
    }

    private void GenerateItemListView()
    {
        //Func<VisualElement> makeItem = () => m_ItemRowTemplate.CloneTree(); // la documentación dice que es mejor usar instantiate

        Func<VisualElement> makeItem = () => m_ItemRowTemplate.Instantiate(); // crea un item de especialidad
        
        // e es un VE template de especialidad y lo "inicializa"
        Action<VisualElement, int> bindItem = (e, i) =>
        {   
            string EspecialidadKey = m_ItemDatabase[i].Name;
            e.Q<VisualElement>("Icon").style.backgroundImage = m_ItemDatabase[i].Icon == null ? m_DefaultItemIcon.texture : m_ItemDatabase[i].Icon.texture;
            e.Q<Label>("Especialidad").text = EspecialidadKey;
            e.Q<Button>("BtnEspecialidad").RegisterCallback<ClickEvent>((e) => ItemButtonHandler(EspecialidadKey));
        };

        m_ItemListView = new ListView(m_ItemDatabase, 80, makeItem, bindItem); // porque 80? no deberia ser m_ItemHeight?
        m_ItemListView.selectionType = SelectionType.Single; // selecciona solo de a 1
        m_ItemListView.style.height = m_ItemDatabase.Count * m_ItemHeight;
        m_ItemsTab.Add(m_ItemListView);

        foreach(string especialidad in m_SubItemDatabase.Keys) {
            GenerateSubItemListView(especialidad);
        }            
        
    }

    // Si hacemos clic sobre una especialidad mostramos los contenidos
    void ItemButtonHandler(string key)
    {
        foreach(string especialidad in m_SubItemDatabase.Keys) {
            //Debug.Log("Pressed:"+key+" especialidad: "+especialidad);
            m_SubItemListView[especialidad].style.height = (especialidad != key) ? 0 : m_ItemDatabase.Count * m_ItemHeight;
            m_SubItemListView[especialidad].style.visibility = (especialidad != key) ? Visibility.Hidden : Visibility.Visible;
        }
    }

    private void GenerateSubItemListView(string especialidad)
    {
        //Func<VisualElement> makeItem = () => m_SubItemRowTemplate.CloneTree();
        Func<VisualElement> makeItem = () => m_SubItemRowTemplate.Instantiate();
      
        List<Contenido> ContenidoLista = m_SubItemDatabase[especialidad]; //lista de contenido de la especialidad
        
        Action<VisualElement, int> bindItem = (e, i) =>
        {
            string ModeloKey = ContenidoLista[i].Name;
            e.Q<Label>("Modelo").text = ContenidoLista[i].Name;
            e.Q<Label>("Curso").text = ContenidoLista[i].Curso;
            e.Q<Button>("BtnCurso").RegisterCallback<ClickEvent>((e) => SubItemButtonHandler(especialidad,i));
        };

        m_SubItemListView[especialidad] = new ListView(ContenidoLista, 80, makeItem, bindItem);
        m_SubItemListView[especialidad].selectionType = SelectionType.Single;
        m_SubItemListView[especialidad].style.height = 0;
        m_SubItemListView[especialidad].style.visibility = Visibility.Hidden;
        m_SubItemsTab.Add(m_SubItemListView[especialidad]);
    }

    // Si hacemos clic sobre un contenido, cargamos la escena
    void SubItemButtonHandler(string EspecialidadKey, int ContenidoIdx)
    {
       //Debug.Log("Pressed: "+m_SubItemDatabase[EspecialidadKey][ContenidoIdx].Name);
       // Send SO msj to load the scene
       onPlayButtonPress.RaiseEvent(m_SubItemDatabase[EspecialidadKey][ContenidoIdx].contenido_scene, showLoadScreen);
    }

    public void OnExitButtonPress()
    {
        onExitButtonPress.RaiseEvent();
    }
}


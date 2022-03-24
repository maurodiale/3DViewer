// la idea es hacer un script que si se lo agrego a un model en la escena
// me cree una carpeta con SO de los GO(que tengan meshRenderer) que 
// forman este model. Vamos a ver si sale.
// https://www.youtube.com/watch?v=9bHzTDIJX_Q
// https://answers.unity.com/questions/1424311/loadassetatpath-vs-loadallassetatpath-vs-loadmaina.html
// Este podría servirnos para crear un sistema para cargar geometria en runtime:
// https://forum.unity.com/threads/create-new-scriptable-object-at-runtime.620458/

using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

//[CustomEditor(typeof())]
public class CreateAssetsEditor : MonoBehaviour
{
    private static Transform instance; // transform del modelo

    private static Model model;

    static private float OutlineWidth = 5f;

    static private List<MeshRenderer> lista;

    [MenuItem("CustomEditor/CreateModelAssets")]
    static void CreateGeoAssets()
    {
        model = SceneAsset.FindObjectOfType<Model>();
        instance = model.transform;

        if(instance == null)
        {
            Debug.Log("Agregue el Script Model a alguna geometría de la escena.");
            return;
        }

        //UnityEngine.Windows.Directory.Delete("Assets/ScriptableObjects/DataLabels/" + instance.name); // si ya existe lo borramos y hacemos denuevo
        //FileUtil.DeleteFileOrDirectory("Assets/ScriptableObjects/DataLabels/" + instance.name);
        // https://forum.unity.com/threads/problem-with-fileutil-movefileordirectory-and-material.497247/
        AssetDatabase.DeleteAsset("Assets/ScriptableObjects/DataLabels/" + instance.name);

        AssetDatabase.CreateFolder("Assets/ScriptableObjects/DataLabels", instance.name);
        AssetDatabase.CreateFolder("Assets/ScriptableObjects/DataLabels/" + instance.name, "Prefabs");

        InitList();

        // Si hacemos un solo foreach uniendo estos 2, no anda. Por alguna razón el prefab en el SO queda mal y luego en runtime no crea la instancia.
        // haciendo las 2 por separado como esta ahora si anda
        foreach (var geo in lista)
        {
            CreatePrefab(geo.gameObject);
        }

        AssetDatabase.Refresh(); // creo que si no hago esto, CreateGeoSO no va a encontrar los prefabs que creamos recien

        foreach (var geo in lista)
        {
            CreateGeoSO(geo.gameObject);
        }

        AssetDatabase.Refresh();

        CreateGeoDatabase();

        AssetDatabase.SaveAssets();

        Debug.Log("Se crearon " + lista.Count + " geometrias SO y prefabs.");
    }

    static void InitList()
    {
        lista = instance.GetComponentsInChildren<MeshRenderer>().ToList();
    }

    static private void CreatePrefab(GameObject obj)
    {
        InitGO(obj);

        string prefabPath = "Assets/ScriptableObjects/DataLabels/" + instance.name + "/Prefabs/" + obj.name + ".prefab";

        //AssetDatabase.DeleteAsset(prefabPath); //borramos el prefab si ya existe

        PrefabUtility.SaveAsPrefabAssetAndConnect(obj, prefabPath, InteractionMode.AutomatedAction);
    }

    static private void CreateGeoSO(GameObject obj)
    {
        /*
        InitGO(obj);
        PrefabUtility.SaveAsPrefabAssetAndConnect(obj, "Assets/ScriptableObjects/DataLabels/" + instance.name + "/Prefabs/" + obj.name + ".prefab", InteractionMode.AutomatedAction);
        */
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/ScriptableObjects/DataLabels/" + instance.name + "/Prefabs/" + obj.name + ".prefab");

        string assetPath = "Assets/ScriptableObjects/DataLabels/" + instance.name + "/" + obj.name + ".asset";

        //AssetDatabase.DeleteAsset(assetPath); //borramos el asset si ya existe

        Geometry newGeo = ScriptableObject.CreateInstance<Geometry>();
        newGeo.geoName = obj.name;
        newGeo.geoPosition = obj.transform.position;
        newGeo.geoRotation = obj.transform.rotation;
        newGeo.Model = prefab;
        newGeo.name = obj.name;

        AssetDatabase.CreateAsset(newGeo, assetPath);
    }

    static private void InitGO(GameObject obj)
    {
        // Le agregamos los componentes
        //obj.AddComponent(typeof(MeshCollider));
        obj.AddComponent<MeshCollider>();
        Selectable _selectable = obj.AddComponent<Selectable>();
        _selectable.SetChannels(model.SelectEventChannel, model.UnSelectEventChannel, model.UnSelectAllEventChannel, model.ResetTransformEventChannel, model.DespieceEventChannel);

        OutlineSelectionResponse _selecResponse = obj.AddComponent<OutlineSelectionResponse>();
        _selecResponse.SetOutlineWidth(OutlineWidth);
        
        Outline _outline = obj.GetComponent<Outline>();
        if(_outline == null) // si ya lo tiene no lo agregamos
        {
            _outline = obj.AddComponent<Outline>();
        }
        _outline.OutlineWidth = 0;
        _outline.OutlineColor = Color.green;
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    static private void CreateGeoDatabase()
    {
        GeoDatabase newDatabase = ScriptableObject.CreateInstance<GeoDatabase>();
        newDatabase.name = instance.name+"Database";
        string dataPath = "Assets/ScriptableObjects/DataLabels/" + instance.name + "/" + newDatabase.name + ".asset";

        foreach (var obj in lista)
        {
            string assetPath = "Assets/ScriptableObjects/DataLabels/" + instance.name + "/" + obj.name + ".asset";

            var geo = AssetDatabase.LoadAssetAtPath<Geometry>(assetPath);

            newDatabase.Database.Add(geo);
        }

        AssetDatabase.CreateAsset(newDatabase, "Assets/ScriptableObjects/DataLabels/" + instance.name + "/" + newDatabase.name + ".asset");
    }
}
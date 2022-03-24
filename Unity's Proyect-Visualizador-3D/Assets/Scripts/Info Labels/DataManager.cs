// No se me ocurre de que otra manera se puede hacer que las funciones sean static
// sin usar un singleton. Podriamos hacer que DataSO sea static e iniciarla en
// awake de alguna manera con AssetDatabase.FindeAssets(), pero medio rebuscado

using UnityEngine;
using System.Linq; // Language Integrated Query
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    [Tooltip("Database for this scene. GameObjects must have the same name in the scene and in the database.")]
    [SerializeField] private GeoDatabase DataSO;

    private static DataManager instance; // Singleton

    private List<GameObject> objects = new List<GameObject>(); // Para poder destruir los objetos

    private Vector3 middlePoint = Vector3.zero; // para despieces

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        Spawner(); // Comentar y descomentar
    }

    private void Start()
    {
        SetCenterPoint();
    }

    private void SetCenterPoint()
    {
        foreach(Geometry geo in DataSO.Database) // tambien podria ser con la lista objects
        {
            middlePoint += geo.geoPosition;
        }
        middlePoint = middlePoint/DataSO.Database.Count;
    }

    private void OnDestroy()
    {
        DestroyGeometries();
    }

    private void DestroyGeometries()
    {
        if(objects == null) return;

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        objects.Clear();
    }

    public static Geometry GetGeometryByID(int ID)
    {
        return instance.DataSO.Database.FirstOrDefault(geo => geo.geoID == ID);
    }

    public static Geometry GetGeometryByName(string name)
    {
        //return instance.DataSO.Database.FirstOrDefault(geo => geo.geoName == name);
        return instance.DataSO.Database.FirstOrDefault(geo => geo.name == name);
    }

    public static int Count()
    {
        return instance.DataSO.Database.Count;
    }

    public static void InitializeGeoTransform(Transform transform) // descomentar en selectable.cs si se va a usar
    {
        Geometry geo = GetGeometryByName(transform.name);
        geo.geoPosition = transform.position;
        geo.geoRotation = transform.rotation;
    }

    public static Vector3 GetCenterPoint()
    {
        return instance.middlePoint;
    }

    public static List<GameObject> GetObjects()
    {
        return instance.objects;
    }

    private void Spawner()
    {
        foreach (Geometry geo in DataSO.Database)
        {
            GameObject obj = Instantiate(geo.Model, geo.geoPosition, geo.geoRotation);
            obj.name = geo.name;
            geo.geoID = obj.GetInstanceID(); // el ID cambia cada vez
            objects.Add(obj);
        }
    }

}

using UnityEngine;

[CreateAssetMenu(fileName = "New Geometry", menuName = "Info/Geometry Info")]
public class Geometry : ScriptableObject
{
    public int geoID;
    public GameObject Model; // preFab to instatiate
    public string geoName;
    [TextArea]
    public string geoDescription;
    public Vector3 geoPosition;
    public Quaternion geoRotation;
}

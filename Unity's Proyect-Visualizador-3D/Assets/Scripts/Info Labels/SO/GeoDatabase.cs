using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Geo Database", menuName = "Info/Geo Database")]
public class GeoDatabase : ScriptableObject
{
    public List<Geometry> Database = new List<Geometry>();
}

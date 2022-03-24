using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Field", menuName = "UI Data/Especialidad", order = 1)]
public class Especialidad : ScriptableObject
{
    public string ID = Guid.NewGuid().ToString().ToUpper();
    public string Name = "";

    public Contenido[] Contenidos; // lista de objetos a los cuales cambiamos el material

    public Sprite Icon;
}

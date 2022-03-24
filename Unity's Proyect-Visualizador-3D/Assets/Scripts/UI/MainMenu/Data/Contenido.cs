using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Field", menuName = "UI Data/Contenido", order = 1)]
public class Contenido : ScriptableObject
{
    public string ID = Guid.NewGuid().ToString().ToUpper();
    public string Name;
    public string Curso;

    public string descripcion;
    [SerializeField] public GameSceneSO[] contenido_scene;
}
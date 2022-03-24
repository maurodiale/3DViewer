using UnityEngine;
using UnityEngine.Localization;

/// This class contains Settings specific to Locations only
[CreateAssetMenu(fileName = "NewLocation", menuName = "Scene Data/Location")]
public class LocationSO : GameSceneSO
{
	[Header("Location specific")]
	public LocalizedString locationName;
	public int enemiesCount; //Example variable, will change later
	// Se puede agregar una variable de configuracion (otro SO)
}

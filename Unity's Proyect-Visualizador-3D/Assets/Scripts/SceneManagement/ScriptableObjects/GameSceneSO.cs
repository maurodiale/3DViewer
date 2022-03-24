using UnityEngine;

/// This class is a base class which contains what is common to all game scenes (Locations or Menus)
public class GameSceneSO : ScriptableObject
{
	[Header("Information")]
	public string sceneName;
	public string shortDescription;

	[Header("Sounds")]
	public AudioClip music;

}

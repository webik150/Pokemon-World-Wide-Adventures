using UnityEngine;

/// <summary>
/// Simple script used by Tutorial 11 that sets the color of the sprite based on the string value.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Examples/Set Color on Selection")]
public class ChangeableIcon : MonoBehaviour
{
	UISprite BulbasaurIcon;

	void OnSelectionChange (string val)
	{
		if (BulbasaurIcon == null) BulbasaurIcon = GetComponent<UISprite>();

		switch (val)
		{
			case "Bulbasaur":	BulbasaurIcon.spriteName = "BulbasaurIcon";		break;
			case "Charmander":		BulbasaurIcon.spriteName = "CharmanderIcon";		break;
			case "Squirtle":	BulbasaurIcon.spriteName = "SquirtleIcon";	break;
		}
	}
}


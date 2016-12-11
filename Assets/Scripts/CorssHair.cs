using UnityEngine;
using System.Collections;

public class CorssHair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public float crosshairScale = 1;
    // Use this for initialization
    void Start ()
    {
        GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}

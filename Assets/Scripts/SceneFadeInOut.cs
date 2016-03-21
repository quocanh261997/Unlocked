
using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
	public float fadeSpeed;          // Speed that the screen fades to and from black.
	public GUITexture guiTexture;
	private int targetLevel;
	private static int previousLevel;
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	private bool sceneEnding = false;      // Whether or not the scene is still fading in.

	void Awake ()
	{
		//guiTexture = new GUITexture ();
	
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}

	void Update ()
	{
		if (Application.loadedLevel == 1 && (previousLevel == 3 || previousLevel == 4)) {
			GameObject.Find ("Canvas2").GetComponent<MainMenuSliderController> ().CallRight ();
			previousLevel = 0;
		}
		// If the scene is starting...
		if (sceneStarting)
			// ... call the StartScene function.
			StartScene ();
		if (sceneEnding)
			// ... call the StartScene function.
			EndScene ();

	}
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp (GetComponent<GUITexture> ().color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp (GetComponent<GUITexture> ().color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	void StartScene ()
	{

		// Fade the texture to clear.
		FadeToClear ();
		
		// If the texture is almost clear...
		if (guiTexture.color.a <= 0.2f) {
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	public void LoadScene (int level)
	{
		sceneEnding = true;
		previousLevel = targetLevel;
		targetLevel = level;
	}

	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack ();
		
		// If the screen is almost black...
		if (guiTexture.color.a >= 0.5f) {
			// ... reload the level.
			//guiTexture.color = Color.black;
			sceneEnding = false;
			Application.LoadLevel (targetLevel);
			sceneStarting = true;
		}
	}
}
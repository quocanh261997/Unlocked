using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
public class SplashScreenScrpt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SavenLoad.Load ();
		GameObject.Find ("ButtonSound").GetComponent<AudioSource> ().volume = SavenLoad.setting.volume;
		GameObject.Find ("UnlockSound").GetComponent<AudioSource> ().volume = SavenLoad.setting.volume;
		GameObject.Find ("BgSound").GetComponent<AudioSource> ().volume = SavenLoad.setting.volumeMusic;

		ThemeCollection.getThemes ();
		Invoke("ProcessToMain",0.75f);
	}
	void ProcessToMain(){
		GameObject.Find ("SceneFader").GetComponent<SceneFadeInOut> ().LoadScene (1);
	}
}

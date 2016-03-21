using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingChanged : MonoBehaviour {
	public Slider volumeSlider;
	public Slider volumeMusicSlider;

	public Toggle vibrateToggle;
	AudioSource buttonSound;
	AudioSource unlockSound;
	AudioSource bgSound;

	// Use this for initialization
	void Start () {
		buttonSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
		unlockSound = GameObject.Find("UnlockSound").GetComponent<AudioSource>();
		bgSound = GameObject.Find ("BgSound").GetComponent<AudioSource> ();
		if (buttonSound != null) {
			volumeSlider.value = SavenLoad.setting.volume;
		}
		if (bgSound != null) {
			volumeMusicSlider.value = SavenLoad.setting.volumeMusic;
		}

		vibrateToggle.isOn = SavenLoad.setting.vibrate;
	}
	
	// Update is called once per frame
	public void UpdateVolume () {
		if (buttonSound.GetComponent<AudioSource>() != null) {
			buttonSound.volume = volumeSlider.value;
		}
		if (unlockSound.GetComponent<AudioSource>() != null) {
			unlockSound.volume = volumeSlider.value;
		}
		SavenLoad.setting.volume = volumeSlider.value;
		SavenLoad.Save();

	}
	public void UpdateMusicVolume () {

		if (bgSound.GetComponent<AudioSource>() != null) {
			bgSound.volume = volumeSlider.value;
		}
		SavenLoad.setting.volumeMusic = volumeSlider.value;
		SavenLoad.Save();
		
	}
	public void UpdateVibrate(){
		SavenLoad.setting.vibrate = vibrateToggle.isOn;
		SavenLoad.Save ();
	}
}

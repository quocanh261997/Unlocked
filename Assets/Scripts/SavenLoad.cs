using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
public static class SavenLoad {
	public static int sessionGamePlayed = 0;
	public static Setting setting = new Setting();
	public static void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/setting.dat");
		bf.Serialize (fs, setting);
		fs.Close ();

	}
	public static void Load(){
		try{
		if (File.Exists (Application.persistentDataPath + "/setting.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.OpenRead (Application.persistentDataPath + "/setting.dat");
			SavenLoad.setting = (Setting)bf.Deserialize (fs);
			fs.Close ();
		}
		}catch(System.Exception){}
	}
}
[System.Serializable]
public class Setting{
	public int highscore{ get; set;}
	public float volume{ get; set;}
	public float volumeMusic{ get; set;}
	public bool vibrate{ get; set;}
	public int activedTheme{ get; set;}
	public int point{ get; set;}
	private Mission _mission;
	public int firstTime{ get; set;}
	public Mission Mission{ 
		get{
			if(_mission==null) 
				_mission = new Mission();
			return _mission;
		} 
		set{_mission = value;}
	}
	public Setting(){
		highscore = 0;
		volume = 1;
		volumeMusic = 1;
		vibrate = true;
		activedTheme = 0;	
		point = -1;
		_mission = new Mission ();
		firstTime = 2;
	}
}

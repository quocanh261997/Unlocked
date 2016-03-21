using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadMission : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		if(SavenLoad.setting.Mission.isCompleted()){
			//Call change mission
			Text txtMission = GameObject.Find("txtMission").GetComponent<Text>();
			txtMission.text = ""+ SavenLoad.setting.Mission.completedMission();
			txtMission.color = new Color(59,174,255);
		} else
		{
			GameObject.Find("txtMission").GetComponent<Text>().text = ""+SavenLoad.setting.Mission.getMessage();
		}
		if(SavenLoad.setting.point%9==0){
			LoadThemeList.UnlockTheme(SavenLoad.setting.point/9);
		}
		int missionNo = SavenLoad.setting.point + 1;
		GameObject.Find ("lblMission").GetComponent<Text> ().text = "MISSION " + (missionNo>270?"":(missionNo+""));
		SavenLoad.Save ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

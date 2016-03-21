using UnityEngine;
using System.Collections;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames;
public class MainButtonHandler : MonoBehaviour {
    public Transform messagebox;
	public void ShowLeaderBoard(){
		if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkI2-rT87cREAIQAA");
	}

	public void UpdatePoint(){
		GameObject.Find ("txtPoint").GetComponent<Text> ().text = "COMPLETED MISSIONS: " + SavenLoad.setting.point;

	}

    public void ShowAchievementBoard()
    {
        Social.ShowAchievementsUI();
    }
    public void SkipMission()
    {
        messagebox.GetComponent<MessageBoxController>().InitMessageBox(
            MessageBoxController.MODE_CONF_SKIP_MISSION, "Are you sure?", 
            "Just a click on the ad, and this pain will soon be over~");
                		
    }
    public void Voting()
    {
        Application.OpenURL("market://details?id=com.TrioStudio.Unlocked");
    }
	public void Facebook(){
		Application.OpenURL(@"https://www.facebook.com/tryolab/");
	}
	public void Twitter(){
		Application.OpenURL(@"https://twitter.com/TryoLab");
	}

}

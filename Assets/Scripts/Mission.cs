using UnityEngine;
using System.Collections;
[System.Serializable]
public class Mission
{
	public int currentMission = 0;
	public const int PLAY_X_GAME = 1;
	public const int UNLOCK_X_PATTERNS_IN_1_GAME = 2;
	public const int UNLOCK_X_PATTERNS_TOTAL = 3;
	public const int UNLOCK_X_PATTERNS_IN_UNDER = 4;
	public int x;
	public int current;
	public Mission(){
		x = 0;
		current = 0;
		newMission ();
	}
	// Use this for initialization
	public string getMessage ()
	{
		switch(currentMission){
		case 0:
			return "You've completed all missionsons!";
		case PLAY_X_GAME:
			return "Play "+x+" games ("+(current>x?x:current)+"/"+x+")";
		case UNLOCK_X_PATTERNS_IN_1_GAME:
			return "Unlock "+x+" patterns in 1 game ("+(current>x?x:current)+"/"+x+")";
		case UNLOCK_X_PATTERNS_TOTAL:
			return "Unlock "+x+" patterns total ("+(current>x?x:current)+"/"+x+")";
		case UNLOCK_X_PATTERNS_IN_UNDER:
			return "Unlock "+x+" patterns in under 3 seconds ("+(current>x?x:current)+"/"+x+")";
		default:
			return "";
		}
	}
	public string newMission(){
		if(SavenLoad.setting!=null){
		if(SavenLoad.setting.point==270){
			currentMission = 0;
			return getMessage();
		}
		currentMission = Random.Range (1, 5);
		//int upper = 0;
		//int lower = 1;
		switch (currentMission) {
		case PLAY_X_GAME:
		{
			//lower = 2;
			//upper = 5;
			x = 1+(SavenLoad.setting.point+1)/3;
		}
			break;
		case UNLOCK_X_PATTERNS_IN_1_GAME:
		{
			//lower = 2;
			//upper = 5;
			x = 1+Mathf.RoundToInt((SavenLoad.setting.point+1)*0.22f);
		}	
			break;
		case UNLOCK_X_PATTERNS_TOTAL:
		{
			//lower = 2;
			//upper = 5;
			x = 4+Mathf.RoundToInt((SavenLoad.setting.point+1)*1);
		}
			break;
		case UNLOCK_X_PATTERNS_IN_UNDER:
		{
			//lower = 2;
			//upper = 5;
			x = 4+Mathf.RoundToInt((SavenLoad.setting.point+1)*0.88f);
		}
			break;
		}
		//x = Random.Range (lower, upper);
		current = 0;
		}
		return getMessage ();
	}
	public bool isCompleted(){return current >= x;}
	public string completedMission ()
	{
		SavenLoad.setting.point += 1;
        if (Social.localUser.authenticated){
            if(SavenLoad.setting.point>=90)
                    Social.ReportProgress("CgkI2-rT87cREAIQAg", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
            if(SavenLoad.setting.point>=180)
                    Social.ReportProgress("CgkI2-rT87cREAIQBA", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
            if(SavenLoad.setting.point>=270)
                    Social.ReportProgress("CgkI2-rT87cREAIQBQ", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
        }

		return newMission ();
	}
}

using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
    public Transform messagebox;
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			switch(Application.loadedLevel){
				case 1:
				//Add confirm quit 
                messagebox.GetComponent<MessageBoxController>().InitMessageBox(MessageBoxController.MODE_CONF_QUIT, "Are you sure?", "You could be a professional lock cracker you know?");
                break;
			case 2:
				GameObject.Find("GameMaster").GetComponent<GM>().Pause();
				break;
			case 3:
			case 4:
			case 5:
				LoadScene(1);
				break;
			default:
				break;
			}
		}
	}
	public void LoadScene(int level){
		if(level == 2 && SavenLoad.setting.firstTime==2 ) 
		{
				SavenLoad.setting.firstTime=1;
				GameObject.Find ("SceneFader").GetComponent<SceneFadeInOut> ().LoadScene (4);
		}else if (level==1&&SavenLoad.setting.firstTime==1)
			{
				SavenLoad.setting.firstTime=0;
				SavenLoad.Save();
				GameObject.Find ("SceneFader").GetComponent<SceneFadeInOut> ().LoadScene (2);
			}
		else
		{
			GameObject.Find ("SceneFader").GetComponent<SceneFadeInOut> ().LoadScene (level);
		}
		//Application.LoadLevel (level);
	}
}

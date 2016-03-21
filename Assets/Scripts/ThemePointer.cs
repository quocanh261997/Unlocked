using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ThemePointer : MonoBehaviour {
	// Use this for initialization
	public static int selectedTheme=0;
	
	public void UpdateSelected(){
		//GameObject.Find ("btnSelectText").GetComponent<Text> ().text = ((RectTransform)transform).anchoredPosition.ToString ();
		Vector2 cur = ((RectTransform)transform).anchoredPosition;
		selectedTheme = Mathf.RoundToInt(-(cur.y + 1 * LoadThemeList.basedistance) / LoadThemeList.basedistance);
		//GameObject.Find ("abcdef").GetComponent<Text> ().text = selectedTheme + "";
		if(selectedTheme<=SavenLoad.setting.point/9){
			GameObject.Find ("SelectedTheme").GetComponent<RectTransform>().anchoredPosition = cur;
			SavenLoad.setting.activedTheme = selectedTheme;
			SavenLoad.Save ();
			GameObject.Find ("Canvas").GetComponent<LoadTheme> ().Start ();
		}
	/*	GameObject.Find ("SelectedTheme").GetComponent<RectTransform>().anchoredPosition = cur;
		SavenLoad.setting.activedTheme = selectedTheme;
		SavenLoad.Save ();
		GameObject.Find ("Canvas").GetComponent<LoadTheme> ().Start ();
	*/
	}
	// Update is called once per frame
	void Update () {
	
	}
}

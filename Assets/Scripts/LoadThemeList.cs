using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadThemeList : MonoBehaviour {
	public RectTransform model;
	public RectTransform selectedSprite;
	//public int selected = 0;
	public static float basedistance = 250;
	int curTheme;
	public Sprite lockedTheme; 
	
	// Use this for initialization
	void Start () {
		curTheme = 0;
		for (int i=0; i<ThemeCollection.getThemes().Count;i++)
		{
			Transform rt = (Transform)Instantiate(model,new Vector3(0,basedistance*i),Quaternion.identity);
			rt.SetParent(transform,false);
			rt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-basedistance*(i+1));
			if(i<=SavenLoad.setting.point/9){
				rt.GetComponent<Image>().sprite = ThemeCollection.getThemes()[i].image;
				rt.GetComponentInChildren<Text>().text = "";
			}else{
				rt.GetComponent<Image>().sprite = lockedTheme;
				rt.GetComponentInChildren<Text>().text = 9*i + " MISSIONS";
			}
		/*	rt.GetComponent<Image>().sprite = ThemeCollection.getThemes()[i].image;
			rt.GetComponentInChildren<Text>().text = "";
			rt.name = "theme_icon"+i;*/
		}
		Transform slt = (Transform)Instantiate(selectedSprite,new Vector3(0,0),Quaternion.identity);
		slt.SetParent(transform,false);
		slt.GetComponent<Image> ().color = new Color (0, 0, 0, 140);
		slt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-basedistance*(SavenLoad.setting.activedTheme+1));
		slt.name = "SelectedTheme";
		((RectTransform)transform).anchoredPosition = new Vector2(0,basedistance*(SavenLoad.setting.activedTheme+0.5f)-((RectTransform)transform).rect.height/2);

		//slt.GetComponent<Image>().sprite = theme.image;

	}
	public static void UnlockTheme(int index){
		GameObject rt = GameObject.Find ("theme_icon" + index);
		if(rt!=null){
			rt.GetComponent<Image>().sprite = ThemeCollection.getThemes()[index].image;
		}
	}
	void Update(){
		if(curTheme!=SavenLoad.setting.activedTheme){
			((RectTransform)transform).anchoredPosition = new Vector2(0,basedistance*(SavenLoad.setting.activedTheme+0.5f)-((RectTransform)transform).rect.height/2);
			curTheme=SavenLoad.setting.activedTheme;
		}
	}
}

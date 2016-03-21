using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class LoadTheme : MonoBehaviour {

	void ChangeColor(GameObject g,Color c){
		Image img = g.GetComponent<Image> ();
		if (img != null) {
			img.color=c;
		} else{
			if(g.GetComponent<SpriteRenderer>()!= null) {
				Color t = new Color(c.r,c.g,c.b,1);
				g.GetComponent<SpriteRenderer>().color = t;
			}
			if(g.GetComponent<Text>()!=null)
				g.GetComponent<Text> ().color = c;
			if(g.GetComponent<LineRenderer>()!=null)
			{
				//Color t = new Color(c.r,c.g,c.b,0.5f);
				g.GetComponent<LineRenderer>().SetColors(c,c);
			}
		}
	}
	// Use this for initialization
	public void Start () {
		List<GameObject> list1 = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Spot"));
		List<GameObject> list2 = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Icon"));
		List<GameObject> list3 = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Highlight"));
		list3.AddRange(GameObject.FindGameObjectsWithTag ("Line"));
		list3.AddRange(GameObject.FindGameObjectsWithTag ("Button"));
		list3.AddRange(GameObject.FindGameObjectsWithTag ("Colored Text"));
		List<GameObject> list4 = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Background"));
		List<GameObject> list5 = new List<GameObject> (GameObject.FindGameObjectsWithTag ("DotBg"));
		list5.AddRange(GameObject.FindGameObjectsWithTag ("IconBg"));
		Theme loaded = ThemeCollection.getThemes()[SavenLoad.setting.activedTheme];
		foreach(GameObject g in list1){
			//
			g.GetComponent<SpriteRenderer>().sprite = loaded.dot;
		}
		foreach(GameObject g in list2){
			ChangeColor(g,loaded.color1);
		}
		foreach(GameObject g in list3){
			ChangeColor(g, loaded.color2);
		}
		foreach(GameObject g in list4){
			ChangeColor(g,loaded.color3);
		}
		foreach(GameObject g in list5){
			ChangeColor(g,loaded.color4);
		}
		GameObject logo = GameObject.Find ("GameLogo");
		if (logo != null)
			logo.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("m"+loaded.imgName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[Serializable]
public class Theme{
	public const int ANIMATION_EXPAND = 1;
	public const int ANIMATION_SPIN = 2;
	public Color color1;
	public Color color2;
	public Color color3;
	public Color color4;
	public Sprite dot;
	public Sprite image;
	public string imgName;
	public int animation = 0;
	public Theme (string color1, string color2, string color3, string color4, string dot, string image,int animation)
	{
		try{
			Color.TryParseHexString(color1,out this.color1);
			Color.TryParseHexString(color2,out this.color2);
			Color.TryParseHexString(color3,out this.color3);
			Color.TryParseHexString(color4,out this.color4);
		}catch(Exception){}
		this.dot = Resources.Load<Sprite>(dot);
		this.image = Resources.Load<Sprite>(image) ;
		this.animation = animation;
		this.imgName = image;
	}
	
}

using UnityEngine;
using System.Collections;

public class SpotCreator : MonoBehaviour {
	public RectTransform spot;
	public RectTransform highlight;
	// Use this for initialization
	void Start(){
		float width = ((RectTransform)transform).rect.width;
		float wideDelta = GetComponent<RectTransform> ().sizeDelta.x;
		float gap = 1*width/3;
        //transform.localScale = new Vector3(height / width, 1, 1);
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (wideDelta, width);
		//float dotSize = spot.rect.height;
		for (int i=0; i<3; i++) {
			for (int j=0; j<3; j++) {
				Vector3 pos = new Vector3(gap*(i-1),gap*(j-1),-80);
					//Camera.main.ViewportToWorldPoint (new Vector3 (0.25f + i * 0.25f, 0.25f + j * 0.25f));
				//pos.z = 1;
				Transform o = (Transform)Instantiate (spot, pos, Quaternion.identity);
				o.name = "" + (3 * i + j+1);
				//o.localScale = new Vector3(height/dotSize/5,height/dotSize/5,1);
				o.SetParent (transform,false);

				Transform h = (Transform)Instantiate (highlight, pos+Vector3.forward, Quaternion.identity);
				h.name = "h" + (3 * i + j+1);
				//o.localScale = new Vector3(height/dotSize/5,height/dotSize/5,1);
				h.SetParent (transform,false);
			}		
		}
	}
	/*void Update () {
		float gap = ((RectTransform)transform).rect.height/3;
		GameObject[] goList = GameObject.FindGameObjectsWithTag ("Spot");
		for (int i=0; i<9; i++) {
			GameObject fixing = goList[i];
			int index = int.Parse(fixing.name);
			Vector3 pos = new Vector3(-gap/2+gap*(index/3),-gap/2+gap*(index%3),1);
				//Camera.main.ViewportToWorldPoint (new Vector3 (0.25f + (index/3) * 0.25f, 0.25f + (index%3) * 0.25f));
			//pos.z = 1;
			fixing.transform.position=pos;
		}
	}*/
}

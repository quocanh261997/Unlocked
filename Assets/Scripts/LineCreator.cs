using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LineCreator : MonoBehaviour {
	public LineRenderer render;
	//GameObject[] gos;
	int count;
	float spotRadius;
	Vector3 previousSpot;
	string currentLine;
	GM gameMaster;
	//public Text tb;

	// Use this for initialization
	void Start () {
		//gos = GameObject.FindGameObjectsWithTag ("Spot");
		currentLine = "";
		render.SetVertexCount (1);
		count = 1;
		//spotRadius = gos [0].transform.;

		gameMaster = GameObject.Find ("GameMaster").GetComponent<GM>();

	}

	public void AddSpot(Vector3 pos){
		count += 1;
		Vector3 temp = previousSpot;
		previousSpot = pos;
		render.SetVertexCount (2*count-1);
		//Vector3 t = pos;//Camera.main.ScreenToWorldPoint (pos);
		pos.z = 0;
		temp.z = 0;
		render.SetPosition (2*count-4, pos);
		render.SetPosition (2*count-3, Vector3.MoveTowards(pos,temp,-0.000001f));

	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)&&!gameMaster.paused){
			Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(v, Vector2.zero);
			if(hit.collider!=null&&hit.transform.position!=previousSpot&&hit.transform.tag=="Spot"){
				hit.transform.gameObject.GetComponent<Animator>().SetInteger("Animation",ThemeCollection.getThemes()[SavenLoad.setting.activedTheme].animation);
						AddSpot(hit.transform.position);
				currentLine += hit.transform.name; 
			}
			v.z=0;
			render.SetPosition(2*count-2,v);
		}else if(Input.GetMouseButtonUp(0)&&currentLine!=""&&!gameMaster.paused){
			//call Game Master here
			gameMaster.checkAns(currentLine);
			//Cancel line
			count = 1;
			currentLine="";
			render.SetVertexCount(1);
			previousSpot = new Vector3(0.1f,0.1f,-1);
		}
		if(currentLine==""){
			foreach(GameObject t in GameObject.FindGameObjectsWithTag("Highlight")) {
				t.GetComponent<SpriteRenderer>().enabled = false;
			}
		}

	}
}

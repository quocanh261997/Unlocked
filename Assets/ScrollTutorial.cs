using UnityEngine;
using System.Collections;

public class ScrollTutorial : MonoBehaviour {
	public float baseDistance = 490;
	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (baseDistance, 0);
	}
	
	// Update is called once per frisame
	public void ScrollTo(int i){
		transform.localPosition = new Vector3 (-(i-1) * baseDistance, 0);
	}
}

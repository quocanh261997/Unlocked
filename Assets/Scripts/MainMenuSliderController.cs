using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MainMenuSliderController : MonoBehaviour {
	public RectTransform pnlLeft;
	public RectTransform pnlRight;
	public GraphicRaycaster canvas;
	public GraphicRaycaster canvas2;
	// Use this for initialization
	public void Start () {
		ResetPanel ();
		//transform.GetComponent<Canvas> ().planeDistance = 150;
	}
	public void ResetPanel(){
		pnlLeft.GetComponent<Animator> ().SetInteger ("Slide", -1);
		pnlRight.GetComponent<Animator> ().SetInteger ("Slide", 1);
		canvas.enabled = true;
		canvas2.enabled = false;
	}
	public void CallLeft(){
		canvas.enabled = false;
		canvas2.enabled = true;
		transform.GetComponent<Canvas> ().planeDistance = 90;
		pnlLeft.GetComponent<Animator> ().SetInteger ("Slide", 0);
	}
	public void CallRight(){
		canvas.enabled = false;
		canvas2.enabled = true;
		transform.GetComponent<Canvas> ().planeDistance = 90;
		pnlRight.GetComponent<Animator> ().SetInteger ("Slide", 0);
	}
}

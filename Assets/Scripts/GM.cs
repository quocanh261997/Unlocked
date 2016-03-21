using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using GooglePlayGames;
using System.Collections.Generic;


public class GM : MonoBehaviour {
	private float timeReducedWhenWrong = 1.0f; 
	int score;
	public bool paused = false;
	bool gameover = false;
	public Text scoreTb;
	public Text txtBest;
	string answer;
	public LineRenderer render;
	public Slider cdTimer;
	private float maxTime; 
	float countdown;
	GameObject pauseScene;
	GameObject gameOverScene;
	bool completedMissionMessage = false;
	Color lineColor;

	int hardness;
	AudioSource unlockSound;
	AudioSource bgMusic;

	// Use this for initialization
	void Start () {
		bgMusic = GameObject.Find ("BgSound").GetComponent<AudioSource> ();
		if (bgMusic != null)
			bgMusic.Play ();
		unlockSound = GameObject.Find ("UnlockSound").GetComponent<AudioSource> ();
		pauseScene = GameObject.Find ("Paused");
		gameOverScene = GameObject.Find ("GameOver");
		score = 0;
		maxTime = 7;
		scoreTb.text = score+"";

		answer = "";
		txtBest.text = SavenLoad.setting.highscore+"";
		if (SavenLoad.setting.Mission.currentMission == Mission.UNLOCK_X_PATTERNS_IN_1_GAME)
			SavenLoad.setting.Mission.current = 0;
		//newGame (2);
		hardness = UnityEngine.Random.Range (2, 5);
		newGame(hardness);
	}
	public void newGame(int vertex){
		lineColor = new Color (1, 1, 1, 0.7f);
		answer = AnswerList.TakeRandom(vertex);
		List<GameObject> spots = new List<GameObject>();
		for(int i = 0;i<vertex;i++){
			spots.Add(GameObject.Find(answer[i]+""));
		}
		//scoreTb.text = ""+spots.Length;
		render.SetVertexCount (2*vertex-1);

		for(int i = 0;i<vertex;i++){
			render.SetPosition(2*i,spots[i].transform.position+Vector3.forward*2);
			if(i+1<vertex)
			{	
				render.SetPosition(2*i+1,
				                   Vector3.MoveTowards(spots[i+1].transform.position+Vector3.forward*2,
				                    spots[i].transform.position+Vector3.forward*2,
				                    0.0001f));
			}
		}
		maxTime = (maxTime<=3f)?3f:(maxTime*0.985f);
		countdown = maxTime;
		timeReducedWhenWrong = maxTime * 0.1f;

		//scoreTb.text = answer;
	}
	string reverse(string source){
		char[] input = source.ToCharArray ();
		Array.Reverse (input);
		return new string (input);
	}
	string FormatAnswer(string source){
		string[] invalidPair = new string[8]{"17","28","39","13","46","79","19","37"};
		string[] validTrio = new string[8]{"147","258","369","123","456","789","159","357"};
		for(int i =0;i<invalidPair.Length;i++){
			source=source.Replace(invalidPair[i],validTrio[i]);
			source=source.Replace(reverse(invalidPair[i]),reverse(validTrio[i]));
		}
		return source;
	}
	public void checkAns (string playerAns){


		bool isCorrect = FormatAnswer(playerAns).Equals(answer)||FormatAnswer(playerAns).Equals(reverse(answer));
		if(isCorrect){
			hardness = UnityEngine.Random.Range(2+(score/10>4?4:score/10),5+(score/3>5?5:score/3));
			newGame(hardness);

			unlockSound.Play();
			switch(SavenLoad.setting.Mission.currentMission){
			case Mission.UNLOCK_X_PATTERNS_TOTAL:
			case Mission.UNLOCK_X_PATTERNS_IN_1_GAME:
				SavenLoad.setting.Mission.current+=1;
				SavenLoad.Save();
				break;
			case Mission.UNLOCK_X_PATTERNS_IN_UNDER:
				if(maxTime-countdown<3) SavenLoad.setting.Mission.current+=1;
				SavenLoad.Save();
				break;
			}
			if(SavenLoad.setting.Mission.isCompleted()&&!completedMissionMessage){
				GameObject.Find("lblFinishedMission").GetComponent<Animator>().SetInteger("Animation",1);
				completedMissionMessage = true;
			}
			score+=1;
			scoreTb.text=score+"";

			/*if (score > SavenLoad.setting.highscore) {
				SavenLoad.setting.highscore = score;
				SavenLoad.Save();
			}*/

		}else {
			countdown = countdown - timeReducedWhenWrong;
			lineColor = new Color (1, 1, 1, 0.7f);
			if(SavenLoad.setting.vibrate)	Handheld.Vibrate();
		}
	}
	public void Pause(){
		paused = true;

        //Display mission
        string additional = "";
        if (SavenLoad.setting.Mission.isCompleted()) additional = "<Completed> ";
        GameObject.Find("txtMissionPaused").GetComponent<Text>().text = additional+SavenLoad.setting.Mission.getMessage();
		int missionNo = SavenLoad.setting.point + 1;
		GameObject.Find ("lblMissionPaused").GetComponent<Text> ().text = "MISSION " + (missionNo>270?"":(missionNo+""));


		pauseScene.GetComponent<GraphicRaycaster> ().enabled = true;
		gameObject.GetComponentInParent<GraphicRaycaster> ().enabled = false;
		pauseScene.GetComponent<Canvas> ().planeDistance = 2;
	}
	public void Unpause(){
		paused = false;
		pauseScene.GetComponent<GraphicRaycaster> ().enabled = false;
		gameObject.GetComponentInParent<GraphicRaycaster> ().enabled = true;
		pauseScene.GetComponent<Canvas> ().planeDistance = 10;
	}
	public void StopMusic(){
		if (bgMusic != null){
			bgMusic.Stop();
		}
	}
	void GameOver(){
		gameover = true;
		StopMusic ();
		SavenLoad.sessionGamePlayed += 1;
		if (SavenLoad.sessionGamePlayed%4==0 && AdMob.interstitial != null && AdMob.interstitial.IsLoaded())
		{
			AdMob.interstitial.Show();
		}
		if (SavenLoad.setting.Mission.currentMission == Mission.PLAY_X_GAME)
			SavenLoad.setting.Mission.current += 1;
		if(SavenLoad.setting.vibrate)	Handheld.Vibrate ();
		Text txtEndScore = GameObject.Find ("txtEndScore").GetComponent<Text> ();
		Text txtEndBest = GameObject.Find ("txtEndBest").GetComponent<Text> ();
		txtEndScore.text = score+"";
		if (score > SavenLoad.setting.highscore) {
			SavenLoad.setting.highscore = score;
			SavenLoad.Save();
		}
		txtEndBest.text = SavenLoad.setting.highscore+"";
		/*if(Int32.Parse(txtBest.text)<score){
			txtEndScore.color = new Color(325,210,255);
		}*/
		if(Social.localUser.authenticated){
            Social.ReportScore(score, "CgkI2-rT87cREAIQAA", (bool success) =>
            {
				// handle success or failure
			});
            PlayGamesPlatform.Instance.IncrementAchievement("CgkI2-rT87cREAIQBg", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkI2-rT87cREAIQBw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkI2-rT87cREAIQCA", 1, (bool success) => { });
		}

		if(SavenLoad.setting.Mission.isCompleted()){
			//Call change mission
			Text txtMission = GameObject.Find("txtMission").GetComponent<Text>();
			txtMission.color = new Color(59,174,255);
			txtMission.text = ""+ SavenLoad.setting.Mission.completedMission();
		} else
		{
			GameObject.Find("txtMission").GetComponent<Text>().text = ""+SavenLoad.setting.Mission.getMessage();
		}
		int missionNo = SavenLoad.setting.point + 1;
		GameObject.Find ("lblMission").GetComponent<Text> ().text = "MISSION " + (missionNo>270?"":(missionNo+""));

		gameOverScene.GetComponent<Canvas> ().planeDistance = 2;
		gameOverScene.GetComponent<GraphicRaycaster> ().enabled = true;
		gameObject.GetComponentInParent<GraphicRaycaster> ().enabled = false;
		gameOverScene.GetComponentInChildren<Animator> ().SetBool ("GameOver", true);
		//GameObject.Find ("GamePlay").SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		if(!paused){
			render.SetColors (lineColor, lineColor);
			lineColor = Color.Lerp (lineColor, Color.clear, (3.5f/hardness)*Time.deltaTime);
			if (lineColor.a < 0.2f)
				lineColor.a = 0;
		}
		if (countdown > 0&&!paused) {
			countdown -= Time.deltaTime;
			cdTimer.value = countdown / maxTime;
		}
		if (countdown <= 0&&!gameover) {
			//countdown = 0;
			GameOver ();
		}
	}
}

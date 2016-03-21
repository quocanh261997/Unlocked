using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
//using GoogleMobileAds.Api;

public class GooglePlayAccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoginPlay();
	}

    public void LoginPlay()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
        });
    }
	public IEnumerator Login(){
		while(!Social.localUser.authenticated){
			
		}
		return null;
	}
	// Update is called once per frame
	void Update () {
		//if (Social.localUser.authenticated)
			//gameObject.SetActive (false);
	}

}

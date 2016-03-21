using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour {
	public static BannerView banner = null;
    public static InterstitialAd interstitial = null;
	public static InterstitialAd adForSkip = null;
	// Use this for initialization
	void Start () {
		RequestBanner ();
        RequestInterstitial();
		RequestInterstitialForSkip ();
	}
	
	// Update is called once per frame
	void Update () {
		//banner.Show ();
	}

	private void RequestBanner()
	{
		string adUnitId = "ca-app-pub-9569136881260451/9847479727";
        if (banner != null) banner.Destroy();
		// Initialize an InterstitialAd.
		banner = new BannerView(adUnitId,AdSize.SmartBanner,AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		banner.LoadAd(request);
        banner.AdLoaded += banner_AdLoaded;

	}

    private void RequestInterstitial()
    {
		string adUnitId = "ca-app-pub-9569136881260451/7232090521";
		if (interstitial != null) interstitial.Destroy();
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
        interstitial.AdClosed += interstitial_AdClosed;
    }
	private void RequestInterstitialForSkip()
	{
		string adUnitId = "ca-app-pub-9569136881260451/7232090521";
		if (adForSkip != null) adForSkip.Destroy();
		// Initialize an InterstitialAd.
		adForSkip = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		adForSkip.LoadAd(request);
		adForSkip.AdLeftApplication += (object sender, System.EventArgs e) => {
			SavenLoad.setting.Mission.completedMission();
			new LoadMission().Start();
		};
		adForSkip.AdClosed += (object sender, System.EventArgs e) => {
			adForSkip.Destroy();
			RequestInterstitialForSkip();
		};
	}
    void interstitial_AdClosed(object sender, System.EventArgs e)
    {
        interstitial.Destroy();
        RequestInterstitial();
    }
    void banner_AdLoaded(object sender, System.EventArgs e)
    {
        banner.Show();
    }

}

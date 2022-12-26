using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;

public class AdmobInterstitial : MonoBehaviour
{
    InterstitialAdGameObject interstitialAd;
    
    void Start()
    {
        //インターステシャル準備
        interstitialAd = MobileAds.Instance
            .GetAd<InterstitialAdGameObject>("Interstitial Ad");

        MobileAds.Initialize((initStatus) =>
        {
            Debug.Log("Initialized MobileAds");
        });
        interstitialAd.LoadAd();
    }

    //広告表示
    public void OnClickShowButton()
    {
        // Display an interstitial ad
        interstitialAd.ShowIfLoaded();

        
    }
}

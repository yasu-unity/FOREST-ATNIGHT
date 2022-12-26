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
        //�C���^�[�X�e�V��������
        interstitialAd = MobileAds.Instance
            .GetAd<InterstitialAdGameObject>("Interstitial Ad");

        MobileAds.Initialize((initStatus) =>
        {
            Debug.Log("Initialized MobileAds");
        });
        interstitialAd.LoadAd();
    }

    //�L���\��
    public void OnClickShowButton()
    {
        // Display an interstitial ad
        interstitialAd.ShowIfLoaded();

        
    }
}

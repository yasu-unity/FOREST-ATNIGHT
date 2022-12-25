using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdsManager : MonoBehaviour
{
/*#if UNITY_IOS
    public const string gameID = "5089716";
    public const string bannarID="Banner_iOS";
#elif UNITY_ANDROID
    public const string gameID = "5089717";
    public const string bannarID = "Banner_Android";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif
    public static UnityAdsManager Instance { get; private set; }
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;

            Advertisement.Initialize(gameID);
        }
    }
    public void ShterowInterstitial()
    {
        if (Advertisement.IsReady(InterstitialID))
        {
            Advertisement.Show(InterStitialID);
        }
       
    }*/
}




/*#if UNITY_IOS
    public const string gameID = "5089716";
    public const string bannarID="Banner_iOS";
#elif UNITY_ANDROID
public const string gameID = "5089717";
public const string bannarID = "Banner_Android";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif


public static UnityAdsManager Instance { get; private set; }
void Start()
{
    if (Instance == null)
    {
        Instance = this;

        Advertisement.Initialize(gameID);
        StartCoroutine(ShowBannerWhenReady());
    }
}
IEnumerator ShowBannerWhenReady()
{
    while (!Advertisement.IsReady(bannarID))
    {
        yield return new WaitForSeconds(0.5f);
    }
    Advertisement.Banner.Show(bannarID);
}*/
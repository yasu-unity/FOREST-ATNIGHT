using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdsBanar : MonoBehaviour
{
#if UNITY_IOS
    public const string gameID = "5089716";
    public const string bannarID="Banner_iOS";
#elif UNITY_ANDROID
    public const string gameID = "5089717";
    public const string bannarID = "Banner_Android";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        StartCoroutine(showBanner());

    }
    IEnumerator showBanner()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.3f); // 0.3秒後に広告表示
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER); //バナーを上部中央にセット
        Advertisement.Banner.Show(bannarID);
    }
}

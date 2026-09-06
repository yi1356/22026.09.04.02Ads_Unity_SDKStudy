using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour,
    IUnityAdsInitializationListener,
    IUnityAdsLoadListener,
    IUnityAdsShowListener
{
    public string myGameIdAndroid = "6185541";
    public string myGameIdIOS = "6185540";

    public string adUnitIdAndroid = "Interstitial_Android";
    public string adUnitIdIOS = "Interstitial_iOS";

    private string myAdUnitId;
    private bool adStarted;
    private readonly bool testMode = true;

    private bool BeginStarted;

    void Start()
    {

    }
    
    public void BtnStart()
    {
#if UNITY_IOS
        Advertisement.Initialize(myGameIdIOS, testMode, this);
        myAdUnitId = adUnitIdIOS;
#else
        Advertisement.Initialize(myGameIdAndroid, testMode, this);
        myAdUnitId = adUnitIdAndroid;
#endif
        BeginStarted = true;
    }

    void Update()
    {
        if (BeginStarted && Advertisement.isInitialized && !adStarted)
        {
            adStarted = true;
            Advertisement.Load(myAdUnitId, this); //传入加载监听 this
        }
    }

    // ========== 初始化回调 ==========
    public void OnInitializationComplete()
    {
        Debug.Log("✅Ads初始化完成");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"❌初始化失败:{error} {message}");
    }

    // ========== 加载广告回调 ==========
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log($"✅广告加载成功 {adUnitId}");
        //加载成功后展示广告，传入show监听
        Advertisement.Show(adUnitId, this);
    }
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"❌广告加载失败 {adUnitId} | {error}:{message}");
    }

    // ========== 展示广告回调 ==========
    public void OnUnityAdsShowStart(string adUnitId) => Debug.Log($"广告开始展示 {adUnitId}");
    public void OnUnityAdsShowClick(string adUnitId) => Debug.Log($"广告被点击 {adUnitId}");
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"广告播放完毕 {adUnitId} state:{showCompletionState}");
    }
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"❌广告展示失败 {adUnitId}|{error}:{message}");
    }
}

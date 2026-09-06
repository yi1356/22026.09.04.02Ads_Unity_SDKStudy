using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay_01 : MonoBehaviour
{
    public string myGameIdAndroid = "6185541";
    public string myGameIdIOS = "6185540";
    public string adUnitIdAndroid = "Interstitial_Android";
    public string adUnitIdIOS = "Interstitial_iOS";
    public string myAdUnitId;
    public bool adStarted;
    private bool testMode = true;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
	        Advertisement.Initialize(myGameIdIOS, testMode);
	        myAdUnitId = adUnitIdIOS;
#else
        Advertisement.Initialize(myGameIdAndroid, testMode);
        myAdUnitId = adUnitIdAndroid;
#endif

    }

    // Update is called once per frame
    void Update()
    {
        if (Advertisement.isInitialized && !adStarted)
        {
            Advertisement.Load(myAdUnitId);
            Advertisement.Show(myAdUnitId);
            adStarted = true;
        }

    }
}

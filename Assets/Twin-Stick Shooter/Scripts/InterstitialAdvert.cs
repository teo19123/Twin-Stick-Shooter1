using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdvert : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField]
    string _androidAdUnitId = "Interstitial_Android";

    [SerializeField]
    string _iosAdUnitId = "Interstitial_iOS";

    public string m_currentAdUnitId = "";
    private void Awake()
    {
#if UNITY_IOS
        m_currentAdUnitId = _iosAdUnitId;
#else
        m_currentAdUnitId = _androidAdUnitId;
#endif
    }

    public void LoadInterstitalAd()
    {
        Advertisement.Load(m_currentAdUnitId, this);
    }

    public void ShowInterstitialAd()
    {
        Advertisement.Show(m_currentAdUnitId, this);
        LoadInterstitalAd();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

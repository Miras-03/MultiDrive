using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private const string Interstitial_Android = nameof(Interstitial_Android);
    private const string Interstitial_iOS = nameof(Interstitial_iOS);

    private string _adUnitId;

    void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? Interstitial_iOS
            : Interstitial_Android;
    }

    public void LoadAd() => Advertisement.Load(_adUnitId, this);

    public void ShowAd() => Advertisement.Show(_adUnitId, this);

    public void OnUnityAdsAdLoaded(string adUnitId) { }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
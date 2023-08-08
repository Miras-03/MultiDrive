using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    private const string androidGameId = "5364967";
    private const string iOSGameId = "5364966";
    private const bool testMode = false;
    private string gameId;

    void Awake() =>  InitializeAds();

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId;
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
            Advertisement.Initialize(gameId, testMode, this);
    }


    public void OnInitializationComplete() { }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }
}
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    private const string _androidGameId = "5364967";
    private const string _iOSGameId = "5364966";
    private bool _testMode = false;
    private string _gameId;

    void Awake() =>  InitializeAds();

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId;
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
            Advertisement.Initialize(_gameId, _testMode, this);
    }


    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}
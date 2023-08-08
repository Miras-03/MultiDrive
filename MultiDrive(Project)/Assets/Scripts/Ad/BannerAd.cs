using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class BannerAd : MonoBehaviour
{
    private BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    private const string Banner_Android = nameof(Banner_Android);
    private const string Banner_iOS = nameof(Banner_iOS);
    private string adUnitId;

    void Start()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        adUnitId = Banner_Android;
#endif

        Advertisement.Banner.SetPosition(_bannerPosition);

        Invoke("LoadBanner", 1f);
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    void OnBannerLoaded() => ShowBannerAd();

    void OnBannerError(string message) { }

    void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(adUnitId, options);
    }

    void HideBannerAd() => Advertisement.Banner.Hide();

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }
}

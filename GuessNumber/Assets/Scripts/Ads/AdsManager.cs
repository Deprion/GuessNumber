using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdsManager s_inst;
    [SerializeField] BannerPosition bannerPos;
    private void Start()
    {
        s_inst = this;
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4515713", true);
        }
        if (CheckForInit()) LoadRewardAd();
    }
    public bool CheckForInit()
    {
        return Advertisement.isInitialized;
    }
    public void LoadVideoAd()
    { 
        Advertisement.Load("Interstitial_Android", this);
    }
    public void LoadRewardAd()
    {
        Advertisement.Load("Rewarded_Android", this);
    }
    public void LoadBannerAd()
    {
        Advertisement.Banner.SetPosition(bannerPos);
        Advertisement.Load("Banner_Android", this);
    }
    public void ShowAd(string id)
    {
        Advertisement.Show(id, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId != "Rewarded_Android")
            ShowAd(placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        switch (placementId)
        {
            case "Rewarded_Android":
                ButtonRewardAd.s_inst.UnlockMenu();
                break;
            case "Interstitial_Android":
                break;
            case "Banner_Android":
                break;
        }
        Debug.Log(error);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log(error);
    }
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch (placementId)
        {
            case "Rewarded_Android":
                if (ButtonRewardAd.s_inst != null)
                {
                    ButtonRewardAd.s_inst.UnlockMenu();
                    LoadRewardAd();
                }
                break;
            case "Interstitial_Android":
                break;
            case "Banner_Android":
                break;
        }
    }
}

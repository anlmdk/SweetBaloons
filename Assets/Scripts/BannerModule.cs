using CrazyGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BannerModule : MonoBehaviour
{
    public CrazyBanner bannerPrefab;

    private void Start()
    {
        CrazySDK.Init(UpdateBannersDisplay);
    }

    public void UpdateBannersDisplay()
    {
        CrazySDK.Banner.RefreshBanners();
    }

    public void AddBanner()
    {
        GameObject showBanner = GameObject.Find("Banners");

        var banner = Instantiate(bannerPrefab, new Vector3(), new Quaternion(), showBanner.transform);
        banner.Size = (CrazyBanner.BannerSize)Random.Range(0, 2);
        banner.Position = new Vector2(0, 0);
    }

    public void DisableLastBanner()
    {
        var banners = FindObjectsOfType<CrazyBanner>();

        foreach (var banner in banners)
        {
            if (!banner.IsVisible()) continue;
            banner.gameObject.SetActive(false);

            return;
        }
    }
}

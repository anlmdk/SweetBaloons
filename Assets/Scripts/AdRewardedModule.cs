using CrazyGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdRewardedModule : MonoBehaviour
{
    [SerializeField] private CrazyAdType adType = CrazyAdType.Rewarded;

    private void Start()
    {
        CrazySDK.Init(() => { });
    }

    void Update()
    {
        Check();   
    }

    public void Check()
    {
        if (adType == CrazyAdType.Rewarded)
        {
            adType = CrazyAdType.Rewarded;
        }
    }

    public void AdModuleRewarded()
    {
        CrazySDK.Ad.RequestAd(adType, () =>
        {
            print("Reklam ba�lad�");
        },
        (error) =>
        {
            print("Reklam hatas�, tekrar g�sterilmeyecek: " + error);
        },
        () =>
        {

        });
    }
}

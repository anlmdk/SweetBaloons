using CrazyGames;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AdInterstitialModule : MonoBehaviour
{
    public static AdInterstitialModule Instance;

    [SerializeField] private CrazyAdType adType = CrazyAdType.Midgame;
    private bool adShown = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        CrazySDK.Init(() => { });
    }

    public void AdModuleInterstitial()
    {
        if (adShown)
        {
            Debug.Log("Reklam zaten gösterildi, tekrar gösterilmeyecek.");
            return;
        }

        CrazySDK.Ad.RequestAd(adType, () =>
        {
            print("Reklam baþladý");
        },
            (error) =>
            {
                print("Reklam hatasý, tekrar gösterilmeyecek: " + error);
            },
            () =>
            {
                StartCoroutine(WaitForGameOverPanel());
                adShown = true;
                print("Reklam Bitti! Oyuncu yeniden doðuyor!");
            });
    }

    public IEnumerator WaitForGameOverPanel()
    {
       yield return new WaitForSeconds(5);
    }
}

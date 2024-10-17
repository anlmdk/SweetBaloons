using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaloonSelector : MonoBehaviour
{
    public static BaloonSelector Instance;

    public GameObject[] Baloons;
    public GameObject[] NoPhysicsBaloons;

    // Baþlangýçta spawn olacak maksimum level
    public int HighestStartingIndex = 3;

    [SerializeField] private Image nextBaloonImage;
    [SerializeField] private Sprite[] baloonSprites;

    public GameObject NextBaloon { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PickNextBaloon();
    }

    public GameObject PickRandomBaloonForThrow()
    {
        int randomIndex = Random.Range(0,HighestStartingIndex + 1);

        if (randomIndex < NoPhysicsBaloons.Length)
        {
            GameObject randomBaloon = NoPhysicsBaloons[randomIndex];
            return randomBaloon;
        }
        return null;
    }

    public void PickNextBaloon()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);

        if (randomIndex < Baloons.Length)
        {
            GameObject nextBaloon = NoPhysicsBaloons[randomIndex];
            NextBaloon = nextBaloon;

            if (randomIndex < baloonSprites.Length)
            {
                nextBaloonImage.sprite = baloonSprites[randomIndex];
            }
        }
    }
}

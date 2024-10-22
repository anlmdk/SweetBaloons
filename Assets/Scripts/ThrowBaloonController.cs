using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowBaloonController : MonoBehaviour
{
    public static ThrowBaloonController Instance;

    public GameObject CurrentBaloon { get; set; }

    [SerializeField] private Transform baloonTransform;
    [SerializeField] private Transform parentAfterThrow;
    [SerializeField] private BaloonSelector baloonSelector;

    private PlayerController playerController;

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    public Bounds Bounds {  get; set; }

    private const float EXTRA_WIDTH = 0.02f;

    public bool canThrow { get; set; } = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        SpawnABaloon(baloonSelector.PickRandomBaloonForThrow());

    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // UI elemanýna týklandý, balon býrakýlmayacak
        }

        if (UserInput.IsThrowPressed && canThrow)
        {
            SpriteIndex index = CurrentBaloon.GetComponent<SpriteIndex>();
            Quaternion rotation = CurrentBaloon.transform.rotation;

            GameObject go = Instantiate(BaloonSelector.Instance.Baloons[index.index], CurrentBaloon.transform.position, rotation);
            go.transform.SetParent(parentAfterThrow);

            Destroy(CurrentBaloon);

            canThrow = false;
        }
    }

    public void SpawnABaloon(GameObject baloon)
    {
        GameObject go = Instantiate(baloon, baloonTransform);

        Debug.Log(go);

        CurrentBaloon = go;

        circleCollider = CurrentBaloon.GetComponent<CircleCollider2D>();
        Bounds = circleCollider.bounds;

        //playerController.ChangeBoundary(EXTRA_WIDTH);
    }
}

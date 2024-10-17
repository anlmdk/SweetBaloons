using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInformation : MonoBehaviour
{
    public bool wasCombinedIn { get; set; }

    private bool hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollided && !wasCombinedIn)
        {
            hasCollided = true;

            ThrowBaloonController.Instance.canThrow = true;
            ThrowBaloonController.Instance.SpawnABaloon(BaloonSelector.Instance.NextBaloon);
            BaloonSelector.Instance.PickNextBaloon();

            Destroy(this);
        }
    }
}

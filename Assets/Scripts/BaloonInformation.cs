using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonInformation : MonoBehaviour
{
    public int BaloonIndex = 0;
    public int PointsWhenAnnihilated = 1;
    public float BaloonMass = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.mass = BaloonMass;
    }
}

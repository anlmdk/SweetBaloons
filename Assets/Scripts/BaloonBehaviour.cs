using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BaloonBehaviour : MonoBehaviour
{
    Baloon baloon;

    public bool hasTouched = false;

    private void Start()
    {
        baloon = FindObjectOfType<Baloon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Baloon"))
        {
            if (!hasTouched) // E�er daha �nce de�memi�se
            {
                hasTouched = true;
                // Burada gerekli ba�ka i�lemleri yapabilirsiniz
            }
        }

        // �arp��ma yap�lan nesne balon mu?
        Baloon otherBaloon = collision.gameObject.GetComponent<Baloon>();
        if (otherBaloon != null && otherBaloon.color == baloon.color)
        {
            // Ayn� renkteki balon �arp��t�, renk de�i�tir
            baloon.ChangeColor(otherBaloon);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            GameManager.Instance.GameOver();
        }
    }
}

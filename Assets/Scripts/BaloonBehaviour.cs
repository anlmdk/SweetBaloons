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
            if (!hasTouched) // Eðer daha önce deðmemiþse
            {
                hasTouched = true;
                // Burada gerekli baþka iþlemleri yapabilirsiniz
            }
        }

        // Çarpýþma yapýlan nesne balon mu?
        Baloon otherBaloon = collision.gameObject.GetComponent<Baloon>();
        if (otherBaloon != null && otherBaloon.color == baloon.color)
        {
            // Ayný renkteki balon çarpýþtý, renk deðiþtir
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

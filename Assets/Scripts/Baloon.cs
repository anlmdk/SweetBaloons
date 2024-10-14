using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    BaloonSpawner baloonSpawner;

    public Colors color;

    // Balonun renklerini temsil eden dizi
    private static Colors[] colorsArray = (Colors[])System.Enum.GetValues(typeof(Colors));


    private void Start()
    {
        baloonSpawner = FindObjectOfType<BaloonSpawner>();
    }

    // Balonun rengini deðiþtiren metod
    public void ChangeColor(Baloon otherBaloon)
    {
        // Mevcut rengin indeksini al
        int currentIndex = (int)color;

        // Renk dizisinde bir sonraki rengi kontrol et
        if (currentIndex < colorsArray.Length - 1)
        {
            // Yeni rengi atama
            Colors newColor = colorsArray[currentIndex + 1];

            // Diðer balonu yok et
            Destroy(otherBaloon.gameObject);

            // Bu balonun rengini deðiþtir
            color = newColor;

            // Renk güncelleme
            UpdateBaloonColor();

            // Eðer yeni bir renk açýlmýþsa IncreaseColorCount'u çaðýrýyoruz
            if (newColor == colorsArray[baloonSpawner.currentColorCount])
            {
                baloonSpawner.IncreaseColorCount(); // Yeni renk açýlýnca renk sayýsýný artýr
            }

            // Eðer balon son renkteyse, isteðe baðlý olarak yok edilebilir
            if (color == Colors.Bomb) // Eðer son renk bombaysa balonu yok et
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Eðer son renkteyse, baþlangýç rengine dön
            color = colorsArray[0];
            UpdateBaloonColor();
        }
    }

    // Balonun görünümünü güncelleyen metod (örnek)
    private void UpdateBaloonColor()
    {
        // Burada balonun görsel temsilini güncelleyin
        // Örneðin, bir sprite renderer'ý kullanarak rengi deðiþtirebilirsiniz
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            // Renk deðiþimlerini burada yapabilirsiniz
            switch (color)
            {
                case Colors.White:
                    renderer.color = Color.white;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(5);
                    break;
                case Colors.Yellow:
                    renderer.color = Color.yellow;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(10);
                    break;
                case Colors.Red:
                    renderer.color = Color.red;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(20);
                    break;
                case Colors.Orange:
                    renderer.color = new Color(1f, 0.5f, 0f); // Turuncu

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(30);
                    break;
                case Colors.Green:
                    renderer.color = Color.green;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(40);
                    break;
                case Colors.Blue:
                    renderer.color = Color.blue;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(50);
                    break;
                case Colors.Pink:
                    renderer.color = new Color(1f, 0.75f, 0.8f); // Pembe

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(60);
                    break;
                case Colors.Purple:
                    renderer.color = new Color(0.5f, 0f, 0.5f); // Mor

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(70);
                    break;
                case Colors.Brown:
                    renderer.color = new Color(0.65f, 0.16f, 0.16f); // Kahverengi

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(80);
                    break;
                case Colors.Grey:
                    renderer.color = Color.grey;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(90);
                    break;
                case Colors.Black:
                    renderer.color = Color.black;

                    // Score 'u güncelle
                    GameManager.Instance.SetScore(100);
                    break;
                case Colors.Bomb:
                    // Burada bomba rengi veya efekti eklenebilir
                    break;
            }
        }
    }

    public enum Colors
    {
        White,
        Yellow,
        Red,
        Orange,
        Green,
        Blue,
        Pink,
        Purple,
        Brown,
        Grey,
        Black,
        Bomb
    }
}

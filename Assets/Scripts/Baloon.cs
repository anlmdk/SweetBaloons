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

    // Balonun rengini de�i�tiren metod
    public void ChangeColor(Baloon otherBaloon)
    {
        // Mevcut rengin indeksini al
        int currentIndex = (int)color;

        // Renk dizisinde bir sonraki rengi kontrol et
        if (currentIndex < colorsArray.Length - 1)
        {
            // Yeni rengi atama
            Colors newColor = colorsArray[currentIndex + 1];

            // Di�er balonu yok et
            Destroy(otherBaloon.gameObject);

            // Bu balonun rengini de�i�tir
            color = newColor;

            // Renk g�ncelleme
            UpdateBaloonColor();

            // E�er yeni bir renk a��lm��sa IncreaseColorCount'u �a��r�yoruz
            if (newColor == colorsArray[baloonSpawner.currentColorCount])
            {
                baloonSpawner.IncreaseColorCount(); // Yeni renk a��l�nca renk say�s�n� art�r
            }

            // E�er balon son renkteyse, iste�e ba�l� olarak yok edilebilir
            if (color == Colors.Bomb) // E�er son renk bombaysa balonu yok et
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // E�er son renkteyse, ba�lang�� rengine d�n
            color = colorsArray[0];
            UpdateBaloonColor();
        }
    }

    // Balonun g�r�n�m�n� g�ncelleyen metod (�rnek)
    private void UpdateBaloonColor()
    {
        // Burada balonun g�rsel temsilini g�ncelleyin
        // �rne�in, bir sprite renderer'� kullanarak rengi de�i�tirebilirsiniz
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            // Renk de�i�imlerini burada yapabilirsiniz
            switch (color)
            {
                case Colors.White:
                    renderer.color = Color.white;

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(5);
                    break;
                case Colors.Yellow:
                    renderer.color = Color.yellow;

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(10);
                    break;
                case Colors.Red:
                    renderer.color = Color.red;

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(20);
                    break;
                case Colors.Orange:
                    renderer.color = new Color(1f, 0.5f, 0f); // Turuncu

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(30);
                    break;
                case Colors.Green:
                    renderer.color = Color.green;

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(40);
                    break;
                case Colors.Blue:
                    renderer.color = Color.blue;

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(50);
                    break;
                case Colors.Pink:
                    renderer.color = new Color(1f, 0.75f, 0.8f); // Pembe

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(60);
                    break;
                case Colors.Purple:
                    renderer.color = new Color(0.5f, 0f, 0.5f); // Mor

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(70);
                    break;
                case Colors.Brown:
                    renderer.color = new Color(0.65f, 0.16f, 0.16f); // Kahverengi

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(80);
                    break;
                case Colors.Grey:
                    renderer.color = Color.grey;

                    // Score 'u g�ncelle
                    GameManager.Instance.SetScore(90);
                    break;
                case Colors.Black:
                    renderer.color = Color.black;

                    // Score 'u g�ncelle
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

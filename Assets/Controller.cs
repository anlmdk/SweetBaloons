using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Controller : MonoBehaviour
{
    BaloonSpawner baloonSpawner;

    public Camera cam;

    public Vector3 mousePosition;

    public bool isClicked = false;

    // Spawner'�n hareket edebilece�i s�n�rlar
    public float minX = -5f;
    public float maxX = 5f;

    private void Start()
    {
        baloonSpawner = FindObjectOfType<BaloonSpawner>();
        Debug.Log(baloonSpawner);
    }

    private void Update()
    {
        TouchInput();
        SpawnnerController();
    }

    public void TouchInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (baloonSpawner.newBaloon != null)
            {
                // Balonun Rigidbody2D bile�enini al ve yer�ekimini aktif et
                Rigidbody2D dropBaloon = baloonSpawner.newBaloon.GetComponent<Rigidbody2D>();

                if (dropBaloon != null)
                {
                    baloonSpawner.DetachBaloon();
                    dropBaloon.gravityScale = 1f; // Yer�ekimi etkisini aktif et
                    isClicked = true;
                    Debug.Log("Objeye t�klad�k");
                }
                else
                {
                    isClicked = false;
                    Debug.LogWarning("Balonun Rigidbody2D bile�eni eksik.");
                }
            }
        }
        else
        {
            isClicked = false;
        }
    }

    public void SpawnnerController()
    {
        // Fare pozisyonunu oyun d�nyas�na �evir
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D oyunda Z eksenini s�f�r yap�yoruz

        // E�er fare ekran d���ndaysa spawner'� minX veya maxX konumuna yerle�tir
        if (mousePosition.x < minX)
        {
            mousePosition.x = minX;
        }
        else if (mousePosition.x > maxX)
        {
            mousePosition.x = maxX;
        }

        // Spawner objesinin yeni pozisyonunu ayarla
        baloonSpawner.transform.position = new Vector3(mousePosition.x, baloonSpawner.transform.position.y, baloonSpawner.transform.position.z);
    }
}

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

    // Spawner'ýn hareket edebileceði sýnýrlar
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
                // Balonun Rigidbody2D bileþenini al ve yerçekimini aktif et
                Rigidbody2D dropBaloon = baloonSpawner.newBaloon.GetComponent<Rigidbody2D>();

                if (dropBaloon != null)
                {
                    baloonSpawner.DetachBaloon();
                    dropBaloon.gravityScale = 1f; // Yerçekimi etkisini aktif et
                    isClicked = true;
                    Debug.Log("Objeye týkladýk");
                }
                else
                {
                    isClicked = false;
                    Debug.LogWarning("Balonun Rigidbody2D bileþeni eksik.");
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
        // Fare pozisyonunu oyun dünyasýna çevir
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D oyunda Z eksenini sýfýr yapýyoruz

        // Eðer fare ekran dýþýndaysa spawner'ý minX veya maxX konumuna yerleþtir
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

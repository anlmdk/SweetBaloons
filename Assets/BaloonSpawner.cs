using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonSpawner : MonoBehaviour
{
    Controller controller;

    public GameObject[] baloonPrefabs;

    public GameObject newBaloon;

    // Ba�lang��ta spawn edilecek balon say�s�
    public int initialSpawnCount = 2;

    // Ge�erli renk say�s�
    public int currentColorCount = 0;

    private void Start()
    {
        controller = FindObjectOfType<Controller>();
        currentColorCount = Mathf.Min(initialSpawnCount, baloonPrefabs.Length); // Ba�lang��ta mevcut renk say�s�n� al
        SpawnInitialBaloons(); // Ba�lang��ta balonlar� spawn et
    }

    private void Update()
    {
        if (newBaloon != null && newBaloon.GetComponent<BaloonBehaviour>().hasTouched)
        {
            SpawnBaloons();
        }
    }

    // �lk balonlar� spawn etme
    private void SpawnInitialBaloons()
    {
        // �lk iki renkten rastgele birini se�
        int randomBaloon = Random.Range(0, initialSpawnCount);

        // Spawn pozisyonunu ayarlarken Spawner'�n y pozisyonunu kullan
        Vector3 spawnPosition = new Vector3(controller.mousePosition.x, transform.position.y, 0f);

        newBaloon = Instantiate(baloonPrefabs[randomBaloon], spawnPosition, Quaternion.identity);
        newBaloon.transform.parent = transform;
    }

    // Balon spawn etme
    public void SpawnBaloons()
    {
        int randomBaloon = Random.Range(0, currentColorCount); // Mevcut renk say�s�na g�re rastgele se�

        // Spawn pozisyonunu ayarlarken Spawner'�n y pozisyonunu kullan
        Vector3 spawnPosition = new Vector3(controller.mousePosition.x, transform.position.y, 0f);


        newBaloon = Instantiate(baloonPrefabs[randomBaloon], spawnPosition, Quaternion.identity);

        newBaloon.transform.parent = transform;
    }

    // Balon d��erken child objeden ��karma
    public void DetachBaloon()
    {
        newBaloon.transform.parent = null;
    }

    // Balon a��ld�k�a mevcut renk say�s�n� art�rma
    public void IncreaseColorCount()
    {
        if (currentColorCount < baloonPrefabs.Length)
        {
            currentColorCount++; // Yeni bir rengi a�
        }
    }
}

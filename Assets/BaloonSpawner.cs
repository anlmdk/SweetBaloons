using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonSpawner : MonoBehaviour
{
    Controller controller;

    public GameObject[] baloonPrefabs;

    public GameObject newBaloon;

    // Baþlangýçta spawn edilecek balon sayýsý
    public int initialSpawnCount = 2;

    // Geçerli renk sayýsý
    public int currentColorCount = 0;

    private void Start()
    {
        controller = FindObjectOfType<Controller>();
        currentColorCount = Mathf.Min(initialSpawnCount, baloonPrefabs.Length); // Baþlangýçta mevcut renk sayýsýný al
        SpawnInitialBaloons(); // Baþlangýçta balonlarý spawn et
    }

    private void Update()
    {
        if (newBaloon != null && newBaloon.GetComponent<BaloonBehaviour>().hasTouched)
        {
            SpawnBaloons();
        }
    }

    // Ýlk balonlarý spawn etme
    private void SpawnInitialBaloons()
    {
        // Ýlk iki renkten rastgele birini seç
        int randomBaloon = Random.Range(0, initialSpawnCount);

        // Spawn pozisyonunu ayarlarken Spawner'ýn y pozisyonunu kullan
        Vector3 spawnPosition = new Vector3(controller.mousePosition.x, transform.position.y, 0f);

        newBaloon = Instantiate(baloonPrefabs[randomBaloon], spawnPosition, Quaternion.identity);
        newBaloon.transform.parent = transform;
    }

    // Balon spawn etme
    public void SpawnBaloons()
    {
        int randomBaloon = Random.Range(0, currentColorCount); // Mevcut renk sayýsýna göre rastgele seç

        // Spawn pozisyonunu ayarlarken Spawner'ýn y pozisyonunu kullan
        Vector3 spawnPosition = new Vector3(controller.mousePosition.x, transform.position.y, 0f);


        newBaloon = Instantiate(baloonPrefabs[randomBaloon], spawnPosition, Quaternion.identity);

        newBaloon.transform.parent = transform;
    }

    // Balon düþerken child objeden çýkarma
    public void DetachBaloon()
    {
        newBaloon.transform.parent = null;
    }

    // Balon açýldýkça mevcut renk sayýsýný artýrma
    public void IncreaseColorCount()
    {
        if (currentColorCount < baloonPrefabs.Length)
        {
            currentColorCount++; // Yeni bir rengi aç
        }
    }
}

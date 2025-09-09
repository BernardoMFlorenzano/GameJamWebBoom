using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    private List<Transform> spawnPoints;
    [SerializeField] private GameObject inimigo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }

        InvokeRepeating("SpawnarInimigos", 0f, 1f);
    }

    void SpawnarInimigos()
    {
        int spawnPos = Random.Range(0, spawnPoints.Count);

        Instantiate(inimigo, spawnPoints[spawnPos].position, Quaternion.identity);
    }
}

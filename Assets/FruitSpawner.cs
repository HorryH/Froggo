using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public static int remaining = 300;
    public static bool gameEnd = false;
    public float minDelay = .001f;
    public float maxDelay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits ()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            if (maxDelay > 0.01)
            {
                maxDelay -= 0.01f;
            }
            if (remaining == 0)
            {
                yield return new WaitForSeconds(2f);
                gameEnd = true;
                break;
            }
            remaining--;


            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 3f);
        }
    }

    public bool isGameEnd()
    {
        return gameEnd;
    }

    public int getRemaining()
    {
        return remaining;
    }
}

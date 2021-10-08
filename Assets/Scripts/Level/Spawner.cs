
/*
 * -----------------------------------------
 * -- Project: Endless Runner 2D -----------
 * -- Author: Rubén Rodríguez Estebban -----
 * -- Date: 98/10/2021 ---------------------
 * -----------------------------------------
 */

using System.Collections;
using UnityEngine;

/*
 * Script that control the appearance of elements in the
 * game round like the ground, the platforms or the items (good and bad).
 */

public class Spawner : MonoBehaviour
{
    // Minimum time time to set the interval for spawn the objects
    public float minTime;

    // Maximum time time to set the interval for spawn the objects
    public float maxTime;

    // Array of objects to be spawned
    public GameObject[] itemPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine that spawn the objects recursively
        StartCoroutine(SpawnCoroutine(1.0f));
    }

    // Coroutine that spawn random objects from time to time
    private IEnumerator SpawnCoroutine(float waitTime)
    {
        // Waits <<waitTime>> seconds to start to spawn the objects
        yield return new WaitForSeconds(waitTime);

        // Calculate the index position in the vector of the object to be spawned and then it is instantiated
        int ramdomItemToSpawn = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[ramdomItemToSpawn], transform.position, Quaternion.identity);

        // Waits a random time between <<minTime and maxTime>> to be executed the next time that it is called
        float randomTimeToSpawn = Random.Range(minTime, maxTime);
        StartCoroutine(SpawnCoroutine(randomTimeToSpawn));
    }
}

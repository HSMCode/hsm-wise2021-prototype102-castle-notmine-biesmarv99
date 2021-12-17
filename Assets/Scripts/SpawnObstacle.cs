using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] possibleObstacles;
    public float spawnGap = 3f;
    public float randomXPosition = -3f;
    private int numberOfObstacles;
    // set first platform to spawn around -2.5f on y-axis
    public float randomYPosition = -2.5f;
    private float randomFactor;
    // variables to check if there is space for next obstacle
    private GameObject lastPlatform;
    private bool canSpawnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        // get number of obstacles within array
        numberOfObstacles = possibleObstacles.Length;

        // make spawning of obstacles possible
        canSpawnPlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        // coroutine that waits with spawning until obstacles won't overlap with each other
        if (canSpawnPlatform == false) {
            StartCoroutine(waitForObstacle());
        } else {
            StopCoroutine(waitForObstacle());
            Spawner();
        }
    }

    private void Spawner() {
        // Choose spawning obstacle randomly from array
        int chooseObstacle = Random.Range(0, numberOfObstacles);
        GameObject chosenObstacle = possibleObstacles[chooseObstacle];

        // x-coordinate: inherited from PlatformSpawn, add half the size to change spawn-pivot
        Bounds bounds = chosenObstacle.GetComponentInChildren<Renderer>().bounds;
        float xPos = transform.position.x + bounds.extents.x * 2.5f; // Generates the Gap between Obstacles
        // y-coordinate: randomly within -3.5 and 2, make sure that obstacles can be reached by max +-1.5f
        randomFactor = Random.Range(-1f, 1f);
        randomYPosition += randomFactor;
        if (randomYPosition < -3.5 || randomYPosition > 2) {
            randomYPosition -= randomFactor * 2;
        }

        float yPos = randomYPosition;
        // z-coordinate: in front of background
        float zPos = -2;
        Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);

        // instanciate chosenObstacle at spawnPosition
        GameObject instanciatedObstacle = Instantiate(chosenObstacle, spawnPosition, Quaternion.identity, this.gameObject.transform);

        // set last spawned obstacle and disable spawning new ones to prevent overlapping
        lastPlatform = instanciatedObstacle;
        canSpawnPlatform = false;
    }

    IEnumerator waitForObstacle() {
        // check if right side of obstacle is past spawn zone
        float xPos = lastPlatform.GetComponentInChildren<Renderer>().bounds.max.x;
        if (xPos < transform.position.x - spawnGap) {
            canSpawnPlatform = true;
        }
            yield return null;
    }
}

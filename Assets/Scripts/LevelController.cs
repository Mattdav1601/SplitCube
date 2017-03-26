using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public GameObject[] obsSet;

    public float spawnInterval;
    float spawnTimer;

    public PlayerController player;

    public float offset;

	// Use this for initialization
	void Start ()
    {
        spawnTimer = spawnInterval;

    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTimer = Mathf.Clamp(spawnTimer - Time.deltaTime, 0, Mathf.Infinity);

        if(spawnTimer <= 0)
        {
            SpawnObstacle();
            spawnTimer = spawnInterval;
        }
	}

    void SpawnObstacle()
    {
        int randIndex = UnityEngine.Random.Range(0, obsSet.Length);

        GameObject newObstacle = Instantiate(obsSet[randIndex]);
        newObstacle.transform.position = new Vector3(0, player.gameObject.transform.position.y - offset, 0);

        float randScale = UnityEngine.Random.Range(1, 2);
        newObstacle.transform.localScale = new Vector3(randScale, randScale, 1);


        spawnInterval = Mathf.Clamp(spawnInterval - 0.25f, 3, 5);

    }
}

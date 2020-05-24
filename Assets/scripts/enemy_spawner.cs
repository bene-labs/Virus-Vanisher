using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public GameObject enemy;

    public float spawnRate = 1f;
    private float nextSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject go = (GameObject)Instantiate(enemy,
            new Vector3(Random.Range(-9.0f, 9.0f), 6, -2), Quaternion.identity);
            go.GetComponent<enemy_movement>().isClone = true;
            go.SetActive(true);
        }
    }
}

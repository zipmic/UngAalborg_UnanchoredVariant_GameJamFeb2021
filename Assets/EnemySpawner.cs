using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyToSpawn;
    public float SpawnInterval;

    private float _counter;

    // Start is called before the first frame update
    void Start()
    {
        _counter = SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        _counter -= Time.deltaTime;
        if (_counter <= 0)
        {
            //Spawn
            GameObject tmp = Instantiate(EnemyToSpawn) as GameObject;
            tmp.transform.position = transform.position;
            _counter = SpawnInterval;
        }
    }
}

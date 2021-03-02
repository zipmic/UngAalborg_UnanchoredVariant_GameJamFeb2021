using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyToSpawn;
    public float SpawnInterval;

    private float _counter;

    public GameObject ExplosionPrefab;

    private AudioPlayer _audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _counter = SpawnInterval;
        _audioPlayer = GameObject.Find("AudioPlayer").GetComponent<AudioPlayer>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (!collision.gameObject.GetComponent<BulletProperties>()._bigBullet)
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject tmp = Instantiate(EnemyToSpawn) as GameObject;
                    tmp.transform.position = transform.position;
                }

                _audioPlayer.PlayWrongBullet();
                
            }
            else if(collision.gameObject.GetComponent<BulletProperties>()._bigBullet)
            {
                _audioPlayer.PlaySpawnerDeath();
                GameObject tmp = Instantiate(ExplosionPrefab) as GameObject;
                tmp.transform.position = transform.position;
                GameObject.Find("GameManager").GetComponent<Gamemanager>().SpawnerDestroyed();
                Destroy(gameObject);
            }
        }
    }
}

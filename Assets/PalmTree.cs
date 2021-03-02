using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour
{

    public int Health = 5;
    public GameObject TreeDropPrefab;
    private AudioPlayer audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GameObject.Find("AudioPlayer").GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Health--;
            audioPlayer.PlayTreeHit();
            if (Health <= 0)
            {
                SpawnPointsAndDestroyTree();

            }
            Destroy(collision.gameObject);

        }
    }

    void SpawnPointsAndDestroyTree()
    {

        int i = Random.Range(1, 4);
        for(int j = 0; j < i; j++)
        {
            GameObject tmp = Instantiate(TreeDropPrefab) as GameObject;
            tmp.transform.position = transform.position + Vector3.up * Random.Range(-1f, 1f) + Vector3.right * Random.Range(-1f, 1f);
        }

        Destroy(gameObject);
    }
}

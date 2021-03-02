using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject _targetObject;

    private Rigidbody2D _rb;

    public float Speed = 200;

    public GameObject Explosion;

    private bool _avoidObstacle;

    private bool _invincible;
    private SpriteRenderer _sr;
    private AudioPlayer audioPlayer;

    private Vector3 AvoidanceVector;

    private float avoidCounter = 0;
    // Start is called before the first frame update


    // Start is called before the first frame update
    void Start()
    {
        _targetObject = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        audioPlayer = GameObject.Find("AudioPlayer").GetComponent<AudioPlayer>();

        StartCoroutine(InvincibleStart());
      
    }

    IEnumerator InvincibleStart()
    {

        _invincible = true;

        float oldspeed = Speed;
        Speed = 100;
        

        for(int i = 0; i < 20; i++)
        {
            _sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        Speed = oldspeed*Random.Range(0.80f, 1.2f);
        _invincible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 VectorToPlayer = _targetObject.transform.position - transform.position;

        if (!_avoidObstacle)
        {
            _rb.velocity = VectorToPlayer.normalized * Speed * Time.deltaTime;
        }
        else
        {
            _rb.velocity = VectorToPlayer.normalized * Speed * Time.deltaTime + AvoidanceVector.normalized*-1;
        }

        if (_avoidObstacle)
        {
            avoidCounter += Time.deltaTime;
            if (avoidCounter >= 3)
            {
                avoidCounter = 0;
                _avoidObstacle = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        _avoidObstacle = true;

        AvoidanceVector = collision.transform.position - transform.position;

        if(collision.gameObject.tag == "Bullet" && !_invincible)
        {
            audioPlayer.PlayMobDeath();
            GameObject tmp = Instantiate(Explosion) as GameObject;
            tmp.transform.position = transform.position;
            Destroy(gameObject);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}

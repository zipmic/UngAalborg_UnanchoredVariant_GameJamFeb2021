using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject _targetObject;

    private Rigidbody2D _rb;

    public float Speed = 600;

    private bool _avoidObstacle;

    private bool _invincible;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _targetObject = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();

        StartCoroutine(InvincibleStart());
      
    }

    IEnumerator InvincibleStart()
    {

        _invincible = true;
        Speed = 100;

        for(int i = 0; i < 20; i++)
        {
            _sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        Speed = 600;
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
            _rb.velocity = VectorToPlayer.normalized * Speed * Time.deltaTime + Vector3.up*4;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        _avoidObstacle = true;

        if(collision.gameObject.tag == "Bullet" && !_invincible)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _avoidObstacle = false;
    }
}

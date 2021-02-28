using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject _targetObject;

    private Rigidbody2D _rb;

    public float Speed = 600;

    private bool _avoidObstacle;

    // Start is called before the first frame update
    void Start()
    {
        _targetObject = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
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

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _avoidObstacle = false;
    }
}

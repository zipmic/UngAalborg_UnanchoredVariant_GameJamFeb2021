using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float Speed = 800;

    public bool _bigBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = transform.right * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!_bigBullet)
        {
            Destroy(gameObject);
        }
    }
}

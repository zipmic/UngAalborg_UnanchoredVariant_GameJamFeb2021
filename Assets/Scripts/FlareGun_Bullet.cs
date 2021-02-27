using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGun_Bullet : MonoBehaviour
{

    public float BulletSpeed = 100;

    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _rb.velocity = transform.right * BulletSpeed * Time.fixedDeltaTime;

    }
}

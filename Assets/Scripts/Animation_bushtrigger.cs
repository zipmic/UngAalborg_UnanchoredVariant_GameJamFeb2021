using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_bushtrigger : MonoBehaviour
{

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _animator.Play("Animation_bush_trigger");
        }
    }
}

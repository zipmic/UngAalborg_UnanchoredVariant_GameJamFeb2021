using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{

	private PlayerScript _playerScript;

	private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
		_animator = GetComponent<Animator>();
		_playerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
		_animator.SetFloat("WalkSpeed", _playerScript.GetSpeed());

	}
}

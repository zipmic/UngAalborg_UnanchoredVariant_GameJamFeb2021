using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpriteFlipOnDifferentSidesOfPlayer : MonoBehaviour
{


    private SpriteRenderer _mySprite;
    private Transform _mainPlayerSprite;


    // Start is called before the first frame update
    void Start()
    {
        _mainPlayerSprite = GetComponentInParent<PlayerScript>().transform;
        _mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x > _mainPlayerSprite.transform.position.x)
        {
            _mySprite.flipY = true;
        }
        else
        {
            _mySprite.flipY = false;
        }
        
    }
}

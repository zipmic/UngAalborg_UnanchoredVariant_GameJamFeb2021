using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprietTurnOffOnRandom : MonoBehaviour
{

    private SpriteRenderer _sr;
    // Start is called before the first frame update
    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.enabled = false;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(2,4));
        _sr.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.15f));
        _sr.enabled = false;
        StartCoroutine(Start());

    }

    // Update is called once per frame

}

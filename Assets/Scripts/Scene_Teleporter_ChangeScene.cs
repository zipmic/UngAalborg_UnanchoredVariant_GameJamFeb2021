using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Teleporter_ChangeScene : MonoBehaviour
{

    public string ChangeSceneTo;

    public float TimeForSceneChange = 5;

    public Color FromColor, ToColor;

    private float _counter;

    private bool _countup;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _countup = true;
    }

    private void Update()
    {
        if (_countup)
        {

            if (_counter <= TimeForSceneChange)
            {
                _counter += Time.deltaTime;
                if(_counter > TimeForSceneChange)
                {
                    _counter = TimeForSceneChange;
                }
            }

        

         }
        else
        {

            if (_counter > 0)
            {
                _counter -= Time.deltaTime;
                if(_counter < 0)
                {
                    _counter = 0;
                }
            }
        }

        _sr.color = Color.Lerp(FromColor, ToColor, _counter / TimeForSceneChange);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _countup = false;
    }
}

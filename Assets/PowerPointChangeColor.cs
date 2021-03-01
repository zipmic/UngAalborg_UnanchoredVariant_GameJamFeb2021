using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPointChangeColor : MonoBehaviour
{

    public List<Color> Colors = new List<Color>();
    private float speed = 1;
    private SpriteRenderer _sr;

    private float counter = 0;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(10f,20f);
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime*speed;
        _sr.color = Color.Lerp(_sr.color, Colors[index], counter);
        if(counter >= 1)
        {
            counter = 0f;
            index++;
            if(index >= Colors.Count)
            {
                index = 0;
            }
        }
    }
}

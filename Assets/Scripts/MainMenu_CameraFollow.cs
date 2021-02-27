using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_CameraFollow : MonoBehaviour
{

	public Transform[] Players;

	private int numPlayers = 0;
	public float StartSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		Vector3 middle = Vector3.zero;
		numPlayers = 0;

		foreach (Transform t in Players)
		{
			if (t != null)
			{
				middle += t.position;
				numPlayers++;
			}
		}

		middle /= numPlayers;
		print(middle.magnitude);

		Camera.main.transform.position = new Vector3(middle.x, middle.y, Camera.main.transform.position.z);
		Camera.main.orthographicSize = StartSize + middle.magnitude;




	}
}

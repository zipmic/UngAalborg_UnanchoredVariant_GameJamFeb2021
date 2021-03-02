using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{

    public int SpawnerAlive = 4;
    public Text SpawnerText;

    public GameObject EndCondition, AudioPlayer;


    void Start()
    {
        SpawnerText = GameObject.Find("SpawnerText").GetComponent<Text>();
    }

    public void SpawnerDestroyed()
    {
        SpawnerAlive--;
        if (SpawnerAlive <= 0)
        {
            print("End game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        SpawnerText.text = "Spawners Left: " + SpawnerAlive;
    }

    void EndGame()
    {
        EndCondition.SetActive(true);
        AudioPlayer.SetActive(false);
    }
}

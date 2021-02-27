using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplitScreenController : MonoBehaviour
{

    [SerializeField]
    private Camera StartCam;

    [SerializeField]
    private List<Camera> PlayerCams = new List<Camera>();

    //private List<Player> RewiredPlayers = new List<Player>();

    public List<GameObject> Players = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        // For fat på alle spillere
        for (int i = 0; i < 4; i++)
        {
            
        //    RewiredPlayers.Add(ReInput.players.GetPlayer(i));
        }

    }

    // Update is called once per frame
    void Update()
    {
      /*  for (int i = 0; i < RewiredPlayers.Count; i++)
        {
            if (!Players[i].activeSelf)
            {
                
                if (RewiredPlayers[i].GetAnyButtonDown())
                {
                    Players[i].SetActive(true);
                    PlayerCams[i].gameObject.SetActive(true);
                    ChangeSplitscreenDependingOnPlayers();
                    
                }
            }


        }

        */

        void ChangeSplitscreenDependingOnPlayers()
        {

            List<Camera> EnabledCams = new List<Camera>();
            for(int i = 0; i < PlayerCams.Count; i++)
            {
                if (PlayerCams[i].gameObject.activeSelf)
                {
                    EnabledCams.Add(PlayerCams[i]);
                }
            }

            if (EnabledCams.Count == 1)
            {
                EnabledCams[0].rect = new Rect(0, 0, 1, 1);
            }
            else if (EnabledCams.Count == 2)
            {
                EnabledCams[0].rect = new Rect(0, 0.5f, 1, 0.5f);
                EnabledCams[1].rect = new Rect(0, 0, 1, 0.5f);
            }
            else if (EnabledCams.Count == 3)
            {
                EnabledCams[0].rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                EnabledCams[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                EnabledCams[2].rect = new Rect(0.25f, 0, 0.5f, 0.5f);
            }
            else if (EnabledCams.Count == 4)
            {
                EnabledCams[0].rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                EnabledCams[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                EnabledCams[2].rect = new Rect(0, 0, 0.5f, 0.5f);
                EnabledCams[3].rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            }

            StartCam.gameObject.SetActive(false);




            // Hop over til en spiller view...
            // 2 = 50-50
            // 3 = 2 i toppen, 1 i bunden ( samme størrelse dog)
            // 4 = 4

        }
    }
}
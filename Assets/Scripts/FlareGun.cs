using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlareGun : MonoBehaviour
{

    public GameObject SpawnPoint;
    public GameObject PrefabFlareGunBullet;
    public float ShootInterval;
    public float Ammo, MaxAmmo = 15;

    private bool _readyToShoot = true;
    private float _counterUntilNextShoot;

    // ref to playerscript (rewired player)
   // private Rewired.Player _player;

    // Start is called before the first frame update
    void Start()
    {
       // _player = GetComponentInParent<PlayerScript>().GetRewiredPlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_readyToShoot)
        {
            _counterUntilNextShoot -= Time.deltaTime;
            if (_counterUntilNextShoot <= 0)
            {
                _readyToShoot = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _readyToShoot = false;
                _counterUntilNextShoot = ShootInterval;
                // Skyde mechanism

                GameObject bulletSpawn = Instantiate(PrefabFlareGunBullet) as GameObject;
                bulletSpawn.transform.position = SpawnPoint.transform.position;
                bulletSpawn.transform.right = SpawnPoint.transform.right * -1;

            }
           
        }
        
    }
}

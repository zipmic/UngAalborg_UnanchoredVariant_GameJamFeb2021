using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

	public AudioClip Monster_death, Tree_hit, ShootGun, Pickup, Spawner_death, PlayerDeath, wrongBullet;

		private AudioSource _as;

	private void Start()
	{
		_as = GetComponent<AudioSource>();

	}

	public void PlayMobDeath()
	{
		_as.PlayOneShot(Monster_death);
	}

	public void PlayTreeHit()
	{
		_as.PlayOneShot(Tree_hit);
	}
	public void PlayShootGun()
	{
		_as.PlayOneShot(ShootGun);
	}
	public void PlayPickup()
	{
		_as.PlayOneShot(Pickup);
	}
	public void PlaySpawnerDeath()
	{
		_as.PlayOneShot(Spawner_death);
	}

	public void PlayPlayerDeath()
	{
		_as.PlayOneShot(PlayerDeath);
	}

	public void PlayWrongBullet()
	{
		_as.PlayOneShot(wrongBullet);
	}

}

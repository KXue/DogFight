using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	public int m_numberOfAsteroids;
	public Vector3 m_spawnBounds;
	// Use this for initialization
	void Awake()
	{
		for(int i = 0; i < m_numberOfAsteroids; i++){
			SpawnAsteroid();
		}
	}
	void SpawnAsteroid(){
		Vector3 spawnLocation = new Vector3(
			Random.Range(-m_spawnBounds.x, m_spawnBounds.x),
            Random.Range(-m_spawnBounds.y, m_spawnBounds.y),
            Random.Range(-m_spawnBounds.z, m_spawnBounds.z)
		);
		Transform asteroid = UberPool.SharedInstance.GetObject("asteroid");
		asteroid.position = spawnLocation;
		asteroid.rotation = Quaternion.identity;
	}
}

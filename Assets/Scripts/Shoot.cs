using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Transform m_bulletPrefab; 
	public Transform m_bulletSpawnLocation;
    public float m_fireRate;
    private bool m_firing = false;
	private float m_timeSinceLastShot = 0;
	private float m_timePerShot;
	void Awake()
	{
		m_timePerShot = 60f / m_fireRate;
	}
	public void SetFiring(bool value){
		m_firing = value;
	}
	void Update()
	{
		if(m_firing){
            m_timeSinceLastShot -= Time.deltaTime;
            if (m_timeSinceLastShot <= 0)
			{
                Fire();
                m_timeSinceLastShot = m_timePerShot;
            }
		}
	}
	void Fire(){
		Transform bullet = UberPool.SharedInstance.GetObject("bullet");
		bullet.position = m_bulletSpawnLocation.position;
		bullet.rotation = m_bulletSpawnLocation.rotation;
		bullet.GetComponent<Bullet>().Enable();
	}
}

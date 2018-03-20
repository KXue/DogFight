using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float m_speed;
	private Rigidbody m_rigidbody;
	// Use this for initialization
	void Awake () {
		m_rigidbody = GetComponent<Rigidbody>();
	}
	public void Enable(){
        m_rigidbody.velocity = transform.forward * m_speed;
        Invoke("Disable", 10);
	}
	void Disable(){
        gameObject.SetActive(false);
    }
	void OnTriggerEnter(Collider other)
	{	Health health = other.GetComponent<Health>();
		//bullet hit logic here
		if(health){
			health.ChangeHealth(-1);
		}
		gameObject.SetActive(false);
	}
}
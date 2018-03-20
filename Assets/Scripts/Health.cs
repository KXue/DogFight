using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float m_maxHealth;
	private float m_health;
	// Use this for initialization
	void Start () {
		m_health = m_maxHealth;
	}
	void OnEnable()
	{
		m_health = m_maxHealth;
	}
	public void ChangeHealth(float amount){
		m_health += amount;
		m_health = Mathf.Min(m_health, m_maxHealth);
		if(m_health <= 0){
            gameObject.SetActive(false);
        }
	}
}

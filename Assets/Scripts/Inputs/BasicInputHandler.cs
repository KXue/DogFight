using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInputHandler : MonoBehaviour {
	private SpaceShipMovement m_spaceShipMovement;
	private Shoot m_shoot;
	void Awake()
	{
        m_spaceShipMovement = GetComponent<SpaceShipMovement>();
		m_shoot = GetComponent<Shoot>();
	}
	// Update is called once per frame
	void Update () {
		m_shoot.SetFiring(Input.GetButton("Fire1"));
		m_spaceShipMovement.Thrust(Input.GetAxis("Thrust"));
        m_spaceShipMovement.Roll(Input.GetAxis("Roll"));
        m_spaceShipMovement.Pitch(Input.GetAxis("Pitch"));
        m_spaceShipMovement.Yaw(Input.GetAxis("Yaw"));
    }
}

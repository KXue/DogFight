using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpaceShip : MonoBehaviour, SpaceShipMovement {
    public float m_pitchMultiplier;
	public float m_rollMultiplier;
    public float m_yawMultiplier;

	public float m_minThrust;
	public float m_maxThrust;
	public float m_defaultThrust;

	private float m_thrustValue = 0;
    private float m_pitchValue = 0;
    private float m_rollValue = 0;
	private float m_yawValue = 0;
    private Rigidbody m_rigidbody;

	void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation *= CalculateRotation();
		m_rigidbody.AddForce(transform.forward * CalculateThrust() * Time.deltaTime);
	}
	float CalculateThrust(){
		float retVal;
		if(m_thrustValue >= 0){
			retVal = m_thrustValue * (m_maxThrust - m_defaultThrust);
		}
		else{
			retVal = m_thrustValue * (m_defaultThrust - m_minThrust);
		}
        return retVal + m_defaultThrust;
	}
	Quaternion CalculateRotation(){
		Vector3 rotations = new Vector3(
            m_pitchMultiplier * m_pitchValue,
            m_yawMultiplier * m_yawValue,
            -m_rollMultiplier * m_rollValue
        );
		rotations *= Time.deltaTime;
		return Quaternion.Euler(rotations);
	}
    public void Pitch(float value)
    {
		m_pitchValue = value;
    }
    public void Thrust(float value){
		m_thrustValue = value;
	}
	public void Roll(float value){
		m_rollValue = value;
	}
    public void Yaw(float value){
		m_yawValue = value;
	}
}

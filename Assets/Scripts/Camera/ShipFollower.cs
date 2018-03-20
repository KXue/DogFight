using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollower : MonoBehaviour {
	public Vector3 m_focusOffset;
	public Vector3 m_cameraOffset;
	public float m_speed;
	public float m_rotationSpeed;
	public Transform m_ship;
	void LateUpdate()
	{
		if(m_ship != null){
			transform.position = CalculateCameraPosition();
			transform.rotation = CalculateCameraRotation();
		}
	}
	Vector3 CalculateCameraPosition(){
		Vector3 targetPosition = m_ship.position + m_ship.rotation * m_cameraOffset;
		return Vector3.Lerp(transform.position, targetPosition, m_speed * Time.deltaTime);
	}
	Quaternion CalculateCameraRotation(){
		Quaternion targetRotation = Quaternion.LookRotation(m_ship.position + m_ship.rotation * m_focusOffset - transform.position, m_ship.up);
		return Quaternion.Lerp(transform.rotation, targetRotation, m_rotationSpeed * Time.deltaTime);
	}
}

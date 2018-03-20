using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpaceShipMovement{
	void Thrust(float value);
	void Pitch(float value);
    void Roll(float value);
    void Yaw(float value);
}

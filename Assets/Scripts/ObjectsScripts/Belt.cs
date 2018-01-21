using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour {

	private float maxSpeed = 1;
	private float minSpeed = 0;
	private bool isRunning = true;

	public void ToggleRunning() {
		isRunning = !isRunning;
		if (isRunning)
			this.gameObject.GetComponent<ConveyorScript>().conveyorDriveSpeed = maxSpeed;
		else
			this.gameObject.GetComponent<ConveyorScript>().conveyorDriveSpeed = minSpeed;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUseObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	private GameObject collidingObject; 
	// 2
	private GameObject objectInHand; 


	private void SetCollidingObject(Collider col)
	{
		if (collidingObject && isUsable(collidingObject))
		{
			return;
		}
		collidingObject = col.gameObject;
	}

	/*
	 *  Trigger Objects enter Collider. Triggered automatically.
	*/

	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

	/*
	* 	Interacting related Functions
	*/
	private bool isUsable(GameObject obj) {
		Usable script = obj.GetComponent<Usable>();
		if (script != null)
			return true;
		else
			return false;

	}

	// Update is called once per frame
	void Update () {
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			if (collidingObject && isUsable(collidingObject))
			{	
				Usable objScript = collidingObject.GetComponent<Usable> ();
				objScript.OnUse (null);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 

public class ControllerMenuSystem : MonoBehaviour {

	public UnityEvent ShowMenuItems;
	public UnityEvent HideMenuItems;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown())
		{
			ShowMenuItems.Invoke();
		}

		if (Controller.GetHairTriggerUp ()) {
			HideMenuItems.Invoke ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolbar : MonoBehaviour {

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

	public GameObject hammerPrefab;
	// 2
	private GameObject hammer;
	// 3
	private Transform hammerTransform;
	// 4
	private Vector3 hitPoint; 


	
	// Update is called once per frame
	void Update () {
		if ( Controller.GetPressDown (SteamVR_Controller.ButtonMask.Grip))
		{
			hammer.SetActive(true);
		}
		if (Controller.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) 
		{
			hammer.SetActive(false);
		}
	}
}

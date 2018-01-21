using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercount : MonoBehaviour {



	private SteamVR_TrackedObject trackedObj;

	public GameObject counter;
	public GameObject spark;
	private float startTime;
	private float currentTime;
	private int count = 0;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		spark.gameObject.SetActive (false);
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
//	private GameObject collidingObject; 
//	// 2
//	private GameObject objectInHand; 
//
//	private void SetCollidingObject(Collider col)
//	{
//		if (collidingObject || !col.GetComponent<Rigidbody>())
//		{
//			return;
//		}
//		collidingObject = col.gameObject;
//	}
	private bool isDestroying = false;
	public void OnTriggerEnter(Collider other)
	{
//		SetCollidingObject(other);
		if(other.gameObject.GetComponent<BatteryPack>() != null) {
			count = count + 1;
			isDestroying = true;
			other.gameObject.transform.position = new Vector3 (257.27f, 1.287f, 281.87f);
			spark.gameObject.SetActive (true);
			startTime = Time.time;
		}
	}


//	public void OnTriggerStay(Collider other)
//	{
//		SetCollidingObject(other);
//	}
//
//	public void OnTriggerExit(Collider other)
//	{
//		if (!collidingObject)
//		{
//			//count = count + 1;
//			return;
//		}
//		collidingObject = null;
//	}
//	int isInside = 0;

	// Update is called once per frame
	void Update () {
//		if (collidingObject) {
//			isInside = 1;
//		}
//		if (isInside == 1 && !collidingObject) {
//			count = count + 1;
//			isInside = 0;
//		}
		//Debug.Log (count);
		//counter = this.transform.Find("counter").gameObject;
		currentTime = Time.time;
		counter.gameObject.GetComponent<TextMesh>().text = "Processed Number: " + count.ToString();
		if (spark.gameObject.activeSelf && (currentTime - startTime > 3))
			spark.gameObject.SetActive (false);


	}
}

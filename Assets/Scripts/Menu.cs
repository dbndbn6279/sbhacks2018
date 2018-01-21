using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public List<GameObject> items;
	bool isMenuShows = false;

	void Awake() {
		this.gameObject.SetActive (true);
		currentTime = Time.time;
		lastTime = currentTime;
		HideItems ();
	}

	// Show and hide items
	public void ShowItems() {
		// Set each Objective Active
		foreach (GameObject item in items) {
			item.SetActive (true);
		}

		// Set each gameObject's parent to be menu and set their coordinate
		int index = 0;
		foreach (GameObject item in items) {
			item.transform.SetParent (this.transform);
			float itemX = -0.2f + 0.2f * (index % 3);
			float itemY = -0.2f + 0.2f * (index / 3);
			item.transform.localPosition = new Vector3(itemX, itemY, 0);
			index++;
		}

		isMenuShows = true;

	}

	public void HideItems() {
		foreach (GameObject item in items) {
			if (item.transform.parent != null) {
				item.transform.SetParent (null);
			}
			item.SetActive (false);
			isMenuShows = false;
		}
	}

	// Add and Get items
	float lastTime;
	float currentTime;

	private void SetNoramlPhysics(GameObject obj) {
		currentTime = Time.time;
		//obj.GetComponent<Collider> ().isTrigger = false;
		//obj.GetComponent<Rigidbody> ().isKinematic = false;
		if (currentTime - lastTime > 1) {
			obj.GetComponent<Rigidbody> ().useGravity = true;
			lastTime = currentTime;
		}
	}

	private void SetItemPhysics(GameObject obj) {
		currentTime = Time.time;
		//obj.GetComponent<Collider> ().isTrigger = true;
		//obj.GetComponent<Rigidbody> ().isKinematic = true;
		if (currentTime - lastTime > 1) {
			obj.GetComponent<Rigidbody>().useGravity = false;
			lastTime = currentTime;
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (isMenuShows && other.gameObject.transform.parent != this.gameObject.transform && other.gameObject.GetComponent<Pickable>() != null) {
			other.gameObject.transform.SetParent (this.gameObject.transform);
			items.Add (other.gameObject);
			SetItemPhysics (other.gameObject);
			//ShowItems ();
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (isMenuShows && other.gameObject.transform.parent == this.gameObject.transform && other.gameObject.GetComponent<Pickable>() != null) {
			other.gameObject.transform.SetParent (null);
			items.Remove (other.gameObject);
			SetNoramlPhysics (other.gameObject);
		}
	}
}

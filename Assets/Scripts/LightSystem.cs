using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem : MonoBehaviour {

	private bool isOn = true;

	public void OnClick() {
		isOn = !isOn;
		if (isOn) {
			for (int i = 0; i < this.gameObject.transform.childCount; i++) {
				this.gameObject.transform.GetChild (i).gameObject.transform.GetChild (0).gameObject.SetActive (true);
			}

		} else {
			for (int i = 0; i < this.gameObject.transform.childCount; i++) {
				this.gameObject.transform.GetChild (i).gameObject.transform.GetChild (0).gameObject.SetActive (false);
			}
		}
			
	}

}

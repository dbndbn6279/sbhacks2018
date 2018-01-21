using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour {
	public GameObject parts;

	// Use this for initialization
	void Start () {
		StartCoroutine(createCubes());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator createCubes(){
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds (1);
			GameObject newCube = Instantiate(parts);
			newCube.transform.parent = this.transform;
			newCube.transform.localPosition = new Vector3 (0f, 0f, 0f);
		}
	}
}

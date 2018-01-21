using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : MonoBehaviour {

	private Material material;
	// Use this for initialization
	void Start () {
		material = this.gameObject.GetComponent<Renderer> ().material;
		material.SetColor ("_Color", Color.green);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggle() {
		if (material.color != Color.green)
			material.SetColor ("_Color", Color.green);
		else
			material.SetColor ("_Color", Color.red);
	}
}

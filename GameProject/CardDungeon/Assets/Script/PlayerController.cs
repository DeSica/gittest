using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class PlayerController : MonoBehaviour {

	public static PlayerController Instance;
	private void Awake() {
		Instance = this;
	}
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
	}
}

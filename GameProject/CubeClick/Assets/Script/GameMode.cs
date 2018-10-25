using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

	public GameObject m_Border;
	// Use this for initialization
	private Transform[] m_BorderChildren;
	void Start () {
		m_BorderChildren = m_Border.transform.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

	// Use this for initialization
	private Transform[] m_BorderChildren;
	void Start () {
		Physics2D.gravity = 100 * Physics2D.gravity;
		Rect ScreenWorldRect = GameManager.Instance.m_ScreenWorldRect;
		m_BorderChildren = transform.GetComponentsInChildren<Transform>();
		m_BorderChildren[1].localPosition = new Vector3(0, (ScreenWorldRect.height + 50) / 2);
		m_BorderChildren[2].localPosition = new Vector3(0, -(ScreenWorldRect.height + 50) / 2);
		m_BorderChildren[3].localPosition = new Vector3((ScreenWorldRect.width + 50) / 2, 0);
		m_BorderChildren[4].localPosition = new Vector3(-(ScreenWorldRect.width + 50) / 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

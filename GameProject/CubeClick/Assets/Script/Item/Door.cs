using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		PlayerController.m_Instance.SetClickLock(true);
		GameManager.Instance.PauseGame();
		GameManager.Instance.ShowPanel(PanelType.EndPanel);
	}
}

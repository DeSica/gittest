using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuUIController : MonoBehaviour {

	public Button m_StartGame;
	// Use this for initialization
	void Start () {
		m_StartGame.onClick.AddListener(() => {
			GameManager.Instance.ShowPanel(PanelType.LevelPanel);
			GameManager.Instance.HidePanel(PanelType.MenuPanel);
		});
	}
}

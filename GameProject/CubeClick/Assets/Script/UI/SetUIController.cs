using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUIController : MonoBehaviour {

	public Button m_Home;
	public Button m_Level;
	public Button m_Restart;
	public Button m_Continue;
	// Use this for initialization
	void Start () {
		m_Home.onClick.AddListener(() => {
			GameManager.Instance.ShowPanel(PanelType.MenuPanel);
			GameManager.Instance.HidePanel(PanelType.GamePanel);
			GameManager.Instance.HidePanel(PanelType.SetPanel);
			GameManager.Instance.HideLevel();
			GameManager.Instance.ContinueGame();
			PlayerController.m_Instance.SetClickLock(false);
		});
		m_Level.onClick.AddListener(() => {
			GameManager.Instance.ShowPanel(PanelType.LevelPanel);
			GameManager.Instance.HidePanel(PanelType.GamePanel);
			GameManager.Instance.HidePanel(PanelType.SetPanel);
			GameManager.Instance.HideLevel();
			GameManager.Instance.ContinueGame();
			PlayerController.m_Instance.SetClickLock(false);
		});
		m_Restart.onClick.AddListener(() => {
			GameManager.Instance.HidePanel(PanelType.SetPanel);
			GameManager.Instance.RestartLevel();
			GameManager.Instance.ContinueGame();
			PlayerController.m_Instance.SetClickLock(false);
		});
		m_Continue.onClick.AddListener(() => {
			GameManager.Instance.HidePanel(PanelType.SetPanel);
			GameManager.Instance.ContinueGame();
			PlayerController.m_Instance.SetClickLock(false);
		});
	}
	
}

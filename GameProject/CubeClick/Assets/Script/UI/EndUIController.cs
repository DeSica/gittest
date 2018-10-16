using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour {

	public Button m_Restart;
	public Button m_Next;
	public GameObject[] m_StarArr;
	// Use this for initialization
	void Start () {
		m_Restart.onClick.AddListener(() => {
			GameManager.Instance.HidePanel(PanelType.EndPanel);
			GameManager.Instance.RestartLevel();
			GameManager.Instance.ContinueGame();
			PlayerController.m_Instance.SetClickLock(false);
		});
		m_Next.onClick.AddListener(() => {
			GameManager.Instance.HidePanel(PanelType.EndPanel);
			GameManager.Instance.NextLevel();
			GameManager.Instance.ContinueGame();
			PlayerController.m_Instance.SetClickLock(false);
		});
	}
	private void OnEnable() {
		int StarNum = GameUIController.m_Instance.GetCurLevelStar();
		for(int i = 0; i < m_StarArr.Length; ++i)
		{
			m_StarArr[i].SetActive(i < StarNum);
		}
	}
}

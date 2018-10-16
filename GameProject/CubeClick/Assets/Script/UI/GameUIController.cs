using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUIController : MonoBehaviour {

	public Button m_SetButton;
	public int m_TouchLimit = 20;
	public Text m_TimeText;
	public Text m_TouchCountText;

	private int m_LevelPassTime = 0;
	private int m_CurTouchCount = 0;
	// Use this for initialization
	void Start () {
		m_SetButton.onClick.AddListener(() => {
			PlayerController.m_Instance.SetClickLock(true);
			GameManager.Instance.PauseGame();
			GameManager.Instance.ShowPanel(PanelType.SetPanel);
		});
	}
	private void OnEnable() {
		ReStart();
	}
	private void OnDisable() {
		CancelInvoke("UpdateTime");
	}
	public void ReStart()
	{
		m_LevelPassTime = 0;
		m_CurTouchCount = 0;
		m_TimeText.text = m_LevelPassTime.ToString();
		m_TouchCountText.text = (m_TouchLimit - m_CurTouchCount).ToString();
		CancelInvoke("UpdateTime");
		InvokeRepeating("UpdateTime", 1, 1);
	}
	private void UpdateTime()
	{
		++m_LevelPassTime;
		m_TimeText.text = m_LevelPassTime.ToString();
	}
	public int GetCurLevelStar()
	{
		int star = 3 - m_LevelPassTime / 30;
		return star > 0 ? star : 0;
	}
	// Update is called once per frame
	public static GameUIController m_Instance;
    private void Awake()
    {
        m_Instance = this;
    }
}

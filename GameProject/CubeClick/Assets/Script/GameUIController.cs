using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUIController : MonoBehaviour {

	public int m_TouchLimit = 20;
	public Text m_TimeText;
	public Text m_TouchCountText;

	private int m_LevelPassTime = 0;
	private int m_CurTouchCount = 0;
	// Use this for initialization
	void Start () {
		
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
		InvokeRepeating("UpdateTime", 1, 1);
	}
	private void UpdateTime()
	{
		++m_LevelPassTime;
		m_TimeText.text = m_LevelPassTime.ToString();
	}
	public void AddTouchCount(int _AddNum)
	{
		m_CurTouchCount += _AddNum;
		if(m_TouchLimit < m_CurTouchCount)
		{
			m_CurTouchCount = m_TouchLimit;
			ReStart();
			GameManager.Instance.RestartLevel();
		}
		m_TouchCountText.text = (m_TouchLimit - m_CurTouchCount).ToString();
	}
	// Update is called once per frame
	public static GameUIController m_Instance;
    private void Awake()
    {
        m_Instance = this;
    }
}

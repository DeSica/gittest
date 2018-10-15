using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] m_LevelPrefabArr;
	public GameObject m_WorldRoot;
	public GameObject m_UIRoot;

	private string m_CurLevelName;
	private GameObject m_CurLevelObj;
	void Start () {
		HideLevel();
		ShowPanel("MenuPanel");
	}
	public void ShowPanel(string _PanelName) 
	{
		Transform _PanelTr = m_UIRoot.transform.Find(_PanelName);
		if(_PanelTr) 
		{
			_PanelTr.gameObject.SetActive(true);
		}
	}
	public void HidePanel(string _PanelName) 
	{
		Transform _PanelTr = m_UIRoot.transform.Find(_PanelName);
		if(_PanelTr) 
		{
			_PanelTr.gameObject.SetActive(false);
		}
	}
	public void ShowLevel(string _LevelName) 
	{
		m_WorldRoot.SetActive(true);
		Destroy(m_CurLevelObj);
		foreach(GameObject prefab in m_LevelPrefabArr)
		{
			if(prefab.name == _LevelName) 
			{
				GameObject obj = Instantiate(prefab);
				m_CurLevelName = _LevelName;
				m_CurLevelObj = obj;
				obj.SetActive(true);
				obj.transform.parent = m_WorldRoot.transform;
			}
		}
	}
	public void HideLevel() 
	{
		m_WorldRoot.SetActive(false);
	}

	public void RestartLevel() 
	{
		ShowLevel(m_CurLevelName);
	}
	public void PauseGame()
	{
		Time.timeScale = 0;
	}
	public void ContinueGame()
	{
		Time.timeScale = 1;
	}
	// Update is called once per frame
	void Update () {
		
	}
	public static GameManager Instance = null;
	private void Awake() {
		Instance = this;
	}
}

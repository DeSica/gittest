using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> m_LevelPrefabArr;
	public GameObject m_WorldRoot;
	public GameObject m_UIRoot;

	private string m_CurLevelName;
	private GameObject m_CurLevelObj;
	private int m_CurLevelIndex;

	private Vector3 m_ScreenSize;
	private Rect m_ScreenWorldRect;
	void Start () {
		CulScreenSize();
		HideLevel();
		ShowPanel(PanelType.MenuPanel);
	}
	public void ShowPanel(PanelType _Panel) 
	{
		Transform _PanelTr = m_UIRoot.transform.Find(_Panel.ToString());
		if(_PanelTr) 
		{
			_PanelTr.gameObject.SetActive(true);
		}
	}
	public void HidePanel(PanelType _Panel) 
	{
		Transform _PanelTr = m_UIRoot.transform.Find(_Panel.ToString());
		if(_PanelTr) 
		{
			_PanelTr.gameObject.SetActive(false);
		}
	}
	public void ShowLevel(int _LevelIndex) 
	{
		m_WorldRoot.SetActive(true);
		Destroy(m_CurLevelObj);
		for(int i = 0; i <　m_LevelPrefabArr.Count; ++i)
		{
			if(i == _LevelIndex) 
			{
				GameObject obj = Instantiate(m_LevelPrefabArr[i]);
				m_CurLevelObj = obj;
				m_CurLevelIndex = _LevelIndex;
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
		ShowLevel(m_CurLevelIndex);
		GameUIController.m_Instance.ReStart();
	}
	public void NextLevel()
	{
		if(m_CurLevelIndex >= m_LevelPrefabArr.Count - 1)
		{
			HideLevel();
			HidePanel(PanelType.GamePanel);
			ShowPanel(PanelType.LevelPanel);
		} else 
		{
			ShowLevel(++m_CurLevelIndex);
			GameUIController.m_Instance.ReStart();
		}
	}
	public void PauseGame()
	{
		Time.timeScale = 0;
	}
	public void ContinueGame()
	{
		Time.timeScale = 1;
	}

	public void CulScreenSize()
	{
		m_ScreenSize = new Vector3(Screen.width, Screen.height, 0);
		Vector3 ScreenP1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Vector3 ScreenP2 = Camera.main.ScreenToWorldPoint(m_ScreenSize);
		m_ScreenWorldRect = new Rect(ScreenP1.x, ScreenP1.y, ScreenP2.x - ScreenP1.x, ScreenP2.y - ScreenP1.y);
	}
	// Update is called once per frame
	void Update () {
		
	}
	public static GameManager Instance = null;
	private void Awake() {
		Instance = this;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] m_LevelPrefabArr;
	public GameObject m_WorldRoot;
	public GameObject m_UIRoot;
	void Start () {

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
		Transform _LevelTr = m_WorldRoot.transform.Find(_LevelName);
		if(_LevelTr)
		{
			_LevelTr.gameObject.SetActive(true);
		} 
		else 
		{
			foreach(GameObject prefab in m_LevelPrefabArr)
			{
				if(prefab.name == _LevelName) 
				{
					GameObject obj = Instantiate(prefab);
					obj.SetActive(true);
					obj.transform.parent = m_WorldRoot.transform;
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public static GameManager Instance = null;
	private void Awake() {
		Instance = this;
	}
}

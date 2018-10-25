using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour {

	public GameObject m_LevelPrefab;

	List<Button> m_LevelBtnArr;
	// Use this for initialization
	void Start () {
		m_LevelBtnArr = new List<Button>();
		int LevelNum = GameManager.Instance.m_LevelPrefabArr.Count;
		for(int i = 0; i < LevelNum; ++i)
		{
			GameObject obj = Instantiate(m_LevelPrefab);
			obj.transform.SetParent(transform);
			Text txt = obj.transform.GetChild(0).GetComponent<Text>();
			txt.text = "level" + (i + 1);
			Button btn = obj.GetComponent<Button>();
			int _LevelIndex = i;
			btn.onClick.AddListener(() => {
				GameManager.Instance.ShowLevel(_LevelIndex);
				GameManager.Instance.HidePanel(PanelType.LevelPanel);
				GameManager.Instance.ShowPanel(PanelType.GamePanel);
			});
			m_LevelBtnArr.Add(btn);
		}
	}
	
}

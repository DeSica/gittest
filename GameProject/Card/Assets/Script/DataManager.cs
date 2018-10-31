using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

[System.Serializable]
public class CardData
{
	public int id; 
	public string name;
}

[System.Serializable]
public class BossData
{
	public int id; 
	public string name;
}
[System.Serializable]
public class TableData
{
	public List<BossData> BossData;
	public List<CardData> CardData;
}
public class DataManager : MonoBehaviour {

	public static DataManager Instance = null;
	private TableData TableData;
	private void Awake() {
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		string path = Application.dataPath + "/Resources/JSON/test.json";
		TableData = LoadFromFile<TableData>(path);
	}
	
	T LoadFromFile<T> (string path)
	{
		StreamReader sr = new StreamReader(path);
		string json = sr.ReadToEnd();
		return JsonUtility.FromJson<T>(json);
	}
	// Update is called once per frame
	void Update () {
		
	}
}

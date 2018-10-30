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
public class CardDataArr
{
	public List<CardData> data;
}
public class DataManager : MonoBehaviour {

	public static DataManager Instance = null;
	private CardDataArr CardData;
	private void Awake() {
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		string path = Application.dataPath + "/Resources/JSON/test.json";
		CardData = LoadFromFile<CardDataArr>(path);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGroup : MonoBehaviour {

	public GameObject GridPrefab;
	public Vector2Int GridGroupSize;
	public Vector2 GridInterval;

	private Vector2 GridSize;
	private Vector2 GridOffset;
	// Use this for initialization
	void Start () {
		GridSize = Global.GetSpriteObjWorldSize(GridPrefab);
		GridOffset = new Vector2(
			-((GridGroupSize.x - 1) * GridSize.x + (GridGroupSize.x - 1) * GridInterval.x) / 2,
			-((GridGroupSize.y - 1) * GridSize.y + (GridGroupSize.y - 1) * GridInterval.y) / 2
			);
		InitGridGroup();
	}
	void InitGridGroup()
	{
		Global.RemoveChildrenByComponentType(transform, typeof(Grid));
		for(int i = 0; i < GridGroupSize.x; ++i)
		{
			for(int j = 0; j < GridGroupSize.y; ++j)
			{
				GameObject obj = Instantiate(GridPrefab);
				obj.transform.SetParent(transform);
				obj.transform.localPosition = new Vector3(
					i * (GridSize.x + GridInterval.x) + GridOffset.x,
					j * (GridSize.y + GridInterval.y) + GridOffset.y);
			}
		}
	}
	// Update is called once per frame
	void Update () {
	}
}

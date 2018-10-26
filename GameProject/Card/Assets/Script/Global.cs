using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace UnityEngine
{
	
	public class Global : MonoBehaviour {
		public static void RemoveChildrenByType(Transform transform, Type type)
		{
			Component[] cptArr = transform.GetComponentsInChildren(type, true);
			foreach(Component cpt in cptArr)
			{
				if(cpt.transform != transform)
				{
					Destroy(cpt.gameObject);
				}
			}
		}
	}
}

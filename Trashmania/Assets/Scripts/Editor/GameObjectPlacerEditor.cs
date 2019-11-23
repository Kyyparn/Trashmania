using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EntityPlacer))]
public class GameObjectPlacerEditro : Editor {

	public int objectCount = 10;
	public float xOffset = 0f;
	public float yOffset = 0f;


	public override void OnInspectorGUI() {
		
		xOffset = EditorGUILayout.FloatField("X Offset", xOffset);
		yOffset = EditorGUILayout.FloatField("Y Offset", yOffset);

		if (GUILayout.Button("Place Objects")) {
			Transform parent = ((EntityPlacer)target).transform;
			int childCount = parent.childCount;
			for (int i = 0; i < childCount; i++) {
				parent.GetChild(i).transform.localPosition = new Vector3(i*xOffset, i*yOffset, 0);
			}
		}

		DrawDefaultInspector();
	}
}

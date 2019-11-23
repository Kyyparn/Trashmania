using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EntityPlacer))]
public class GameObjectPlacerEditro : Editor {

	public int objectCount = 10;
	public Vector3 positionOffset;
	public Vector3 rotation;

	public override void OnInspectorGUI() {

		positionOffset = EditorGUILayout.Vector3Field("Position Offset", positionOffset);
		rotation = EditorGUILayout.Vector3Field("Rotation", rotation);

		if (GUILayout.Button("Place Objects")) {
			Transform parent = ((EntityPlacer)target).transform;
			int childCount = parent.childCount;
			for (int i = 0; i < childCount; i++) {
				var child = parent.GetChild(i);
				child.transform.localPosition = positionOffset * i;
				child.transform.localRotation = Quaternion.Euler(rotation);
			}
		}

		DrawDefaultInspector();
	}
}

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FixedLoader), true)]
public class FixedLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FixedLoader fl = target as FixedLoader;

        SerializedObject s = new SerializedObject(fl.Serial());

        SerializedProperty spImage = s.FindProperty("image");

        serializedObject.Update();
        s.Update();

        EditorGUILayout.PropertyField(spImage, new GUIContent("Image"));

        s.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();

        fl.Serial().Load();
    }
}
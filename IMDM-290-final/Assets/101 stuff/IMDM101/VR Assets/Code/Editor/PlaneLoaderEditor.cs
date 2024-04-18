using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlaneLoader), true)]
public class PlaneLoaderEditor : Editor
{
    Texture2D oldTexture;

    public override void OnInspectorGUI()
    {
        PlaneLoader pl = target as PlaneLoader;

        SerializedObject s = new SerializedObject(pl.Serial());

        SerializedProperty spImage = s.FindProperty("image");

        serializedObject.Update();
        s.Update();

        EditorGUILayout.PropertyField(spImage, new GUIContent("Image"));

        s.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();

        pl.Serial().Load();
    }
}
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FragileLoader), true)]
public class FragileLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FragileLoader fl = target as FragileLoader;

        SerializedObject s = new SerializedObject(fl.Serial());

        SerializedProperty spImage = s.FindProperty("image");
        SerializedProperty spAudioClip = s.FindProperty("audioClip");

        serializedObject.Update();
        s.Update();

        EditorGUILayout.PropertyField(spImage, new GUIContent("Image"));
        EditorGUILayout.PropertyField(spAudioClip, new GUIContent("AudioClip"));

        s.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();

        fl.Serial().Load();
    }
}
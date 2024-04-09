using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OnOffLoader), true)]
public class OnOffLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        OnOffLoader ol = target as OnOffLoader;

        SerializedObject s = new SerializedObject(ol.Serial());

        SerializedProperty spOffImage = s.FindProperty("offImage");
        SerializedProperty spOnImage = s.FindProperty("onImage");
        SerializedProperty spWaitTime = s.FindProperty("waitTime");

        SerializedProperty spPlayAudio = s.FindProperty("playAudio");
        SerializedProperty spLoopAudio = s.FindProperty("loopAudio");
        SerializedProperty spMuteAudio = s.FindProperty("muteAudio");

        SerializedProperty spAudioClip = s.FindProperty("audioClip");

        serializedObject.Update();
        s.Update();

        EditorGUILayout.PropertyField(spOffImage, new GUIContent("OffImage"));
        EditorGUILayout.PropertyField(spOnImage, new GUIContent("OnImage"));
        EditorGUILayout.PropertyField(spWaitTime, new GUIContent("waitTime"));
        EditorGUILayout.PropertyField(spPlayAudio, new GUIContent("playAudio"));
        EditorGUILayout.PropertyField(spLoopAudio, new GUIContent("loopAudio"));
        EditorGUILayout.PropertyField(spMuteAudio, new GUIContent("muteAudio"));
        EditorGUILayout.PropertyField(spAudioClip, new GUIContent("audioClip"));

        s.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();

        ol.Serial().Load();
    }
}
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;

public class ArcanixEditor : Editor
{
    Dictionary<string, ReorderableList> _reorderableLists;
    
    private void OnEnable()
    {
        _reorderableLists = new Dictionary<string, ReorderableList>();
        SerializedProperty iter = serializedObject.GetIterator();
        iter.Next(true);
        while (iter.NextVisible(false))
        {
            Debug.Log(iter.propertyPath + " : "+ iter.propertyType);
            var serializedProperty = serializedObject.FindProperty(iter.name);
            if (serializedProperty.isArray)
            {
                ReorderableList list = new ReorderableList(serializedObject, serializedProperty, true, true, true, true);
                _reorderableLists.Add(serializedProperty.name, list);
                list.drawElementCallback = (Rect rect, int index, bool active, bool focused) =>
                {
                    var element = list.serializedProperty.GetArrayElementAtIndex(index);
                    rect.y += 2;
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), element);
                };

                list.drawHeaderCallback = (Rect rect) =>
                {
                    EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), list.serializedProperty.name);
                };
            }
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var iter = serializedObject.GetIterator();
        iter.Next(true);
        while (iter.NextVisible(false))
        {
            if (iter.isArray)
            {
                _reorderableLists[iter.name].DoLayoutList();
            }
            else
            {
                if (iter.name != "m_Script")
                {
                    EditorGUILayout.PropertyField(iter);
                }
                else
                {
                    GUI.enabled = false;
                    EditorGUILayout.PropertyField(iter);
                    GUI.enabled = true;
                }
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}

[CustomEditor(typeof(Unit), true)]
public class UnitEditor : ArcanixEditor
{

}

[CustomEditor(typeof(ScriptableObject), true)]
public class ScriptableEditor : ArcanixEditor
{

}
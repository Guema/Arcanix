using UnityEngine;
using UnityEditor;
using System.Collections;

/*
[CustomPropertyDrawer(typeof(MaxedInt))]
public class MaxedIntDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var minRect = new Rect(position.x, position.y, position.width*5/100, position.height);
        var valRect = new Rect(position.x + minRect.width, position.y, position.width*80/100, position.height);
        var maxRect = new Rect(position.x + minRect.width + valRect.width, position.y, position.width*15/100, position.height);

        EditorGUI.LabelField(minRect, "0");
        //EditorGUI.PropertyField(minRect, property.FindPropertyRelative("min"), GUIContent.none);
        EditorGUI.IntSlider(valRect, property.FindPropertyRelative("value"), 0, property.FindPropertyRelative("max").intValue, GUIContent.none);
        EditorGUI.IntField(maxRect, property.FindPropertyRelative("max").intValue);
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
*/

[CustomEditor(typeof(Unit))]
[CanEditMultipleObjects]
public class DefaultEditor : Editor
{
}

[CustomPropertyDrawer(typeof(MaxedInt))]
public class MaxedIntDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 0;
        EditorGUILayout.LabelField("noob");
    }
}
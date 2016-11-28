using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(ClampedInt))]
public class ClampedIntDrawer : PropertyDrawer
{
    static GUIStyle minStyle = new GUIStyle
    {
        alignment = TextAnchor.MiddleLeft
    };

    static GUIStyle maxStyle = new GUIStyle
    {
        alignment = TextAnchor.MiddleRight
    };

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        var minField = new Rect(position.x, position.y, position.width / 6, position.height);
        var valueBar = new Rect(position.x + minField.width, position.y, position.width * 4 / 6, position.height);
        var maxField = new Rect(position.x + minField.width + valueBar.width, position.y, position.width / 6, position.height);

        //EditorGUI.ProgressBar(position, 0.1f, "val");
        property.FindPropertyRelative("_val").intValue = (int)GUI.HorizontalSlider(valueBar, property.FindPropertyRelative("_val").intValue, 0, property.FindPropertyRelative("_max").intValue, GUIStyle.none, GUIStyle.none);
        EditorGUI.IntField(minField, property.FindPropertyRelative("_val").intValue, minStyle);
        property.FindPropertyRelative("_max").intValue = EditorGUI.IntField(maxField, property.FindPropertyRelative("_max").intValue, maxStyle);
        EditorGUI.ProgressBar(valueBar, (float)property.FindPropertyRelative("_val").intValue / (float)property.FindPropertyRelative("_max").intValue,"");

        EditorGUI.EndProperty();
    }
}
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

        property.isExpanded = false;

        var numberfield = new Rect(position.x, position.y, position.width * 4 / 5, position.height);
        var sliderfield = new Rect(position.x + numberfield.width + 5, position.y, position.width / 5 - 5, position.height);
        
        property.FindPropertyRelative("_max").intValue = EditorGUI.IntField(numberfield, property.displayName, property.FindPropertyRelative("_max").intValue);
        property.FindPropertyRelative("_val").intValue = (int)GUI.HorizontalSlider(sliderfield, property.FindPropertyRelative("_val").intValue, 0, property.FindPropertyRelative("_max").intValue, GUIStyle.none, GUIStyle.none);
        string percent = ((int)((property.FindPropertyRelative("_val").intValue / (float)property.FindPropertyRelative("_max").intValue) * 100)).ToString() + "%";
        EditorGUI.ProgressBar(sliderfield, property.FindPropertyRelative("_val").intValue / (float)property.FindPropertyRelative("_max").intValue, percent);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}

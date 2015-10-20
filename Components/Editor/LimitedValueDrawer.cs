using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(LimitedValue))]
public class LimitedValueDrawer : PropertyDrawer
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
        var minRect = new Rect(position.x, position.y, position.width/10, position.height);
        //var valueRect = new Rect(position.x + minRect.width, position.y, position.width / 8, position.height);
        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        //EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("value"), GUIContent.none);
        //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("min"), GUIContent.none);
        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("max"), GUIContent.none);

        //EditorGUI.PropertyField(minRect, property.FindPropertyRelative("min"), GUIContent.none);
        EditorGUI.IntSlider(position, property.FindPropertyRelative("value"), property.FindPropertyRelative("min").intValue, property.FindPropertyRelative("max").intValue, GUIContent.none);
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}


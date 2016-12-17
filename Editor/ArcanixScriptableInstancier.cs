using UnityEngine;
using System.Collections;
using UnityEditor;

public class ArcanixScriptableInstancier : EditorWindow
{
    static MonoScript _monoscript = null;
    string _assetName = "unnamed";
    //SerializedObject _obj = null;

    [MenuItem("Assets/Create/Arcanix/Scriptable objet instance")]
    [MenuItem("Arcanix/New Scriptable objet instance")]
    static void Init()
    {
        ArcanixScriptableInstancier window = GetWindow<ArcanixScriptableInstancier>(typeof(ArcanixScriptableInstancier));
        window.titleContent = new GUIContent("Scriptable Instancier");
        window.Show();
    }

    void OnGUI()
    {
        _monoscript = (MonoScript)EditorGUILayout.ObjectField(_monoscript, typeof(MonoScript), false);

        if (!_monoscript)
        {
            return;
        }

        System.Type classOfScript = _monoscript.GetClass();

        if (classOfScript == null)
        {
            EditorGUILayout.HelpBox("Unable to read file main class name.", MessageType.Error);
            return;
        }

        if (!classOfScript.IsSubclassOf(typeof(ScriptableObject)))
        {
            EditorGUILayout.HelpBox("You must enter a ScriptableObject class file.", MessageType.Error);
            return;
        }

        if (classOfScript.IsAbstract || classOfScript.IsInterface)
        {
            EditorGUILayout.HelpBox("This ScriptableObject is not instanciable (abstract).", MessageType.Error);
            return;
        }

        _assetName = EditorGUILayout.TextField("Name: ", _assetName);

        if (GUILayout.Button("Instanciate"))
        {
            var newScriptable = CreateInstance(classOfScript);
            AssetDatabase.CreateAsset(newScriptable, "Assets/" + _assetName + ".asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = newScriptable;
            EditorGUIUtility.PingObject(newScriptable.GetInstanceID());
            Close();
        }
    }
}

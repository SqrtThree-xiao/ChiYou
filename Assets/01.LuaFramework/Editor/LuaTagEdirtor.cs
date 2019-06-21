using UnityEditor;

public class LuaTagEdirtor : Editor {

	//TODO 加载.lua文件资源
	[CustomEditor(typeof(LuaTag))]
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		
		EditorGUILayout.PropertyField(serializedObject.FindProperty("objects"), true);
		
		serializedObject.ApplyModifiedProperties();
	}
}

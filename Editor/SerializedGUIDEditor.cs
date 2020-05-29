using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SerializedGUID))]
public class SerializedGuidEditor : PropertyDrawer
{
	const int offset = 0;
	const float labelScale = 0.9f;
	const float buttonScale = 0.1f;

#if LANG_KOR
	const string createText = "생성";
	const string copyText = "GUID 복사";
	const string pastedText = "GUID 붙여넣기";
#else
	const string createText = "Gen";
	const string copyText = "Copy GUID";
	const string pastedText = "Paste GUID";
	const string errorMsg = "Need Initialization GUID!";
#endif

	public override void OnGUI(Rect rect, SerializedProperty p, GUIContent l)
	{
		EditorGUI.BeginProperty(rect, l, p);

		Rect origin = rect;

		rect.width *= labelScale;
		rect.width -= offset;

		var sb = new System.Text.StringBuilder();
		
		SerializedProperty bytes = p.FindPropertyRelative("guidBytes");
		byte[] bytes1 = new byte[16];
		for (int i = 0; i < bytes.arraySize; i++)
		{
			bytes1[i] = (byte) bytes.GetArrayElementAtIndex(i).intValue;
			sb.Append(bytes1[i].ToString());
		}
		
		var guid = new Guid(bytes1);
		
		EditorGUI.LabelField(rect, l, new GUIContent(guid.ToString()));
		
		// 우클릭 메뉴
		if (Event.current.type == EventType.ContextClick)
		{
			if (rect.Contains(Event.current.mousePosition))
			{
				GenericMenu menu = new GenericMenu();

				menu.AddItem(new GUIContent(copyText), false,
					() => { GUIUtility.systemCopyBuffer = new Guid(bytes1).ToString(); });

				var parsed = Guid.TryParse(GUIUtility.systemCopyBuffer, out Guid parsedGuid);
				if (parsed && parsedGuid != Guid.Empty)
				{
					menu.AddItem(new GUIContent(pastedText), false, () => { SetGuid(bytes, parsedGuid); });
				}
				else
				{
					menu.AddDisabledItem(new GUIContent(pastedText));
				}

				menu.ShowAsContext();

				Event.current.Use();
			}
		}

		rect.x = origin.x + rect.width + offset;
		rect.width = origin.width * buttonScale;

		Color bg = Color.white;
		Color ct  = Color.white;
		
		if (bytes.arraySize < 1)
		{
			bg = GUI.backgroundColor;
			ct = GUI.contentColor;
			
			GUI.backgroundColor = Color.green;
			GUI.contentColor = Color.white;			
		}
		
		if (GUI.Button(rect, createText, "MiniButton"))
		{
			SetGuid(bytes, Guid.NewGuid());
		}
		
		if (bytes.arraySize < 1)
		{
			GUI.backgroundColor = bg;
			GUI.contentColor = ct;
		}

		EditorGUI.EndProperty();
	}

	void SetGuid(SerializedProperty serializedProperty, Guid newGuid)
	{
		var bytes = newGuid.ToByteArray();
		serializedProperty.arraySize = bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			serializedProperty.GetArrayElementAtIndex(i).intValue = bytes[i];
		}

		serializedProperty.serializedObject.ApplyModifiedProperties();
	}
}

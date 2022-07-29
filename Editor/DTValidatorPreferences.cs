using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace DTValidator {
	public static class DTValidatorPreferences {
		public static bool ValidateSceneAutomatically {
			get { return EditorPrefs.GetBool("DTValidatorPreferences::ValidateSceneAutomatically", defaultValue: false); }
			set { EditorPrefs.SetBool("DTValidatorPreferences::ValidateSceneAutomatically", value); }
		}

#if UNITY_2018_3_OR_NEWER
		[SettingsProvider]
		public static SettingsProvider DTSettingsProvider() {
			var provider = new SettingsProvider("Preferences/DTValidator", SettingsScope.User) {
				guiHandler = (searchContext) => {
					ValidateSceneAutomatically = EditorGUILayout.Toggle("Validate Scene Automatically", ValidateSceneAutomatically);
				}
			};
			return provider;
		}
#else
		[PreferenceItem("DTValidator")]
		public static void PreferencesGUI() {
			ValidateSceneAutomatically = EditorGUILayout.Toggle("Validate Scene Automatically", ValidateSceneAutomatically);
		}
#endif
	}
}

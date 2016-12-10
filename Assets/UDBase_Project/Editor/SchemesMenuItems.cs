using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Editor {
	public static class SchemesMenuItems {
		[MenuItem("UDBase/Schemes/Default")]
		static void SwitchToScheme_Default() {
			SchemesTool.SwitchScheme("Default");
		}		[MenuItem("UDBase/Schemes/WebRelease")]
		static void SwitchToScheme_WebRelease() {
			SchemesTool.SwitchScheme("WebRelease");
		}		[MenuItem("UDBase/Schemes/WebTest")]
		static void SwitchToScheme_WebTest() {
			SchemesTool.SwitchScheme("WebTest");
		}
	}
}

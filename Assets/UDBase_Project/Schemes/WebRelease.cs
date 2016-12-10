#if Scheme_WebRelease
using UnityEngine;
using System.Collections;
using UDBase.Common;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddController<Scene>(new DirectSceneLoader());
	}
}
#endif

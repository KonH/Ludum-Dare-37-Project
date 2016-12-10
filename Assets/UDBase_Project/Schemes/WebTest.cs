#if Scheme_WebTest
using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.SaveSystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		var save = new FsJsonDataSave().
			AddNode<SaveNode>("save");
		AddController<Save>(save);
		AddController<Scene>(new DirectSceneLoader());
		AddController<Game>(new GameController());
	}
}
#endif

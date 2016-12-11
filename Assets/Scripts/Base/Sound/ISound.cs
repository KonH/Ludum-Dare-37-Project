using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers;

public interface ISound:IController {

	void Play(SoundType type);
}

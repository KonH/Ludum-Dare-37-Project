using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers;

public interface IGame:IController {

	void SelectMode(GameMode mode);
	GameMode GetCurrentMode();
	void CalculateScore(float time);
	int GetCurrentScore();
	int GetBestScore();
}

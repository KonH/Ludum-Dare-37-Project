using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageView : MonoBehaviour {

	public List<GameObject> Pages;

	int _current;

	void Start () {
		for( int i = 0; i < Pages.Count; i++) {
			Pages[i].SetActive(false);
		}
		TryShowNext();
	}

	void Update () {
		if( Input.anyKeyDown ) {
			TryShowNext();
		}
	}

	public void TryShowNext() {
		if( _current >= Pages.Count ) {
			return;
		}
		if( (_current > 0) && (_current < Pages.Count) ) {
			Pages[_current - 1].SetActive(false);
		}
		Pages[_current].SetActive(true);
		_current++;
	}
}

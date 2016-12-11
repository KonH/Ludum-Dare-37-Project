using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Utils;

[RequireComponent(typeof(Image))]
public class RandomColorImage : MonoBehaviour {

	public List<Color> Colors = new List<Color>();

	Image _img = null;

	// Use this for initialization
	void Start () {
		_img = GetComponent<Image>();	
	}

	void OnEnable() {
		_img.color = RandomUtils.GetItem(Colors);
	}
}

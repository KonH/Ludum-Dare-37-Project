using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Utils;

[RequireComponent(typeof(Image))]
public class RandomColorImage : MonoBehaviour {

	public List<Color> Colors = new List<Color>();

	Image _img = null;

	void OnEnable() {
		if( !_img ) {
			_img = GetComponent<Image>();
		}
		_img.color = RandomUtils.GetItem(Colors);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		var destroyable = other.GetComponent<Destroyable>();
		if( destroyable ) {
			destroyable.GiveDamage(destroyable.HP + 1);
		}
	}
}

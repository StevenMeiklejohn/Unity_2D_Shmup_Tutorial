using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

  private WeaponScript[] weapons;

  void Awake(){
    weapons = GetComponentsInChildren<WeaponScript>();
  }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    foreach (WeaponScript weapon in weapons){
    // Auto-fire
    if (weapon != null && weapon.CanAttack){
      weapon.Attack(true);
    }
	}
}
}


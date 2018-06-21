using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

  public int hp = 1;
  public bool isEnemy = true;


	void Start () {
		
	}
	
	void Update () {
		
	}

  public void Damage(int damageCount){
      hp -= damageCount;
      if (hp <= 0){
        Destroy(gameObject);
      }
  }

  public void OnTriggerEnter2D(Collider2D otherCollider){
    // Is this a shot?
    ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
    if (shot != null){
      // Avoid friendly fire
      if (shot.isEnemyShot != isEnemy){
        Damage(shot.damage);
        // Destroy the shot (always target the game object, otherwise you will just remove the script)
        Destroy(shot.gameObject);
      }
    }
  }
}

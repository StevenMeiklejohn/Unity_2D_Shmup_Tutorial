using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

  public Transform shotPreFab;
  public float shootingRate = 0.25f;
  private float shootCooldown;


	// Use this for initialization
	void Start () {
    shootCooldown = 0f;	
	}	

	// Update is called once per frame
	void Update () {
    if (shootCooldown > 0){
      shootCooldown -= Time.deltaTime;
    }
  }

  public void Attack(bool isEnemy){
    if (CanAttack){
      shootCooldown = shootingRate;
      // Create a new shot
      var shotTransform = Instantiate(shotPreFab) as Transform;
      // Assign position
      shotTransform.position = transform.position;
      // The is enemy property
      ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
      if (shot != null){
        shot.isEnemyShot = isEnemy;
      }
      // Make the weapon shot always towards it
      MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
      if (move != null){
        // Move right from the sprite.
        move.direction = this.transform.right;
      }
    }
  }
// Is weapon ready to create a new projectile.
  public bool CanAttack{
    get{
      return shootCooldown <= 0f;
    }
  }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBlaster : MonoBehaviour {

    private Object projectileRef;
    private const float PROJECTILE_SPEED = 200f;

    void Start() {
        projectileRef = Resources.Load("Projectile");
    }

    internal void shoot() {

        //Instantiate projectile at the postion of the ship's blasters
        GameObject projectile = (GameObject)Instantiate(projectileRef);
        projectile.transform.position = new Vector2(transform.position.x, transform.position.y);

        //Shoot projectile from position
        Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
        projectileRB.AddForce(transform.up*PROJECTILE_SPEED);

        //Destroy projectile after three seconds if it didn't hit anything
        StartCoroutine(destroyProjectile(projectile));
    }

    private IEnumerator destroyProjectile(GameObject projectile) {
        yield return new WaitForSeconds(10f);
        Destroy(projectile);
    }


}

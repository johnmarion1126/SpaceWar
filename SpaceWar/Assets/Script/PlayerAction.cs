using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {
    
    [SerializeField] private Player player;
    [SerializeField] private ShipBlaster ship;

    void Start() {
        player.playerRB.velocity = new Vector2(-0.05f, 0);
    }

    void Update() {
        if (player.playerInput.isUpPressed) {
            accelerate();
        } else if (player.playerInput.isDownPressed) {
            ship.shoot();
        }

        if (player.transform.position.y > 6 || player.transform.position.y < -6) {
            player.transform.position = new Vector2(player.transform.position.x, -player.transform.position.y);
        }

        if (player.transform.position.x > 10 || player.transform.position.x < -10) {
            player.transform.position = new Vector2(-player.transform.position.x, player.transform.position.y);
        }
    }

    void LateUpdate() {
        transform.Rotate(0f, 0f, player.playerInput.rotation);
    }

    private void accelerate() {
        player.playerRB.AddForce(transform.up*player.PLAYER_SPEED);
    }

}

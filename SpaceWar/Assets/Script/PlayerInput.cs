using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private string currentPlayer;

    // Up and down inputs
    internal bool isUpPressed;
    internal bool isDownPressed;

    // Left and right inputs
    internal float rotation;
    private float horizontalVal;


    void Update() {
        if (currentPlayer == "Player1") {
            if (Input.GetKey(KeyCode.UpArrow)) {
                isUpPressed = true;
            } else {
                isUpPressed = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                isDownPressed = true;
            } else {
                isDownPressed = false;
            }

            // Calculate rotation of the player ship
            rotation = Input.GetAxis("Horizontal") * -player.PLAYER_ROTATE_SPEED * Time.deltaTime;
        } 
        
        else if (currentPlayer == "Player2") {
            if (Input.GetKey("w")) {
                isUpPressed = true;
            } else {
                isUpPressed = false;
            }

            if (Input.GetKeyDown("s")) {
                isDownPressed = true;
            } else {
                isDownPressed = false;
            }

            if (Input.GetKey("a")) {
                horizontalVal = -1;
            } else if (Input.GetKey("d")) {
                horizontalVal = 1;
            } else {
                horizontalVal = 0;
            }

            // Calculate rotation of the player ship
            rotation = horizontalVal * -player.PLAYER_ROTATE_SPEED * Time.deltaTime;
        }        
    }

}

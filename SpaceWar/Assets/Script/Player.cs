using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Player Script Components")]
    [SerializeField] internal PlayerInput playerInput;
    [SerializeField] internal PlayerAction playerAct;
    [SerializeField] internal PlayerCollision playerCol;

    // Component references
    internal Animator playerAnim;
    internal Rigidbody2D playerRB;

    // Main player properties
    internal int playerHP = 3;
    internal float PLAYER_SPEED = 0.1f;
    internal float PLAYER_ROTATE_SPEED = 80f;

    // Other references
    internal string currentState;
    private bool isUpPressed;
    private bool isDownPressed;
    private bool isLeftPressed;
    private bool isRightPressed;

    void Awake() {
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        changeState("Idle");
    }

    internal void changeState(string state) {
        if (state != currentState) {
            playerAnim.Play(state);
            currentState = state;
        }
    }
}

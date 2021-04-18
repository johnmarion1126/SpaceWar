using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    [SerializeField] private GameObject gameOverText;

    [Header("Player Objects")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private bool isGameOver;

    void Start() {
        gameOverText.SetActive(false);
    }

    void Update() {
        if (player1 == null || player2 == null) StartCoroutine(startGameOver());

        if (isGameOver) {
            if (Input.GetKey("r")) SceneManager.LoadScene("PlayScene");
            if (Input.GetKey("q")) SceneManager.LoadScene("IntroScene");
        }
    }

    private IEnumerator startGameOver() {
        yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        isGameOver = true;
    }
}

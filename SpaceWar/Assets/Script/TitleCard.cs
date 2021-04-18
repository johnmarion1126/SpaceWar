using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour {

    [Header("TitleScreen Componenets")]
    [SerializeField] private Image blackScreen;
    [SerializeField] private GameObject playText;

    private bool isWaiting = true;

    void Start() {
        blackScreen.canvasRenderer.SetAlpha(1.0f);
        blackScreen.CrossFadeAlpha(0,3,false);
        StartCoroutine(flashPlay());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            isWaiting = false;
            StartCoroutine(fadeOut());
        }
    }

    IEnumerator flashPlay() {
        while (isWaiting) {
            playText.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            playText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        for (int i = 0; i < 2; i++) {
            playText.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            playText.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        
        playText.SetActive(true);
    }

    IEnumerator fadeOut() {
        blackScreen.CrossFadeAlpha(1,3,false);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("PlayScene");

    }
}

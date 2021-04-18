using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] private Player player;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("DoesDamage")) {
            Destroy(collision.gameObject);
            StartCoroutine(takeDamage());
        }
    }

    private IEnumerator takeDamage() {
        player.playerHP -= 1;
        player.changeState("Damaged");
        if (player.playerHP == 0) StartCoroutine(destroyShip());
        yield return new WaitForSeconds(1.5f);
        player.changeState("Idle");
    }

    private IEnumerator destroyShip() {
        for (float f = 1f; f >= -0.05f; f -= 0.05f) {
            Color c = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

}

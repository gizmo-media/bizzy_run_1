using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Pollens") {
            Destroy(collision.gameObject);
            PlayerManager.numberOfPollens++;
        } else if (collision.transform.tag == "Death") {
            PlayerManager.isGameOver = true;
        }
    }
}

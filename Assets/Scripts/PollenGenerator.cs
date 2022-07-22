using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class PollenGenerator : MonoBehaviour {
    public GameObject pollenPrefab;
    private Bounds spriteBounds;
    public GameObject player;
    public GameObject newPollenParent;
    [Range(0, 30)][SerializeField] private float pollenLifetime;
    [Range(0, 3)][SerializeField] private float spawnInterval;
    [SerializeField] private float playerOffsetX, playerOffsetY;

    void Start() {
        spriteBounds = GetComponent<SpriteRenderer>().bounds;
        StartCoroutine(spawnPollens());
    }
 
    IEnumerator spawnPollens() {
        while (true) {
            var randomX = Random.Range(0, spriteBounds.size.x) - (spriteBounds.size.x / 2);
            var randomY = Random.Range(0, spriteBounds.size.y) - (spriteBounds.size.y / 2);

            if (Random.Range(1, 2) == 1) randomX = -randomX;
            if (Random.Range(1, 2) == 1) randomY = -randomY;

            var randomLocationInsideSprite = new Vector3(transform.position.x + randomX, transform.position.y + randomY);
            GameObject newPollen = Instantiate(pollenPrefab, randomLocationInsideSprite, Quaternion.identity);
            newPollen.GetComponent<PollenController>().pollenLifetime = pollenLifetime;
            newPollen.transform.parent = newPollenParent.transform;

            yield return new WaitForSeconds(spawnInterval);
        };
    }

    // Update is called once per frame
    void Update() {
        var offsetLocation = new Vector3(
            player.transform.position.x + playerOffsetX,
            player.transform.position.y + playerOffsetY
        );
        transform.position = offsetLocation;
    }
}

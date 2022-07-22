using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static bool isGameOver;
    public static int numberOfPollens;
    public GameObject GameOverPanel;
    
    private void Awake() {
        isGameOver = false;
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Update() {
        if (isGameOver) {
            GameOverPanel.SetActive(true);
        }
    }

    public void ReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour {
    public static bool isGameOver;
    public GameObject GameOverPanel;
    public static int numberOfPollens;
    public TextMeshProUGUI pollenCountText;
    
    private void Awake() {
        isGameOver = false;
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Update() {
        if (isGameOver) {
            GameOverPanel.SetActive(true);
            gameObject.SetActive(false);
        }
        pollenCountText.text = $"{numberOfPollens}";
    }

    public void ReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

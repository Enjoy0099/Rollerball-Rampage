using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreCount_Text;
    public GameObject Loser_Panel;
    public GameObject Winner_Panel;
    //private SpawnManager spawnManager_Script;

    private void Awake()
    {
        //spawnManager_Script = FindObjectOfType<SpawnManager>();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        Winner_Panel.SetActive(true);
    }

    public void LoseGame()
    {
        Loser_Panel.SetActive(true);
    }
}

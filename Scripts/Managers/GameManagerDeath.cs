//Jean-Luc Hayes 02/01/16
//The Manager of the UI's for Death instantiation
// Managers entire scene's Death screens
using UnityEngine;
using System.Collections;

public class GameManagerDeath : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;

    public Canvas canvas;
    public UnityEngine.UI.Text lives;
    public UnityEngine.UI.Text deathTextText;
    public UnityEngine.UI.Text gameOver;
    public UnityEngine.UI.Button startGame;
    public UnityEngine.UI.Button exitGame;
    public UnityEngine.UI.Button reentryGame;
    public UnityEngine.UI.Text winGame;

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + playerHealth.CurrentNumLives;
    }

    public void deathScreenIntial()
    {
        deathText();
        UnityEngine.UI.Button reentryLevels = Instantiate(reentryGame, reentryGame.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Button;
        reentryLevels.transform.SetParent(canvas.transform, false);
    }

    public void deathText()
    {
        UnityEngine.UI.Text deathTexts = Instantiate(deathTextText, deathTextText.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Text;
        deathTexts.transform.SetParent(canvas.transform, false);
        Invoke("reentryLevel", 5f);
    }

    public void wonText()
    {
        UnityEngine.UI.Text winGames = Instantiate(winGame, winGame.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Text;
        winGames.transform.SetParent(canvas.transform, false);
        Invoke("endGame", 5f);
    }

    public void gameOverText()
    {
        UnityEngine.UI.Text gameOvers = Instantiate(gameOver, gameOver.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Text;
        gameOvers.transform.SetParent(canvas.transform, false);
        Invoke("endGame", 5f);
}

    public void deathScreenFinal()
    {
        deathText();
        UnityEngine.UI.Button startGames = Instantiate(startGame, startGame.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Button;
        startGames.transform.SetParent(GameObject.Find("Canvas").transform, false);
        startGames.enabled = true;
        UnityEngine.UI.Button exitGames = Instantiate(exitGame, exitGame.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Button;
        exitGames.transform.SetParent(GameObject.Find("Canvas").transform, false);
        exitGames.enabled = true;
    }

    public void reentryLevel()
    {
        LevelManager.reentryLevel = true;
    }

    public void endGame()
    {
        LevelManager.endGame = true;
    }
}


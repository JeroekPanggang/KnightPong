using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_Bot : MonoBehaviour
{
    [Header("Variabel untuk Score")]
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    [SerializeField] private int BatasScore = 100;

    //Buat UI Text
    [Header("Text Untuk Score")]
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;

    [Header("Panel player WIN")]
    public GameObject panelWin;
    public TMP_Text playerWin;

    public static GameManager_Bot instance;
    public SceneManagement change;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        //txtPlayerScoreL.text = PlayerScoreL.ToString();
        //txtPlayerScoreR.text = PlayerScoreR.ToString();

        panelWin.SetActive(false);
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == BatasScore)
        {
            //Debug.Log("playerL win");
            panelWin.SetActive(true);
            playerWin.text = "YOU";
            playerWin.color = Color.blue;
            Invoke("ChangingScene", 1f);
        }
        else if (PlayerScoreR == BatasScore)
        {
            //Debug.Log("playerR win");
            panelWin.SetActive(true);
            playerWin.text = "BOT";
            playerWin.color = Color.red;
            Invoke("ChangingScene", 1f);
        }
    }

    //Method penyeleksi untuk menambah score
    public void Score(string wallID)
    {
        if (wallID == "LeftGoal")
        {
            PlayerScoreR = PlayerScoreR + 1; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
            ScoreCheck();
        }
        else if (wallID == "RightGoal")
        {
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }
    }

    public void ChangingScene()
    {
        //this.gameObject.SendMessage("ChangingScene", "MenuScene");
        change.ChangeScene("MainMenu");
    }
}

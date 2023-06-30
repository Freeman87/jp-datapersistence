using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public TMP_InputField InputField;

    public void Start()
    {
        HighScoreText.text = DataManager.Instance.GetHighScore();
        InputField.text = DataManager.Instance.HighScoreName;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName()
    {
        DataManager.Instance.PlayerName = InputField.text;
    }
}


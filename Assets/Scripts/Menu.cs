using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_InputField inputName;

    public void StartGame()
    {
        PersistanceManager.Instance.playerName = inputName.text;
        SceneManager.LoadScene("main");
    }
}

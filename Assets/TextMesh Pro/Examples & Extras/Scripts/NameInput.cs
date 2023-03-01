using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    private string playerName;

    public void LoadNextScene()
    {
        // Set the playerName in PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);
        // Load the next scene
        SceneManager.LoadScene("welcome_scene");
    }

    public void OnNameChanged(string name)
    {
        playerName = name;
    }
}
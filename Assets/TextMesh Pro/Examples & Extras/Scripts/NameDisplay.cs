using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public Text nameText;

    void Start()
    {
        // Get the player's name from PlayerPref and display it
        string playerName = PlayerPrefs.GetString("PlayerName");
        nameText.text = playerName;
    }
}
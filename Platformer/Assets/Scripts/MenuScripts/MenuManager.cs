using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    /*
     * Ova skripta je attachana na _MenuManager, a on je dodan na svaki button.
     * Buttoni pozivaju metode ove skripte kao OnClick evente!
     */
    public InputField inputField;

    public void LoadLevelScene()
    {
        Application.LoadLevel("LevelScene");
    }

    public void LoadCreateLevelScene()
    {
        Application.LoadLevel("CreateLevelScene");
    }

    public void LoadPlayCustomLevelScene()
    {
        if (this.ValidScene())
        {
            this.LoadLevelScene();
            return;
        }
        else
        {
            // neka button postane crven ako ne valja unesena struktura levela
            GameObject startButton = GameObject.Find("ButtonStart");
            var b = startButton.GetComponent<Image>();
            //b.color = Color.red;
            b.CrossFadeColor(Color.red, 0.5f, true, true);
        }
    }

    private bool ValidScene()
    {        
        string[] arr = inputField.text.Split('\n');
        int coins = 0;

        foreach (string s in arr)
        {
            if (s.Length != 40) return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != 'W' && s[i] != ' ' && s[i] != 'P' && s[i] != 'X' && s[i] != '|' && s[i] != '-' && s[i] != 'C' && s[i] != '_') 
                    return false;

                if (s[i] == 'C')
                    coins += 1;
            }
        }

        if (coins == 0) return false;

        LevelInfo.SetCustomLevel(arr, coins);
        return true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Application.LoadLevel("MainScene");
    }

    public void IspuniDefaultLevel()
    {
        string level = "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "___________________P____________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________\n" +
                        "________________________________________";

        inputField.text = level;
    }
}

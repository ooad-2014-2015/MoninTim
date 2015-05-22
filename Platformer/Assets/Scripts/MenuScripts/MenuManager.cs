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
            Debug.Log("Okej level!");
            this.SaveScene();
            this.LoadLevelScene();
            return;
        }
        Debug.Log("Nije ok!");
    }

    private bool ValidScene()
    {        
        string s = inputField.text;
        Debug.Log(s.Length + " => " + (s.Length / 40).ToString());
        if (s.Length / 40 != 19) return false;
        Debug.Log("Ide se vrtit!");
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != 'W' && s[i] != ' ' && s[i] != 'P' && s[i] != 'X' && s[i] != '|' && s[i] != '-') return false;
        }
        
        return true;
    }

    private void SaveScene()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public List<Word> wordsEasy;
    public List<Word> wordsMedium;
    public List<Word> wordsHard;
    private TMP_InputField inputField;
    public TextMeshProUGUI wordTMP;
    public string diff;


    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString("TypingState"));
        diff = PlayerPrefs.GetString("TypingSeed", "Easy");
        if (diff == "Easy" && PlayerPrefs.GetString("TypingState") == "Active")
        {
            wordTMP.text = wordsEasy[0].text;
        }
        if (diff == "Medium" && PlayerPrefs.GetString("TypingState") == "Active")
        {
            wordTMP.text = wordsMedium[0].text;
        }
        if (diff == "Hard" && PlayerPrefs.GetString("TypingState") == "Active")
        {
            wordTMP.text = wordsHard[0].text;
        }
        //nyari object inputfield buat diambil componentnya
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        inputField.Select();
    }

    public void tryInput(string word)
    {
        try{
            Input(word);
        }
        catch {
            wordTMP.text = "";
            PlayerPrefs.SetString("TypingState", "Cleared");
            ClearInput();
            inputField.ActivateInputField();
        }
    }

    public void Input(string word)
    {
        if (word.Equals(wordsEasy[0].text) && diff == "Easy")
        {
            wordsEasy.Remove(wordsEasy[0]);
            if (PlayerPrefs.GetString("TypingState") == "Active")
            {
                wordTMP.text = wordsEasy[0].text;
            }
        }
        if (word.Equals(wordsMedium[0].text) && diff == "Medium")
        {
            wordsMedium.Remove(wordsMedium[0]);
            if (PlayerPrefs.GetString("TypingState") == "Active")
            {
                wordTMP.text = wordsMedium[0].text;
            }
        }
        if (word.Equals(wordsHard[0].text) && diff == "Hard")
        {
            wordsHard.Remove(wordsHard[0]);
            if (PlayerPrefs.GetString("TypingState") == "Active")
            {
                wordTMP.text = wordsHard[0].text;
            }
        }
        ClearInput();
        inputField.ActivateInputField();
    }

    public void ClearInput()
    {
        inputField.text = ("");
    }
}

[System.Serializable]
public class Word
{
    public string text;
}

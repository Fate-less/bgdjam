using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public List<Word> words;
    private TMP_InputField inputField;
    public TextMeshProUGUI wordTMP;


    private void Start()
    {
        wordTMP.text = words[0].text;
        //nyari object inputfield buat diambil componentnya
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        inputField.Select();
    }

    public void Input(string word)
    {
        //input handling disini, di compare sm string yg ada di list
        if (word.Equals(words[0].text))
        {
            words.Remove(words[0]);
            wordTMP.text = words[0].text;
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

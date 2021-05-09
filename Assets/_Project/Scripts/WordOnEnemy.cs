using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordOnEnemy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WordTxt;
    [SerializeField] TextMeshProUGUI TypedWordTxt; // The current word that the player is typing

    private string word = "";

    public string Word
    {
        get => word; set
        {
            word = value;
            WordTxt.text = word;
        }
    }

    private void Start()
    {
        Word = WordDatabase.Instance.getRandomWord();
    }

    public void SetTypedText(string t)
    {
        TypedWordTxt.text = t;
    }
}

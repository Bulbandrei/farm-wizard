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
        string __typed = "<color=yellow>" + t + "</color>";
        string __final = Word.Substring(t.Length, Word.Length - t.Length);

        WordTxt.text = __typed + __final;
        //TypedWordTxt.text = t;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTyper : MonoBehaviour
{
    public string CurInput { get; set; } = "";

    public static Action OnTargetDestroyed;

    public void CheckTyping()
    {
        if (!string.IsNullOrEmpty(Input.inputString))
            TypeLetter(Input.inputString);
    }

    void TypeLetter(string l)
    {
        var curWord = StageManager.targetWord.Word;
        CurInput += l.ToLower();
        if (curWord.Equals(CurInput))
        {
            OnTargetDestroyed?.Invoke();
            CurInput = "";

        }
        else if (curWord.Substring(0, CurInput.Length).Equals(CurInput))
        {
            StageManager.targetWord.SetTypedText(CurInput);
        }
        else
        {
            CurInput = "";
            StageManager.targetWord.SetTypedText(CurInput);
            // TODO Add feedback
        }
    }
}

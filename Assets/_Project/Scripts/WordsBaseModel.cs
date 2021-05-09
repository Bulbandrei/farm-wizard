using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsBaseModel
{
    public Language Language { get; set; }
    public List<WordsListModel> WordsLists { get; set; } = new List<WordsListModel>();
}

[Serializable]
public class WordsListModel
{
    public WordType WordType;
    public List<string> Words;
}
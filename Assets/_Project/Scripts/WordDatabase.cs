using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordDatabase : MonoBehaviour
{
    public static WordDatabase Instance;
    public List<WordsBaseModel> WordsLists { get; set; } = new List<WordsBaseModel>();
    WordType curWordType = WordType.NONE;
    Language curLanguage = Language.EN;
    List<string> curList = new List<string>();

    private void Awake()
    {
        Instance = this;
        InitializeWordData();
    }

    public void InitializeWordData()
    {
        foreach (Language item in (Language[]) Enum.GetValues(typeof(Language)))
        {
            WordsBaseModel nl = new WordsBaseModel();
            nl.Language = item;

            nl.WordsLists.Add(JsonUtility.FromJson<WordsListModel>(Resources.Load<TextAsset>("Words/" + item + "_Feelings").text));
            nl.WordsLists.Add(JsonUtility.FromJson<WordsListModel>(Resources.Load<TextAsset>("Words/" + item + "_Food").text));

            WordsLists.Add(nl);
        }
    }

    public string getRandomWord()
    {
        WordType wordType = StageManager.isDay ? WordType.FOOD : WordType.FEELINGS;

        if (wordType != curWordType || curLanguage != GameCEO.CurLanguage)
        {
            curLanguage = GameCEO.CurLanguage;
            curWordType = wordType;

            curList = WordsLists.Where(w => w.Language == GameCEO.CurLanguage).ToList()
                    .Select(x => x.WordsLists.Where(y => y.WordType == wordType).First()).First().Words;
        }

        if (curList == null || curList != null && curList.Count == 0)
            return "Error";

        return curList[UnityEngine.Random.Range(0, curList.Count)];
    }
}

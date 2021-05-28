using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisplay : Display
{
    // Stats
    public TMPro.TextMeshProUGUI averageWpmLabel;
    public TMPro.TextMeshProUGUI maxWpmLabel;
    public TMPro.TextMeshProUGUI wordsTypedLabel;
    public TMPro.TextMeshProUGUI accuracyLabel;

    public override void Show(bool p_show, Action p_callback, float p_ratio)
    {
        averageWpmLabel.text = StageManager.avgWpm.ToString();
        maxWpmLabel.text = StageManager.maxWpm.ToString();
        wordsTypedLabel.text = StageManager.wordsTyped.Count.ToString();
        accuracyLabel.text = StageManager.accuracy.ToString() + "%";

        base.Show(p_show, p_callback, p_ratio);
    }
}

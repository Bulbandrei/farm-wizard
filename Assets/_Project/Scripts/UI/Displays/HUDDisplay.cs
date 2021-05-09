using UnityEngine;

public class HUDDisplay : Display
{
    public TMPro.TextMeshProUGUI hpLabel;

    public override void UpdateDisplay(int p_operation, int p_value, int p_data)
    {
        switch (p_operation)
        {
            case 0:
                hpLabel.text = "HP: " + p_value;
                break;
        }

        base.UpdateDisplay(p_operation, p_value, p_data);
    }
}

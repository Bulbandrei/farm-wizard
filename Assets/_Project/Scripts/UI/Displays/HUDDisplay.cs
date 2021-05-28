using UnityEngine;

public class HUDDisplay : Display
{
    public TMPro.TextMeshProUGUI hpLabel;
    public Transform dayNightArrow;

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

    public override void UpdateDisplay(int p_operation, object p_data)
    {
        switch (p_operation)
        {
            case 1:
                UpdateDayNightArrowAngle((float)p_data);
                break;
        }
        base.UpdateDisplay(p_operation, p_data);
    }

    void UpdateDayNightArrowAngle(float dayTime)
    {
        float angle = StageManager.isDay ? HelpExtensions.CalculateValueBasedOnRef(225, 45, dayTime, dayTime + StageManager.dayNightDuration, Time.time)
            : HelpExtensions.CalculateValueBasedOnRef(45, -135, dayTime, dayTime + StageManager.dayNightDuration, Time.time);

        dayNightArrow.localEulerAngles = new Vector3(0, 0, angle);
    }
}

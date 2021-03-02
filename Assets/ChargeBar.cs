using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{

    public Image ImageChargeBar;

    public float CurrentCharge = 0;

    private Color _oldColor;

    // Start is called before the first frame update
    void Start()
    {
        _oldColor = ImageChargeBar.color;
    }

    // Update is called once per frame
    void Update()
    {
        ImageChargeBar.fillAmount = CurrentCharge / 100;
    }

    public float GetCharge()
    {
        return CurrentCharge;
    }

    public void UseCharge()
    {
        CurrentCharge = 0;
        ImageChargeBar.color = _oldColor;
    }

    public void ChangeCharge(float amount)
    {
        CurrentCharge += amount;
        if(CurrentCharge > 100)
        {
            CurrentCharge = 100;
            ImageChargeBar.color = Color.red;
        }
    }
}

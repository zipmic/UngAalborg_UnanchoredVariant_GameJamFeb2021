using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{

    public Image ImageChargeBar;

    public float CurrentCharge = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ImageChargeBar.fillAmount = CurrentCharge / 100;
    }

    public void ChangeCharge(float amount)
    {
        CurrentCharge += amount;
        if(CurrentCharge > 100)
        {
            CurrentCharge = 100;
        }
    }
}

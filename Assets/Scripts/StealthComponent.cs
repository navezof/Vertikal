using UnityEngine;
using System.Collections;

public class StealthComponent : AComponent {

    bool bStealth;

    public float bStealthSpeed;

    void OnEnable()
    {
        PlayerController.OnStealthInput += StealthInput;
    }

    void OnDisable()
    {
        PlayerController.OnStealthInput -= StealthInput;
    }

    void StealthInput()
    {
        if (bStealth)
        {
            ExitStealth();
        }
        else
        {
            EnterStealth();
        }
    }

    public void EnterStealth()
    {
        print("Enter stealth");
        bStealth = true;
    }

    public void ExitStealth()
    {
        print("Exit stealth");
        bStealth = false;
    }

    public float ApplyStealthMod(float move)
    {
        if (bStealth)
            return move * bStealthSpeed;
        return move;
    }
}

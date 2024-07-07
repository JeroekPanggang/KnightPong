using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour
{
    public GameObject SelectModeMenu;
    public GameObject credit;

    public void ToggleHowToPlay()
    {
        if (SelectModeMenu != null)
        {
            bool isActive = SelectModeMenu.activeSelf;
            SelectModeMenu.SetActive(!isActive);
        }
    }

    public void ToggleCredit()
    {
        if (credit != null)
        {
            bool isCredit = credit.activeSelf;
            credit.SetActive(!isCredit);
        }
    }

    public void CloseHowToPlay()
    {
        if (SelectModeMenu != null)
        {
            SelectModeMenu.SetActive(false);
        }
    }

    public void CloseCredit()
    {
        if (credit != null)
        {
            credit.SetActive(false);
        }
    }

}

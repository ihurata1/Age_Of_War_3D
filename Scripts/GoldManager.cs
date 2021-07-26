using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    static int currentGold = 400;
    public static Text txtGold;

    public static void AddGold(int amount)
    {
        currentGold += amount;
        txtGold.text = currentGold.ToString();
    }
    private void Start()
    {

        txtGold = GameObject.Find("CurrentGold").GetComponent<Text>();
        txtGold.text = currentGold.ToString();

    }

    public static bool SpendGold(int amount)
    {
        if (currentGold - amount < 0)
        {
            ErrorManager.PrintError("You have not enough gold!");
            return false;

        }
        else
        {
            currentGold -= amount;
            txtGold.text = currentGold.ToString();
            return true;
        }
    }

}

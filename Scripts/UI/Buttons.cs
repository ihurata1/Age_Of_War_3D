using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public static int selectedCharacterIndex = 0;
    public static int selectedTurretIndex = 0;

    public void ChangeSelectedCharacter(int index)
    {
        selectedCharacterIndex = index;
    }
    public void ChangeSelectedTurret(int index)
    {
        selectedTurretIndex = index;
    }
}

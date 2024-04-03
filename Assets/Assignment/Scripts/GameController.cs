using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int enemyDeath;
    public static int MedEnemyDeath;
    public static int lives = 3;

    public static bool allEnemiesDead = false;
    public static bool allMedEnemiesDead = false;

    public static void IncreaseDeath(int amount)
    {
        enemyDeath += amount;
    }

    public static void IncreaseMedDeath(int amount)
    {
        MedEnemyDeath += amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public int money = 1000;
    public void endOfRoundFund(int waveNumber) { 
        money+= waveNumber+150;
    }
}

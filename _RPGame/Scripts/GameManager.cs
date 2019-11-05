using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameManager : MonoBehaviour
{
    public CharStatus[] charsPlayer = new CharStatus[1];
    public CharStatus[] charsEnemy = new CharStatus[1];

    private void Awake()
    {
        //mage = new CharStatus(CharStatus.Class.Mage, "Mage Player", 100, 15, 50, 20, 10, 5);
        //enemy = new CharStatus(CharStatus.Class.Mage, "Mage Enemy", 50, 10, 30, 15, 10, 10);
    }

    void Start()
    {
        // Player atancando!
        //charsPlayer[0].Attack(charsEnemy[0]);

        // Inimigo atancando!
        //charsEnemy[0].Attack(charsPlayer[0]);
    }

    void Update() { }
}



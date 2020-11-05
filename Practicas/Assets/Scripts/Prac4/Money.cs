﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money = 0;
    private int _minMoney;
    public GameObject moneyAware;
    // Start is called before the first frame update
    void Start()
    {
        _minMoney = 0;
        SetMoney(_minMoney);
    }

    private void SetMoney(int newMoney)
    {
        moneyAware.SendMessage(nameof(SetMoney), newMoney, SendMessageOptions.DontRequireReceiver);
    }

    public void ModifyMoney(int delta)
    {
        money += delta;
        if(money<=0)
            NotifyNoMoney();
        else 
            SetMoney(money);
    }
    private void NotifyNoMoney()
    {
        Debug.Log("No tienes dinero!");
    }
}
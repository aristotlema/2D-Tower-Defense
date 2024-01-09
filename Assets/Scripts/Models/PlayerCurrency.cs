using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency
{
    private int _startingCurrency;
    private int _currentCurrency;

    public PlayerCurrency(int startingCurrency)
    {
        this._startingCurrency = startingCurrency;
        ResetCurrency();
    }

    public int GetCurrentCurrency()
    {
        return _currentCurrency;
    }

    public void ResetCurrency()
    {
        this._currentCurrency = this._startingCurrency;
    }

    public void IncreaseCurrency(int amount)
    {
        this._currentCurrency += Mathf.Abs(amount);
    }

    public void DecreaseCurrency(int amount)
    {
        this._currentCurrency -= Mathf.Abs(amount);
    }
}

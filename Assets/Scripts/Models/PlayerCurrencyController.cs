using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencyController : MonoBehaviour
{
    [SerializeField] private int _startingCurrency;

    private PlayerCurrency _playerCurrency;

    [Header("Events")]
    [SerializeField] private GameEvent onCurrencyChange;

    private void Awake()
    {
        _playerCurrency = new PlayerCurrency(_startingCurrency);
    }
}

using System;
using UnityEngine;

public class DisableHUD : MonoBehaviour, IFinishObserver
{
    [SerializeField] private GameObject playerHUD;

    public void Execute() => DisablePlayerHUD();

    private void DisablePlayerHUD() => playerHUD.SetActive(false);
}

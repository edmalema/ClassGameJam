using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private GameObject ShopContainer;

    public void OnOpenShop()
    {
        if (ShopContainer.activeSelf == true)
        {
            ShopContainer.SetActive(false);
        }
        else
        {
            ShopContainer.SetActive(true);
        }
    }



}

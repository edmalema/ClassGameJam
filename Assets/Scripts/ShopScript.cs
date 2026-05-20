using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private GameObject ShopContainer;
    [SerializeField] private TextMeshProUGUI CoinUI;
    public float AssetValues = 0f;
    public int AssetCount = 0;
    public int Coins = 0;
    public static ShopScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnOpenShop()
    {
        if (ShopContainer.activeSelf == true)
        {
            ShopContainer.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            GetComponent<Movement>().CameraActive = true;
        }
        else
        {
            ShopContainer.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GetComponent<Movement>().CameraActive = false;
        }
    }


    public void BuyItem(string ItemName)
    {
        Debug.Log("baz");
        GetComponent<PlayerAttack>().Attack = Resources.Load("Prefabs/" + ItemName + "Primary", typeof(GameObject)) as GameObject;
        GetComponent<PlayerAttack>().SecondaryAttack = Resources.Load("Prefabs/" + ItemName + "Secondary", typeof(GameObject)) as GameObject;
    }

    private void Update()
    {
        CoinUI.text = AssetValues.ToString();
    }

}

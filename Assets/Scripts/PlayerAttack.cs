using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject Attack;
    public GameObject SecondaryAttack;

    [SerializeField] private Transform Origin;


    public void OnAttack()
    {
        InitAttack(Attack);
    }


    public void OnSecondaryAttack()
    {
        InitAttack(SecondaryAttack);
    }


    private void HitboxParameters(GameObject HurtBoxObj)
    {
        DeleteHitbox HurtboxHitbox = HurtBoxObj.GetComponent<DeleteHitbox>();

        HurtboxHitbox.transform.localPosition = new Vector3(HurtboxHitbox.PositionValue.x, HurtboxHitbox.PositionValue.y, 0f);

    }


    private void InitAttack(GameObject AttackType)
    {
        GameObject HurtBoxObj = Instantiate(AttackType, Vector3.zero, Origin.rotation, Origin);
        HitboxParameters(HurtBoxObj);
    }
    
}

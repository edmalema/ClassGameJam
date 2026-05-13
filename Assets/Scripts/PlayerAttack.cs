using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private GameObject Attack;
    [SerializeField] private Transform Origin;
    void Start()
    {
        
    }

    
    public void OnAttack()
    {
        InitAttack();
    }


    private void HitboxParameters(GameObject HurtBoxObj)
    {
        DeleteHitbox HurtboxHitbox = HurtBoxObj.GetComponent<DeleteHitbox>();

        HurtboxHitbox.transform.localPosition = new Vector3(HurtboxHitbox.PositionValue.x, HurtboxHitbox.PositionValue.y, 0f);

    }


    private void InitAttack()
    {
        GameObject HurtBoxObj = Instantiate(Attack, Vector3.zero, Quaternion.identity, Origin);
        HitboxParameters(HurtBoxObj);
    }
    
}

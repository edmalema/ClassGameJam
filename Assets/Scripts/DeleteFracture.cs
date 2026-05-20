using System.Collections;
using UnityEngine;

public class DeleteFracture : MonoBehaviour
{
    public float FractureValue;
    public WaitForSeconds Delay;

    private void Start()
    {
        StartCoroutine(DeleteFractureAfterTime());
    }

    IEnumerator DeleteFractureAfterTime()
    {
        yield return Delay;

        ShopScript.instance.AssetValues += FractureValue;
        ShopScript.instance.AssetCount += 1;

        Destroy(gameObject);
    }
}

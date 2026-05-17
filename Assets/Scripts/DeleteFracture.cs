using System.Collections;
using UnityEngine;

public class DeleteFracture : MonoBehaviour
{

    public WaitForSeconds Delay;

    private void Start()
    {
        StartCoroutine(DeleteFractureAfterTime());
    }

    IEnumerator DeleteFractureAfterTime()
    {
        yield return Delay;
        Destroy(gameObject);
    }
}

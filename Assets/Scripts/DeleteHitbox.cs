using UnityEngine;
using System.Collections;



public class DeleteHitbox : MonoBehaviour
{
    [SerializeField] private float Duration;
    public Vector2 PositionValue;


    void Start()
    {
        StartCoroutine(DeleteWithDelay());
    }

    private IEnumerator DeleteWithDelay()
    {
        yield return new WaitForSeconds(Duration);

        Destroy(gameObject);
    }


}
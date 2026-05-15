using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float Speed;
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}

using UnityEngine;

public class FractureMomentum : MonoBehaviour
{
    [SerializeField] private float explosionForce = 10;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float upwardModifier = 0.5f;

    private Fracture fracture;
    private Vector3 impactPoint;

    void Awake()
    {
        fracture = GetComponent<Fracture>();

        // Capture impact point when fracture starts
        fracture.callbackOptions.onFracture.AddListener(OnFractureStarted);

        // Apply force once fragments exist
        fracture.callbackOptions.onCompleted.AddListener(OnFractureCompleted);
    }

    void OnFractureStarted(Collider instigator, GameObject fracturedObject, Vector3 impact)
    {
        impactPoint = impact;
    }

    void OnFractureCompleted()
    {
        GameObject FractureContainer = GameObject.Find(gameObject.name + "Fragments");
        Rigidbody[] FractureChildren = FractureContainer.GetComponentsInChildren<Rigidbody>();
        // Fragments are children of the fractured object's parent
        // OpenFracture instantiates them in the scene — find them by tag or name
        foreach (var rb in FractureChildren)
        {
            rb.AddExplosionForce(
                explosionForce,
                impactPoint,
                explosionRadius,
                upwardModifier,
                ForceMode.Impulse
            );
        }
    }

}

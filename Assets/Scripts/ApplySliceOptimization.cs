using UnityEngine;

public class ApplySliceOptimization : MonoBehaviour
{
    private Renderer OriginRenderer;
    private Slice slice;
    private Fracture fracture;

    private float OriginVolume;
    [SerializeField] private float LowerSizeTreshold;
    [SerializeField] private float UpperSizeTreshold;
    [SerializeField] private float FractureValue;
    [SerializeField] private bool FractureMode;

    void Awake()
    {
        if (FractureMode)
        {
            fracture = GetComponent<Fracture>();
            OriginRenderer = GetComponent<Renderer>();
            Vector3 OriginSize = OriginRenderer.bounds.size;
            OriginVolume = OriginSize.x * OriginSize.y * OriginSize.z;
            fracture.callbackOptions.onCompleted.AddListener(OnFractureCompleted);
        }
        else
        {
            slice = GetComponent<Slice>();
            OriginRenderer = GetComponent<Renderer>();
            Vector3 OriginSize = OriginRenderer.bounds.size;
            OriginVolume = OriginSize.x * OriginSize.y * OriginSize.z;
            slice.callbackOptions.onCompleted.AddListener(OnSliceCompleted);
        }
        
    }

    void OnFractureCompleted()
    {
        GameObject FractureContainer = GameObject.Find(gameObject.name + "Fragments");
        FractureOptimizer OptimizerComponent = FractureContainer.AddComponent<FractureOptimizer>();
        OptimizerComponent.OriginVolume = OriginVolume;
        OptimizerComponent.LowerSizeTreshold = LowerSizeTreshold;
        OptimizerComponent.UpperSizeTreshold = UpperSizeTreshold;
        OptimizerComponent.FractureValue = FractureValue;
    }

    void OnSliceCompleted()
    {
        GameObject FractureContainer = GameObject.Find(gameObject.name + "Slices");
        FractureContainer.AddComponent<FractureOptimizer>();
        FractureContainer.GetComponent<FractureOptimizer>().OriginVolume = OriginVolume;
        FractureContainer.GetComponent<FractureOptimizer>().LowerSizeTreshold = LowerSizeTreshold;
        FractureContainer.GetComponent<FractureOptimizer>().UpperSizeTreshold = UpperSizeTreshold;
        FractureContainer.GetComponent<FractureOptimizer>().FractureValue = FractureValue;
    }
}

using UnityEngine;

public class ApplySliceOptimization : MonoBehaviour
{
    private Renderer OriginRenderer;
    private Slice slice;
    private float OriginVolume;
    [SerializeField] private float SizeTreshold;
    void Awake()
    {
        slice = GetComponent<Slice>();
        OriginRenderer = GetComponent<Renderer>();
        Vector3 OriginSize = OriginRenderer.bounds.size;
        OriginVolume = OriginSize.x * OriginSize.y * OriginSize.z;
        Debug.Log(OriginVolume);
        // Apply force once fragments exist
        slice.callbackOptions.onCompleted.AddListener(OnFractureCompleted);
    }

    void OnFractureCompleted()
    {
        GameObject FractureContainer = GameObject.Find(gameObject.name + "Slices");
        FractureContainer.AddComponent<SliceOptimizer>();
        FractureContainer.GetComponent<SliceOptimizer>().OriginVolume = OriginVolume;
        FractureContainer.GetComponent<SliceOptimizer>().SizeTreshold = SizeTreshold;

    }
}

using UnityEngine;

public class FractureOptimizer : MonoBehaviour
{
    public float OriginVolume;

    private int ChildCount = 0;

    public float LowerSizeTreshold;
    public float UpperSizeTreshold;
    public float FractureValue;
    public bool FractureMode;
    private bool Changed = false;

    private void Update()
    {
        Renderer[] ChildrenRenderer = GetComponentsInChildren<Renderer>(true);
        if (Changed)
        {
            ChildCount = ChildrenRenderer.Length;
            OnSliceCompleted(ChildrenRenderer);
            Changed = false;
        }

        if (ChildrenRenderer.Length > ChildCount)
        {
            Changed = true;
        }
    }

    void OnSliceCompleted(Renderer[] ChildrenRenderer)
    {
        foreach (var rend in ChildrenRenderer)
        {
            Vector3 size = rend.bounds.size;
            float volume = size.x * size.y * size.z;

            if (volume <= OriginVolume / LowerSizeTreshold || !rend.gameObject.activeInHierarchy)
            {
                Destroy(rend.gameObject);
            }

            if (volume <= OriginVolume / UpperSizeTreshold)
            {
                rend.gameObject.AddComponent<DeleteFracture>();
                rend.gameObject.GetComponent<DeleteFracture>().FractureValue = FractureValue;
                rend.gameObject.GetComponent<DeleteFracture>().Delay = new WaitForSeconds(UnityEngine.Random.Range(20f, 30.0f));
            }
        }
    }
}

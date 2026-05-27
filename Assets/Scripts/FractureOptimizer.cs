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
        Renderer[] ChildrenRenderer = null;
        ChildrenRenderer = GetComponentsInChildren<Renderer>(true);
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
        int i = 0;
        int x = 0;
        foreach (var rend in ChildrenRenderer)
        {
            
            Vector3 size = rend.bounds.size;
            float volume = size.x * size.y * size.z;


            if (volume <= OriginVolume / LowerSizeTreshold || !rend.gameObject.activeInHierarchy)
            {
                Destroy(rend.gameObject);
            }
            else if (volume <= OriginVolume / UpperSizeTreshold)
            {
                Debug.Log("Omg bruh");

                if (rend.GetComponent<DeleteFracture>() != null) continue;
                DeleteFracture DeleteScript = rend.gameObject.AddComponent<DeleteFracture>();
                DeleteScript.FractureValue = FractureValue;
                DeleteScript.Delay = new WaitForSeconds(UnityEngine.Random.Range(20f, 30.0f));
            }
            else
            {
                Debug.Log("Bleh");
            }
        }
    }
}

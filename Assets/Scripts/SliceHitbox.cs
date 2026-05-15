using UnityEngine;

public class SliceHitbox : MonoBehaviour
{
    private void Start()
    {
        var mesh = this.GetComponent<MeshFilter>().sharedMesh;
        var center = mesh.bounds.center;
        var extents = mesh.bounds.extents;

        extents = new Vector3(extents.x * this.transform.localScale.x,
                              extents.y * this.transform.localScale.y,
                              extents.z * this.transform.localScale.z);

        // Cast a ray and find the nearest object
        RaycastHit[] hits = Physics.BoxCastAll(this.transform.position, extents, this.transform.forward, this.transform.rotation, extents.z);

        foreach (RaycastHit hit in hits)
        {
            var obj = hit.collider.gameObject;
            var sliceObj = obj.GetComponent<Slice>();

            if (sliceObj != null)
            {
                sliceObj.GetComponent<MeshRenderer>()?.material.SetVector("CutPlaneOrigin", Vector3.positiveInfinity);
                sliceObj.ComputeSlice(this.transform.up, this.transform.position);
            }
        }
    }
}

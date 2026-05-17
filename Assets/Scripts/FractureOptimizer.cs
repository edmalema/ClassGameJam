using System.Collections;
using UnityEngine;

public class FractureOptimizer : MonoBehaviour
{

    private Fracture fracture;

    void Awake()
    {
        fracture = GetComponent<Fracture>();
        // Apply force once fragments exist
        fracture.callbackOptions.onCompleted.AddListener(OnFractureCompleted);
    }



    void OnFractureCompleted()
    {
        GameObject FractureContainer = GameObject.Find(gameObject.name + "Fragments");
        Renderer[] FractureChildren = FractureContainer.GetComponentsInChildren<Renderer>();
        // Fragments are children of the fractured object's parent
        // OpenFracture instantiates them in the scene — find them by tag or name
        foreach (var rend in FractureChildren)
        {
            rend.gameObject.AddComponent<DeleteFracture>();
            rend.gameObject.GetComponent<DeleteFracture>().Delay = new WaitForSeconds(UnityEngine.Random.Range(20f, 30.0f));

        }
    }


}

using UnityEngine;

public class MSSureHit : MonoBehaviour
{
    [SerializeField] private GameObject CleavePrefab;
    [SerializeField] private float Range;


    private void Update()
    {
        float x = Random.Range(-Range, Range);
        float y = Random.Range(-Range, Range);
        float z = Random.Range(-Range, Range);


        Vector3 randomPos = new Vector3(x, y, z);
        Quaternion randomRot = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        Vector3 Size = new Vector3(5, 5, 5);


        GameObject Cleave = Instantiate(CleavePrefab);
        Cleave.transform.position = randomPos;
        Cleave.transform.rotation = randomRot;
        Cleave.transform.localScale = Size;
    }
}

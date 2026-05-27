using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
public class StartDomain : MonoBehaviour
{
    [SerializeField] private Color FogColor;
    private float FogDensity = 0f;
    [SerializeField] private float FogEndDensity;
    [SerializeField] private float FogAnimationDuration;


    [SerializeField] private GameObject DomainPrefab;
    [SerializeField] private GameObject StartRenderVolume;
    private ColorAdjustments VolumeColorAdjustments;
    [SerializeField] private Gradient colorGradient;


    private float FogT = 0f;

    void Start()
    {
        RenderSettings.fog = true;

        RenderSettings.fogColor = FogColor;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = FogDensity;
        StartRenderVolume.GetComponent<Volume>().profile.TryGet<ColorAdjustments>(out VolumeColorAdjustments);
    }

    private void Update()
    {
        FogT += Time.deltaTime / FogAnimationDuration;
        if (FogT > 1.2f)
        {
            Instantiate(DomainPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        FogDensity = FogEndDensity * FogLerp(FogT);

        Color mappedColor = colorGradient.Evaluate(FogLerp(FogT));
        VolumeColorAdjustments.colorFilter.value = mappedColor;
    }


    private float FogLerp(float t)
    {
        return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
    }

}

using UnityEngine;

[ExecuteAlways]
public class LightController : MonoBehaviour
{
    public float dayLength = 120f;
    [Range(0f, 1f)] public float timeOfDay;

    public Light sunLight;
    public Light moonLight;
    public float sunBaseIntensity = 1.2f;
    public float moonBaseIntensity = 0.3f;

    public Gradient sunColor;
    public Gradient ambientColor;

    //public Material skyboxMat;
    //public Gradient skyTint;

    private float _timeRate;

    void Start()
    {
        _timeRate = 1f / dayLength;
    }

    void Update()
    {
        timeOfDay += _timeRate * Time.deltaTime;
        if (timeOfDay >= 1f) timeOfDay = 0f;

        UpdateLighting();
    }

    void UpdateLighting()
    {
        float sunAngle = timeOfDay * 360f - 90f;
        sunLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
        moonLight.transform.rotation = Quaternion.Euler(sunAngle + 180f, 170f, 0f);

        float dot = Mathf.Clamp01(Vector3.Dot(sunLight.transform.forward, Vector3.down));
        sunLight.intensity = Mathf.Lerp(0f, sunBaseIntensity, dot);
        moonLight.intensity = Mathf.Lerp(moonBaseIntensity, 0f, dot);

        if (sunColor != null) sunLight.color = sunColor.Evaluate(dot);
        if (ambientColor != null) RenderSettings.ambientLight = ambientColor.Evaluate(dot);

        //if (skyboxMat != null && skyTint != null)
        //{
        //    skyboxMat.SetColor("_Tint", skyTint.Evaluate(dot));
        //    DynamicGI.UpdateEnvironment();
        //}
    }
}

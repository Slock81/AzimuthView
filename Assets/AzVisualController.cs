using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using TMPro;

public class AzVisualController : MonoBehaviour
{
    public Triangle azTriangle;
    public Transform torpedoTransform;
    private Transform triangleTrans;
    public TMP_Text azText;
    [SerializeField] private float radius;
    [SerializeField] private float azimuth;
    //Debug
    [Range(0, 360)] public float deg = 0;
    //We want 0 to be like a clock

    // Start is called before the first frame update
    void Start()
    {
        radius = azTriangle.transform.localPosition.y;
        triangleTrans = azTriangle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float rad = Mathf.Deg2Rad * -(deg - 90);
        float x = radius * Mathf.Cos(rad);
        float y = radius * Mathf.Sin(rad);
        Vector3 pos = new Vector3(x, y, 0);
        triangleTrans.localPosition = pos;

        Quaternion triangleQuat = Quaternion.Euler(0, 0, -deg);
        triangleTrans.rotation = triangleQuat;

        Quaternion torpQuat = Quaternion.Euler(0, 0, -deg + 180);
        torpedoTransform.rotation = torpQuat;

        deg = isPort ? azimuth : (360 - azimuth);

    }


    public void azimuthUpdated(string p_azStr)
    {
        float.TryParse(p_azStr, out azimuth);
        azText.text = "" + azimuth;
    }

    public bool isPort;
    public void setIsPort(bool p_on)
    {
        isPort = p_on;
    }


}

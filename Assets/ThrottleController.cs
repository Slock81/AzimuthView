using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class ThrottleController : MonoBehaviour
{
    [SerializeField] private int maxRpm;
    [SerializeField] private int currRpm;
    [SerializeField] private int perc;

    [Header("UI Hooks")]
    public TMPro.TMP_Text rpmText;
    public Rectangle greyRect;
    public Rectangle greenRect;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rpmText.text = "" + currRpm;
        if (maxRpm == 0)
        {
            perc = 0;
        }
        else
        {
            perc = Mathf.RoundToInt(100.0f * (currRpm / (float)maxRpm));
        }

        float ySize = greyRect.Height;
        float xSize = ySize * (perc / 100.0f);
        greenRect.Height = xSize;
    }

    public void currentRpmUpdated(string p_rpm)
    {
        int.TryParse(p_rpm, out currRpm);
    }

    public void maxRpmUpdated(string p_maxRpm)
    {
        int.TryParse(p_maxRpm, out maxRpm);
    }
}

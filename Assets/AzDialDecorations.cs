using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

[ExecuteAlways]
public class AzDialDecorations : ImmediateModeShapeDrawer
{
    public Disc disc;
    public int degSpacing = 30;

    [Range(0, 10)] public float thicknessPx;
    [Range(0, 64)] public float fontSize = 12;
    public Color lineColor = Color.black;

    [Range(0, 10)] public float textOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void DrawShapes(Camera cam)
    {

        float w = disc.Thickness;
        float offset = w / 2.0f;
        float r = disc.Radius - offset;

        using (Draw.Command(cam))
        {

            // set up static parameters. these are used for all following Draw.Line calls
            Draw.LineGeometry = LineGeometry.Volumetric3D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness = thicknessPx; // 4px wide

            // set static parameter to draw in the local space of this object
            Draw.Matrix = transform.localToWorldMatrix;

            //Right Side
            for (int deg = 0; deg <= 180; deg += degSpacing)
            {

                float rad = Mathf.Deg2Rad * -(deg - 90);
                float startX = r * Mathf.Cos(rad);
                float startY = r * Mathf.Sin(rad);
                float length = getDegLength(deg);
                float endX = (r + length) * Mathf.Cos(rad);
                float endY = (r + length) * Mathf.Sin(rad);
                Draw.Line(new Vector2(startX, startY), new Vector2(endX, endY), lineColor);


                if (deg % 30 == 0)
                {
                    float textX = (r + length + textOffset) * Mathf.Cos(rad);
                    float textY = (r + length + textOffset) * Mathf.Sin(rad);
                    Draw.Text(new Vector2(textX, textY), "" + deg, fontSize, lineColor);
                }
            }

            //Left Side
            for (int deg = 0; deg <= 180; deg += degSpacing)
            {
                float revDeg = 360 - deg;
                float rad = Mathf.Deg2Rad * -(revDeg - 90);
                float startX = r * Mathf.Cos(rad);
                float startY = r * Mathf.Sin(rad);
                float length = getDegLength(deg);
                float endX = (r + length) * Mathf.Cos(rad);
                float endY = (r + length) * Mathf.Sin(rad);
                Draw.Line(new Vector2(startX, startY), new Vector2(endX, endY), lineColor);


                if (deg != 0 && deg != 180 && deg % 30 == 0)
                {
                    float textX = (r + length + textOffset) * Mathf.Cos(rad);
                    float textY = (r + length + textOffset) * Mathf.Sin(rad);
                    Draw.Text(new Vector2(textX, textY), "" + deg, fontSize, lineColor);
                }
            }
        }
    }

    public float getDegLength(float p_deg)
    {
        if (p_deg % 30 == 0)
        {
            return disc.Thickness * 1.5f;
        }
        else if (p_deg % 10 == 0)
        {
            return disc.Thickness;
        }
        else
        {
            return disc.Thickness / 2.0f;
        }
    }
}

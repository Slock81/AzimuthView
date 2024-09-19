using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
[ExecuteAlways]
public class ThrottleDecorations : ImmediateModeShapeDrawer
{
    public int[] percsToDraw = new int[] { 0, 25, 50, 75, 100 };
    public Rectangle rect;
    public Vector2 offset;
    public Vector2 fontOffset;

    [Header("Visual Controls")]
    [Range(0, 10)] public float thicknessPx;
    [Range(0, 64)] public float fontSize = 12;
    public Color lineColor = Color.black;
    public override void DrawShapes(Camera cam)
    {
        float height = rect.Height;
        float width = rect.Width;
        offset.x = (-width / 2.0f);
        offset.y = (-height / 2.0f);

        using (Draw.Command(cam))
        {

            // set up static parameters. these are used for all following Draw.Line calls
            Draw.LineGeometry = LineGeometry.Volumetric3D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness = thicknessPx; // 4px wide

            // set static parameter to draw in the local space of this object
            Draw.Matrix = transform.localToWorldMatrix;

            float startX = 0;
            float endX = width;
            float startY = 0;
            float endY = height;
            // draw lines
            for (int i = 0; i < percsToDraw.Length; i++)
            {
                int percInt = percsToDraw[i];
                float perc = (float)(percInt / 100.0f);
                float y = (endY - startY) * perc;
                Vector2 start = new Vector2(startX, y);
                Vector2 end = new Vector2(endX, y);
                Draw.Line(start + offset, end + offset, lineColor);

                Draw.Text(start + offset + fontOffset, "" + percInt, fontSize, lineColor);
            }

            Draw.Line(offset, offset + new Vector2(0, height), lineColor);
            Draw.Line(offset + new Vector2(width, 0), offset + new Vector2(width, height), lineColor);
        }

    }

}

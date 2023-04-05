using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public int Segments = 10;


    public void Draw(Vector3 a, Vector3 b, float lenght)
    {
        LineRenderer.enabled = true;

        LineRenderer.positionCount = 2;
        LineRenderer.SetPosition(0, a);
        LineRenderer.SetPosition(1, b);

        float interpolant = Vector3.Distance(a, b) / lenght;
        float offset = Mathf.Lerp(lenght / 2f, 0f, interpolant);

        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        LineRenderer.positionCount = Segments + 1;
        for (int i = 0; i < Segments + 1; i++)
        {
            LineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float)i / Segments));
        }
    }


    public void Hide()
    {
        LineRenderer.enabled = false;
    }
}

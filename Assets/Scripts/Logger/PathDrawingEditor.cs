using UnityEngine;

//[CustomEditor(typeof(PathDrawing))]
public class DrawLineEditor //: Editor
{
    // draw lines between a chosen game object
    // and a selection of added game objects

    void OnSceneGUI()
    {
        // get the chosen game object
        //PathDrawing t = target as PathDrawing;

        /*if (t == null || t.vectorsToDraw == null)
            return;

        //Handles.DrawLines(t.vectorsToDraw);

        Handles.color = Color.red;
        Handles.DrawPolyLine(t.vectorsToDraw);*/
        /*
        // iterate over game objects added to the array...
        for (int i = 1; i < t.vectorsToDraw.Length; i++)
        {
            // ... and draw a line between them
            if (t.vectorsToDraw[i] != null && t.vectorsToDraw[i - 1] != null) {
                Handles.DrawLine(t.vectorsToDraw[i - 1], t.vectorsToDraw[i]);
            }
        }*/
    }
}
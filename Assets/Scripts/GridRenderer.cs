using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GridRenderer : MonoBehaviour
{

    //public GameObject plane;
    public Grid grid;

    public Vector3Int Size = new Vector3Int(10,10,10);

    public bool showMain = true;
    public bool showSub = false;

    private Material lineMaterial;

    public Color mainColor = new Color(0f, 1f, 0f, 1f);
    public Color subColor = new Color(0f, 0.5f, 0f, 1f);

    void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            var shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    void OnRenderObject()
    {
        if(this.grid == null) return;
        CreateLineMaterial();
        // set the current material

        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.LINES);

        // if (showSub)
        // {
        //     GL.Color(subColor);

        //     //Layers
        //     for (float j = 0; j <= gridSizeY; j += smallStep)
        //     {
        //         //X axis lines
        //         for (float i = 0; i <= gridSizeZ; i += smallStep)
        //         {
        //             GL.Vertex3(startX, startY + j, startZ + i);
        //             GL.Vertex3(startX + gridSizeX, startY + j, startZ + i);
        //         }

        //         //Z axis lines
        //         for (float i = 0; i <= gridSizeX; i += smallStep)
        //         {
        //             GL.Vertex3(startX + i, startY + j, startZ);
        //             GL.Vertex3(startX + i, startY + j, startZ + gridSizeZ);
        //         }
        //     }

        //     //Y axis lines
        //     for (float i = 0; i <= gridSizeZ; i += smallStep)
        //     {
        //         for (float k = 0; k <= gridSizeX; k += smallStep)
        //         {
        //             GL.Vertex3(startX + k, startY, startZ + i);
        //             GL.Vertex3(startX + k, startY + gridSizeY, startZ + i);
        //         }
        //     }
        // }

        if (showMain)
        {
            GL.Color(mainColor);

            Vector3 cellSize = Grid.Swizzle(this.grid.cellSwizzle, this.grid.cellSize);
            //Layers
            for (int i = 0; i <= this.Size.y; i++)
            {
                float y = i*cellSize.y;
                float x = this.Size.x * cellSize.x;
                float z = 0f;
                
                //X axis lines
                for (int j = 0; j <= this.Size.z; j++)
                {
                    z = j*cellSize.z;

                    GL.Vertex3(-x, y, +z);
                    GL.Vertex3(+x, y, +z);

                    GL.Vertex3(-x, y, -z);
                    GL.Vertex3(+x, y, -z);
                }

                z = this.Size.z * cellSize.z;
                for (int j = 0; j <= this.Size.x; j++)
                {
                    x = j*cellSize.x;

                    GL.Vertex3(+x, y, -z);
                    GL.Vertex3(+x, y, +z);

                    GL.Vertex3(-x, y, -z);
                    GL.Vertex3(-x, y, +z);
                }
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}
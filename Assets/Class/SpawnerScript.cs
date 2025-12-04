using UnityEngine;
using UnityEngine.UIElements;

public struct CubeData
{
    public CubeData(float position, Color color)
    {
        Position = position;
        Color = color;
    }

    public float Position { get; set; }
    public Color Color { get; set; }
}

public class SpawnerScript : MonoBehaviour
{
    public CubeData[,] cubes = {
        {
            new CubeData( 0f, Color.white),
            new CubeData( 1.0f, Color.white),
            new CubeData( 2.0f, Color.black),
            new CubeData( 3.0f, Color.white),
            new CubeData( 4.0f, Color.white),
        },
        {
            new CubeData( 0f, Color.white),
            new CubeData( 1.0f, Color.black),
            new CubeData( 2.0f, Color.black),
            new CubeData( 3.0f, Color.black),
            new CubeData( 4.0f, Color.white),
        },
        {
            new CubeData( 0f, Color.black),
            new CubeData( 1.0f, Color.black),
            new CubeData( 2.0f, Color.black),
            new CubeData( 3.0f, Color.black),
            new CubeData( 4.0f, Color.black),
        },
        {
            new CubeData( 0f, Color.white),
            new CubeData( 1.0f, Color.white),
            new CubeData( 2.0f, Color.black),
            new CubeData( 3.0f, Color.white),
            new CubeData( 4.0f, Color.white),
        },
        {
            new CubeData( 0f, Color.white),
            new CubeData( 1.0f, Color.white),
            new CubeData( 2.0f, Color.black),
            new CubeData( 3.0f, Color.white),
            new CubeData( 4.0f, Color.white),
        },
    };

    void Start()
    {
        for (int i = 0; i < cubes.GetLength(0); ++i)
        {
            for (int j = 0; j < cubes.GetLength(1); ++j) {
                Debug.Log("pos: " + i + " " + j);
                MeshRenderer cube = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<MeshRenderer>();
                cube.transform.position = new Vector3(cubes[i,j].Position, i, 0);
                cube.material.color = cubes[i, j].Color;
            }
        }        
    }

    void Update()
    {
        
    }
}

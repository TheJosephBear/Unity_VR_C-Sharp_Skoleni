using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class PerlinTerrainGenerator : MonoBehaviour {

    [Header("Rozmìry terénu")]
    public int width = 256;     // Šíøka heightmapy (osa X)
    public int height = 256;    // Délka heightmapy (osa Z)
    public float depth = 20f;   // Maximální výška terénu v metrech (osa Y)

    [Header("Nastavení Perlin Noise")]
    public float scale = 20f;   // Mìøítko šumu (vìtší = jemnìjší terén)
    public int seed = 0;        // Seed pro náhodnost (stejný seed = stejný terén)
    public Vector2 offset;      // Posun v Perlin Noise prostoru

    private Terrain terrain;

    void Start() {
        terrain = GetComponent<Terrain>();

        GenerateTerrain();
    }

    private void Update() {
        // Volám v Updatu, aby šly vidìt zmìny v runtime
     //   GenerateTerrain();
    }

    void GenerateTerrain() {
        TerrainData terrainData = terrain.terrainData;

        // Nastavení fyzické velikosti terénu ve svìtì (X, Y, Z)
        terrainData.size = new Vector3(width, depth, height);

        // Náhodný offset – posune "kameru" v Perlin Noise prostoru
        // Díky seedu je offset pokaždé stejný
        System.Random prng = new System.Random(seed);

        offset.x = prng.Next(-100000, 100000);
        offset.y = prng.Next(-100000, 100000);

        // Vygenerování výšek - perlin noise
        float[,] heights = GenerateHeights();
        terrainData.SetHeights(0, 0, heights);
    }

    float[,] GenerateHeights() {
        // 2D pole výšek (hodnoty 0–1)
        float[,] heights = new float[width, height];

        // Smyèka pøes každý bod heightmapy
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                // Normalizace souøadnice X do rozsahu 0–1
                // (float)x / width
                float xNormalized = (float)x / width;

                // Normalizace souøadnice Y do rozsahu 0–1
                float yNormalized = (float)y / height;

                // Pøepoèet do Perlin Noise prostoru:
                // - scale urèuje "zoom"
                // - offset posouvá vzorek v šumovém prostoru
                float xCoord = xNormalized * scale + offset.x;
                float yCoord = yNormalized * scale + offset.y;

                // PerlinNoise vrací hodnotu 0–1
                float noiseValue = Mathf.PerlinNoise(xCoord, yCoord);

                // Uložení výšky
                heights[x, y] = noiseValue;
            }
        }

        return heights;
    }
}

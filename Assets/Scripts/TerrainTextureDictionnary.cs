using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainTextureDictionnary : MonoBehaviour {
    public static string[] Textures { get; private set; }

	// Use this for initialization
	void Start () {
        Terrain terrain = Terrain.activeTerrain;
        TerrainData terrainData = terrain.terrainData;
        SplatPrototype[] splatPrototypes = terrainData.splatPrototypes;
        Textures = new string[splatPrototypes.Length];
        for (int i = 0; i < splatPrototypes.Length; i++) {
            Textures[i] = splatPrototypes[i].texture.ToString();
        }
    }

}

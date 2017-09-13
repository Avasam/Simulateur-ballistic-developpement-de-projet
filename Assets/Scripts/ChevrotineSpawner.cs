using UnityEngine;

public class ChevrotineSpawner : MonoBehaviour {
    public int shotQuantity = 5;

	// Use this for initialization
	void Start () {
        GameObject shotPrefab = this.gameObject.transform.GetChild(0).gameObject;
        for (int i = 1; i < shotQuantity; i++) {
            GameObject shot = Instantiate(shotPrefab, this.transform);
            shot.transform.position += new Vector3(Random.Range(-.05f, .05f), Random.Range(-.05f, .05f), Random.Range(-.05f, .05f));
            shot.name = "Shot" + i;
        }
    }

}

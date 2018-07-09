
using UnityEngine;

public class DeactivateObjectsOnGameStart : MonoBehaviour {

    [SerializeField] private GameObject[] gameObjects;
	
    // Use this for initialization
	void Start () {
        foreach (GameObject item in gameObjects)
        {
            item.SetActive(false);
        }
	}
	
	
}

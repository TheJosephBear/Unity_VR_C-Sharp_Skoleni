using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public float StartingZPosition = 30;
    public float SpaceBetweenPieces = 15;
    public float PieceSpeed = 5;
    public List<GameObject> Pieces = new List<GameObject>();
    
    void Start() {
        InvokeRepeating("SpawnPiece", 0f, SpaceBetweenPieces);
    }

    void SpawnPiece() {
        GameObject pieceToSpawn = Pieces[Random.Range(0, Pieces.Count-1)];

        Instantiate(pieceToSpawn, new Vector3(0, 0, StartingZPosition), Quaternion.identity);
        pieceToSpawn.GetComponent<Prekazka>().speed = PieceSpeed;
    }


}

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {


	public GameObject enemyPrefab;
	public float width=10f;
	public float height=5f;
	public float positionY=3f;
	public float speed=5f;
	public float spawnDelay=0.5f;


	private bool movingRight=true;
	private float xmin;
	private float xmax;

	void Start () {

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x;
		xmax = rightmost.x;

		SpawnUntilFull ();
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position+new Vector3(0,positionY,0), new Vector3 (width, height, 0));
	}
	// Update is called once per frame
	void Update () {

		if (movingRight) {
			transform.position+=new Vector3(speed*Time.deltaTime,0f,0f);
		}else {
			transform.position+=new Vector3(-speed*Time.deltaTime,0f,0f);
		}
		float rightEdgeOfFormation=transform.position.x+(0.5f*width);
		float leftEdgeOfFormation=transform.position.x-(0.5f*width);
		if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight=false;
		}
		if (AllMembersDead ()) {
			Debug.Log ("Empty formation");
			SpawnUntilFull ();
		}


	}
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount>0){
				return false;
			}

		}
		return true;
	}
	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount==0){
				return childPositionGameObject;
			}
			
		}
		return null;
	
	}
	void RespawnEnemies(){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition ()){
		Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
}

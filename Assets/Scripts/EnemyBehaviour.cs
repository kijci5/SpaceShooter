using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject enemyLaser;
	public float laserEnemySpeed = 5;
	public float health=150;
	public float shotsPerSeconds=0.5f;
	public int scoreValue=150;
	public AudioClip laserSound,dieSound;

    [SerializeField] PowerUp[] powerUps;

    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityGem1 = 10;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityGem2 = 10;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityGem3 = 10;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityGem4 = 10;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityBulletUpgrade = 2;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityShipUpgrade = 2;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityAutoFire = 2;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityBulletSpeed = 2;
    [Tooltip("probability 1:[your number] bigger number, lower probability")]
    [SerializeField] int probabilityShipSpeed = 2;


    void OnTriggerEnter2D(Collider2D collider){
		Projectile missile=collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health-=missile.GetDamage();
			missile.Hit ();
			if(health<=0){
				ScoreKeeper.points+=scoreValue;
				AudioSource.PlayClipAtPoint(dieSound,transform.position);
                DropPowerUp();
				Destroy (gameObject);
			}
		}
	}
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire ();
		}
	}
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3 (0, -1, 0);
		GameObject projectile = Instantiate(enemyLaser,startPosition,Quaternion.identity) as GameObject;
		projectile.GetComponent<Rigidbody2D>().velocity=new Vector3(0,-laserEnemySpeed,0);

		AudioSource.PlayClipAtPoint (laserSound, transform.position);
		
	}
    void DropPowerUp() {
        int rangeGem1 = Random.Range(1, probabilityGem1+1);
        if (rangeGem1 == 1) { Instantiate(powerUps[0], transform.position, Quaternion.identity); }

        int rangeGem2 = Random.Range(1, probabilityGem2 + 1);
        if (rangeGem2 == 2) { Instantiate(powerUps[1], transform.position, Quaternion.identity); }

        int rangeGem3 = Random.Range(1, probabilityGem3 + 1);
        if (rangeGem3 == 3) { Instantiate(powerUps[2], transform.position, Quaternion.identity); }

        int rangeGem4 = Random.Range(1, probabilityGem4 + 1);
        if (rangeGem4 == 1) { Instantiate(powerUps[3], transform.position, Quaternion.identity); }

        int rangeBulletUpgrade = Random.Range(1, probabilityBulletUpgrade + 1);
        if (rangeBulletUpgrade == 2) { Instantiate(powerUps[4], transform.position, Quaternion.identity); }

        int rangeShipUpgrade = Random.Range(1, probabilityShipUpgrade + 1);
        if (rangeShipUpgrade == 3) { Instantiate(powerUps[5], transform.position, Quaternion.identity); }

        int rangeAutoFire = Random.Range(1, probabilityAutoFire + 1);
        if (rangeAutoFire == 1) { Instantiate(powerUps[6], transform.position, Quaternion.identity); }

        int rangeBulletSpeed = Random.Range(1, probabilityBulletSpeed + 1);
        if (rangeBulletSpeed == 2) { Instantiate(powerUps[7], transform.position, Quaternion.identity); }

        int rangeShipSpeed = Random.Range(1, probabilityShipSpeed + 1);
        if (rangeShipSpeed == 3) { Instantiate(powerUps[8], transform.position, Quaternion.identity); }
    }
}

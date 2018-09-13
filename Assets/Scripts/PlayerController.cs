using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static int bulletState=0;
    public static int spriteState = 0;

    public GameObject[] laserPrefabs;
    public float laserSpeed;
    public float firingRate = 0.6f;
    public float health = 150;
    public Sprite[] playerSprites;
    public bool autoFire = false;
    public float speed=15f;

    [SerializeField] float paddling=1f;
    [SerializeField] AudioClip fireSound, deathSound;

    private GameObject currentLaser;
    private SpriteRenderer spriteRenderer;

	float Xmin;
	float Xmax;
	void Start()
	{
        bulletState = 0;
        spriteState = 0;

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Xmin = leftmost.x+paddling;
		Xmax = rightmost.x-paddling;


        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	void Update ()
    {

        spriteRenderer.sprite = playerSprites[spriteState];

        currentLaser = laserPrefabs[bulletState];

        Move();
        DealingWithAutofire();

    }

    private void DealingWithAutofire()
    {
        if (!autoFire && Input.GetKeyDown(KeyCode.Space))
        { Fire(); }
        else if (autoFire)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { InvokeRepeating("Fire", 0.000001f, firingRate); }
            else if(Input.GetKeyUp(KeyCode.Space))
            { CancelInvoke("Fire");}
        }        
    }

    void Move()
	{
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position+=new Vector3(-speed*Time.deltaTime,0f,0f);

		}else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position+=new Vector3(speed*Time.deltaTime,0f,0f);

		}
		float newX = Mathf.Clamp (transform.position.x, Xmin, Xmax);
		transform.position=new Vector3(newX,transform.position.y,transform.position.z);	
	}
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint(deathSound,transform.position);
				Destroy (gameObject);
				LevelManager man=GameObject.Find ("LevelManager").GetComponent<LevelManager>();
				man.LoadLevel("Win Screen");
			}
		}
	}
void Fire(){
        if (bulletState < 2)
        {
            Vector3 startPosition = transform.position + new Vector3(0, 0.5f, 0);
            GameObject laser = Instantiate(currentLaser, startPosition, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
        else if(bulletState==2)
        {
            Vector3 startPosition1 = transform.position + new Vector3(0.1f, 0.5f, 0);
            Vector3 startPosition2 = transform.position + new Vector3(-0.1f, 0.5f, 0);

            GameObject laser1 = Instantiate(currentLaser, startPosition1, Quaternion.identity) as GameObject;
            GameObject laser2 = Instantiate(currentLaser, startPosition2, Quaternion.identity) as GameObject;

            laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
        else if (bulletState == 3)
        {
            Vector3 startPosition1 = transform.position + new Vector3(0.2f, 0.5f, 0);
            Vector3 startPosition2 = transform.position + new Vector3(0, 0.5f, 0);
            Vector3 startPosition3 = transform.position + new Vector3(-0.2f, 0.5f, 0);

            GameObject laser1 = Instantiate(currentLaser, startPosition1, Quaternion.identity) as GameObject;
            GameObject laser2 = Instantiate(currentLaser, startPosition2, Quaternion.identity) as GameObject;
            GameObject laser3 = Instantiate(currentLaser, startPosition3, Quaternion.identity) as GameObject;

            laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
        else if (bulletState == 4)
        {
            Vector3 startPosition1 = transform.position + new Vector3(0.3f, 0.5f, 0);
            Vector3 startPosition2 = transform.position + new Vector3(0.1f, 0.5f, 0);
            Vector3 startPosition3 = transform.position + new Vector3(-0.1f, 0.5f, 0);
            Vector3 startPosition4 = transform.position + new Vector3(-0.3f, 0.5f, 0);

            GameObject laser1 = Instantiate(currentLaser, startPosition1, Quaternion.identity) as GameObject;
            GameObject laser2 = Instantiate(currentLaser, startPosition2, Quaternion.identity) as GameObject;
            GameObject laser3 = Instantiate(currentLaser, startPosition3, Quaternion.identity) as GameObject;
            GameObject laser4 = Instantiate(currentLaser, startPosition4, Quaternion.identity) as GameObject;

            laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser4.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
        else if(bulletState == 5 || bulletState ==6)
        {
            Vector3 startPosition = transform.position + new Vector3(0, 4.8f, 0);
            GameObject laser = Instantiate(currentLaser, startPosition, Quaternion.identity) as GameObject;
           // laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
            Destroy(laser,0.1f);
        }
        else if (bulletState == 7)
        {
            Vector3 startPosition1 = transform.position + new Vector3(0.2f, 0.7f, 0);
            Vector3 startPosition2 = transform.position + new Vector3(0, 1.2f, 0);
            Vector3 startPosition3 = transform.position + new Vector3(-0.2f, 0.5f, 0);

            GameObject laser1 = Instantiate(currentLaser, startPosition1, Quaternion.identity) as GameObject;
            laser1.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            GameObject laser2 = Instantiate(currentLaser, startPosition2, Quaternion.identity) as GameObject;
            GameObject laser3 = Instantiate(currentLaser, startPosition3, Quaternion.identity) as GameObject;
            laser3.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
        else if (bulletState == 8)
        {
            Vector3 startPosition1 = transform.position + new Vector3(0.3f, 0.5f, 0);
            Vector3 startPosition2 = transform.position + new Vector3(0.15f, 0.9f, 0);
            Vector3 startPosition3 = transform.position + new Vector3(0f, 1.35f, 0);
            Vector3 startPosition4 = transform.position + new Vector3(-0.15f, 1f, 0);
            Vector3 startPosition5 = transform.position + new Vector3(-0.3f, 0.8f, 0);

            GameObject laser1 = Instantiate(currentLaser, startPosition1, Quaternion.identity) as GameObject;
            laser1.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            GameObject laser2 = Instantiate(currentLaser, startPosition2, Quaternion.identity) as GameObject;
            laser2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            GameObject laser3 = Instantiate(currentLaser, startPosition3, Quaternion.identity) as GameObject;
            GameObject laser4 = Instantiate(currentLaser, startPosition4, Quaternion.identity) as GameObject;
            laser4.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            GameObject laser5 = Instantiate(currentLaser, startPosition5, Quaternion.identity) as GameObject;
            laser5.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser4.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            laser5.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
    }
}

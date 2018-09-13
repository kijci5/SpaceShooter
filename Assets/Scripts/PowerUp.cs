using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] int gemScoreValue = 500;

    private GameObject player;
    private Rigidbody2D rigidBody;
    private Vector2 falling;
   
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        falling = new Vector2(0f, -3f);
        rigidBody.velocity = falling;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject == player)
        {
            GemAddingScore();
            Destroy(gameObject);
        }
        if (col.gameObject==player && gameObject.tag == "BulletUpgrade") {
            BulletUpgrade();
            Destroy(gameObject);
        }
        if (col.gameObject == player && gameObject.tag == "ShipUpgrade")
        {
            ShipUpgrade();
            Destroy(gameObject);
        }
        if (col.gameObject == player && gameObject.tag == "AutoFire")
        {
            AutoFire();
            Destroy(gameObject);
        }
        if (col.gameObject == player && gameObject.tag == "BulletSpeed")
        {
            BulletSpeed();
            Destroy(gameObject);
        }
        if (col.gameObject == player && gameObject.tag == "ShipSpeed")
        {
            ShipSpeed();
            Destroy(gameObject);
        }
    }
    private void GemAddingScore()
    {
        ScoreKeeper.points += gemScoreValue;
    }
    private void BulletUpgrade()
    {
        if (PlayerController.bulletState < player.GetComponent<PlayerController>().laserPrefabs.Length - 1)
        {
            PlayerController.bulletState += 1;
        }
    }
    private void ShipUpgrade()
    {
        if (PlayerController.spriteState < player.GetComponent<PlayerController>().playerSprites.Length - 1)
        {
            PlayerController.spriteState += 1;
            player.GetComponent<PlayerController>().health += 100;
        }
    }
    private void AutoFire()
    {
        player.GetComponent<PlayerController>().autoFire = true;
    }
    private void BulletSpeed()
    {
        if (player.GetComponent<PlayerController>().laserSpeed <= 25f)
        { player.GetComponent<PlayerController>().laserSpeed += 0.5f; }
    }
    private void ShipSpeed()
    {
        if (player.GetComponent<PlayerController>().speed <= 21f)
        { player.GetComponent<PlayerController>().speed += 1f; }
    }
}

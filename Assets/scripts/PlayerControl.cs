using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO;
    public GameObject PlayerBulletGO;
    public GameObject BulletPosition1;
    public GameObject BulletPosition2;
    public GameObject ExplosionGO;

    private AudioSource shootAudio;


    public TMP_Text LivesUIText;

    const int MaxLives = 3;//maximum player lives
    int lives;//current player lives


    void Start()
    {
        shootAudio = GetComponent<AudioSource>();
    }

    public void Init()
    {
        lives = MaxLives;

        //update the lives UI text
        LivesUIText.text = lives.ToString();

        //set this player game object to active gameObject.SetActive (true);
        gameObject.SetActive(true);
    }


    public float speed;
    private Vector2 moveInput;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Instantiate bullets
            Instantiate(PlayerBulletGO, BulletPosition1.transform.position, Quaternion.identity);
            Instantiate(PlayerBulletGO, BulletPosition2.transform.position, Quaternion.identity);

            if (shootAudio != null)
                shootAudio.Play();
        }

        if (Keyboard.current == null) return;

        moveInput = Vector2.zero;

        if (Keyboard.current.aKey.isPressed) moveInput.x = -1;
        if (Keyboard.current.dKey.isPressed) moveInput.x = 1;
        if (Keyboard.current.wKey.isPressed) moveInput.y = 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y = -1;

        Move(moveInput.normalized);
    }

    void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag =="EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            lives--;
            LivesUIText.text = lives.ToString();
            if (lives == 0)
            {
                gameObject.SetActive(false);
                GameManagerGO.GetComponent<GameManager>().GameOver();
            }
           
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }


}

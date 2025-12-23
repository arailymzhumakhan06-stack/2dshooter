using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public GameObject PlayerBulletGO;
    public GameObject BulletPosition1;
    public GameObject BulletPosition2;
    public GameObject ExplosionGO;

    public float speed;
    private Vector2 moveInput;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Instantiate bullets
            Instantiate(PlayerBulletGO, BulletPosition1.transform.position, Quaternion.identity);
            Instantiate(PlayerBulletGO, BulletPosition2.transform.position, Quaternion.identity);
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
            Destroy(gameObject); //destroy player
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }


}

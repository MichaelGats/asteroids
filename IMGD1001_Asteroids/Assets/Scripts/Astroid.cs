using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
            // can also write Vector.one as new Vector3(this.size, this.size, this.size)

        _rigidbody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction) {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        gameObject.GetComponent<AudioSource>().Play();
        if (collision.gameObject.tag == "Bullet") {
            if ((this.size * 0.5) >= this.minSize) {
                
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AstroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit() {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Astroid half = Instantiate(this, position, this.transform.rotation);
        half.size  = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
}

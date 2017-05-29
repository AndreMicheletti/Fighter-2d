using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public new SpriteRenderer renderer;
	public new Rigidbody2D body;
	public BehaviourList behaviourList;

	public Sprite[] spriteOptions;
	public int maxHealth = 10;
	public int atkDamage = 1;
	public float xVel = 1.0f;
	public float yVel = 1.0f;

	private int currHealth = 0;
	private EnemyBehaviour behaviour;

	/*public void initialize(Sprite _sprite, int _maxhealth, int _atkdamage) {
		this.sprite = _sprite;
		this.maxHealth = _maxhealth;
		this.atkDamage = _atkdamage;
		resetStatus ();
	}*/

	public void initialize() {
		renderer.sprite = spriteOptions[Random.Range(0, spriteOptions.Length)];
		switch (behaviourList) {
		case BehaviourList.ZigZag:
			behaviour = new ZigZagBehaviour ();
			break;
		default:
			behaviour = new ZigZagBehaviour ();
			break;
		}
		resetStatus ();
	}

	void resetStatus() {
		currHealth = maxHealth;
	}

	// Use this for initialization
	void Start () {
		if (renderer == null) {
			Debug.LogError ("Renderer variable in Enemy.cs is null. Destroying object");
			Destroy (gameObject);
			return;
		}
		resetStatus ();
	}
	
	// Update is called once per frame
	void Update () {
		behaviour.update ();
		Move (behaviour.getCommand());
	}

	void Move(Command command) {
		/*Vector3 newPos = transform.position;

		if (command == Command.MOVE_LEFT) {
			newPos.x -= xVel;
		} else if (command == Command.MOVE_RIGHT) {
			newPos.x += xVel;
		}
		newPos.y += yVel;

		body.MovePosition (newPos);*/

		Vector2 velocity = new Vector2 (0.0f, 0.0f);
		if (command == Command.MOVE_LEFT) {
			velocity.x = -xVel;
		} else if (command == Command.MOVE_RIGHT) {
			velocity.x = +xVel;
		}
		velocity.y = yVel;
		body.velocity = velocity;
	}

	public void cloneFrom(Enemy enemy) {
		this.renderer.sprite = enemy.getSprite();
		this.maxHealth = enemy.getMaxHealth ();
		this.atkDamage = enemy.getAtkDamage ();
	}

	public void hit(int dmg) {
		currHealth -= dmg;
		if (currHealth <= 0) {
			DestroyEnemy ();
		}
	}

	void DestroyEnemy() {
		Destroy (gameObject);
	}

	/**
	 * Getters and Setters
	 * */

	public Sprite getSprite() {
		return renderer.sprite;
	}

	public int getMaxHealth() {
		return maxHealth;
	}

	public int getAtkDamage() {
		return atkDamage;
	}
}

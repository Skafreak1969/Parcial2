using UnityEngine;

namespace Parcial2.Game
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody myRigidBody;
        private float speed;
        private int damage;

        private GameObject instigator;

        public void SetParams(float bulletSpeed, int bulletDamage, GameObject instanceInstigator)
        {
            instigator = instanceInstigator;
            speed = bulletSpeed;
            damage = bulletDamage;
        }

        public void Toss()
        {
            myRigidBody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player.Instance.gameObject)
            {
                //Collided with player
            }
            else
            {
                Enemy enemy = other.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.ReceiveDamage(damage);
                }
            }

            if (instigator != other.gameObject)
            {
                Destruir(); 
            }
        }

        void Destruir()
        {
            Destroy(gameObject);
        }

        // Use this for initialization
        private void Awake()
        {
            myRigidBody = GetComponent<Rigidbody>();
            Invoke("Destruir", 2);
        }

        private void OnDestroy()
        {
            myRigidBody = null;
        }
    } 
}
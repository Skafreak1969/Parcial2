using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Parcial2.Game {
    public class FactoryA : Enemy {
        [SerializeField] GameObject EnemigoA;
        GameObject aux;
        Enemy aux2;
        [SerializeField] private float tiempoRetraso;

        public float GettiempoRetraso()
        {
            return tiempoRetraso;
        }

        public  Enemy InstanciarEnemigo()
        {
            aux=Instantiate(EnemigoA);
            aux2 = aux.GetComponent<Enemy>();
            HP = Random.Range(0, 5);
            Atk = Random.Range(0, 5);
            return aux2;
        }
    }
}

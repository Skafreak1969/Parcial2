using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Parcial2.Game {
    public class Factory : MonoBehaviour {
        public List<Enemy> enemigos;
        [SerializeField] float TiempoOlas;
        float tiempo2;
        Enemy aux;
        [SerializeField] FactoryA FactoriaA;
        [SerializeField] FactoryB FactoriaB;
        [SerializeField] FactoryC FactoriaC;
        [SerializeField] FactoryD FactoriaD;
        int ola;
        int cantidadA;
        int cantidadB;
        int cantidadC;
        int cantidadD;
        private void Awake()
        {
            ola = 1;
            cantidadA = 3;
            cantidadB = 2;
            cantidadC = 2;
            cantidadD = 1;
            tiempo2 = 0;
            enemigos = new List<Enemy>();
        }

        protected void InstanciarEnemigos()
        {
            for (int i = 0; i < cantidadA * ola; i++)
            {
                Invoke("InstanciarA", FactoriaA.GettiempoRetraso());
            }
            for (int i = 0; i < cantidadB * ola; i++) {
                Invoke("InstanciarB", FactoriaA.GettiempoRetraso());
            }
            for (int i = 0; i<cantidadC* ola; i++){
                Invoke("InstanciarC", FactoriaA.GettiempoRetraso());
            }
            for (int i = 0; i < cantidadD * ola; i++){
                Invoke("InstanciarD", FactoriaA.GettiempoRetraso());
            }
            if (ola < 4)
            {
                ola++;
            }
            else
            {
                ola = 4;
            }
        }

        public void InstanciarA()
        {
            enemigos.Add(FactoriaA.InstanciarEnemigo());
        }

        public void InstanciarB()
        {
            enemigos.Add(FactoriaB.InstanciarEnemigo());
        }

        public void InstanciarC()
        {
            enemigos.Add(FactoriaC.InstanciarEnemigo());
        }

        public void InstanciarD()
        {
            enemigos.Add(FactoriaD.InstanciarEnemigo());
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void FixedUpdate() {
            tiempo2-=Time.deltaTime;
            if (tiempo2 <= 0)
            {
                tiempo2 = TiempoOlas*(ola/2);
                InstanciarEnemigos();
                
            }
        }
    }
}

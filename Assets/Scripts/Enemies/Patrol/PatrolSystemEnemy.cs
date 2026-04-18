using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Patrol
{
    public class PatrolSystemEnemy : EnemySystem 
    {
        [SerializeField]private Transform patrolPath;
        [SerializeField]private int patrolSpeed;
        private List<Vector3> patrolPositions = new ();
        private Vector3 currentPosition;
        private int currentIndex;
        
        private Coroutine patrolRoutine;
        private bool patrolIsRunning;
        
        
        private void Awake()
        {
            base.Awake();
            foreach (Transform partolPoint in patrolPath)
            {
                patrolPositions.Add(partolPoint.position);
            }
        }

        private void Start()
        { 
            Move();         
        }

        public void Move()
        {
            patrolIsRunning = true;
            patrolRoutine = StartCoroutine(PatrolAndWait());
        }

        public void Stop()
        {
            patrolIsRunning = false;
            if (patrolRoutine != null)
            {
                StopCoroutine(patrolRoutine);
            }
        }
        private IEnumerator PatrolAndWait()
        {
            while (patrolIsRunning)
            {
                CalculateNewDestination();
                FaceToDestination();
                while (transform.position != currentPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, currentPosition, patrolSpeed * Time.deltaTime);
                    yield return new Null();
                }
                enemyMain.events.UpdateMovement(0);
                yield return new WaitForSeconds(Random.Range(0.2f, 2.5f));
                currentIndex = (currentIndex+1) % patrolPositions.Count;
            }
            
        }
        private void FaceToDestination()
        {
            float x = currentPosition.x - transform.position.x;
            switch (Mathf.Sign(x))
            {
                case -1:
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    enemyMain.events.UpdateMovement(-1);
                    break;
                case 1:
                    transform.eulerAngles = Vector3.zero;
                    enemyMain.events.UpdateMovement(1);
                    break;
            }
        }
        private void CalculateNewDestination()
        {
            currentPosition = patrolPositions[currentIndex];
        }
    }
}

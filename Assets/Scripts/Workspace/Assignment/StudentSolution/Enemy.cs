using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assignment.StudentSolution
{
    public class Enemy : Entity
    {
        public int damage;
        protected int aiLevel;
        public virtual void Attack(Entity target)
        {

        }
        protected virtual void Patrol()
        {

        }
    }
}

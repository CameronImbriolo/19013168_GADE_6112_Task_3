using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_CameronImbriolo_19013168
{
    public enum Faction
    {
        Red,
        Blue
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    [Serializable]
    abstract class Unit
    {
        //Q.1.3 Creates all the relevant variables for any Unit with the appropriate protection
        public int xPos;
        public int yPos;
        public int health;
        public int maxHealth;
        protected int attackRange;
        protected int attack;
        protected int speed;

        public string symbol;
        public Faction faction;
        protected string name;
        protected bool isAttacking;

        //Q.1.4 Defines all the abstract methods required for any Unit
        public abstract void Move(List<Unit> units, List<ResourceBuilding> buildings);
        public abstract void Attack(Unit u);
        public abstract bool InRange(Unit u);
        public abstract Unit ClosestEnemy(List<Unit> units);
        public abstract ResourceBuilding ClosestEnemy(List<ResourceBuilding> units);
        public abstract void TakeDamage(int damage);
        public abstract bool IsDead();
        public override abstract string ToString();
        public abstract bool InRange(ResourceBuilding u);
        public abstract void Attack(ResourceBuilding u);
    }
}

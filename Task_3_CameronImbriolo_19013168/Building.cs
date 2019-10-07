using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_CameronImbriolo_19013168
{
    [Serializable]
    //Q.2.4 Created an abstract class called building
    abstract class Building
    {
        //generates the fields for Building
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected Faction faction;
        protected string symbol;

        //Q.2.4 Defines all the abstract methods required for any Building
        public abstract bool IsDead();
        public abstract void TakeDamage(int damage);
        public override abstract string ToString();
    }
}

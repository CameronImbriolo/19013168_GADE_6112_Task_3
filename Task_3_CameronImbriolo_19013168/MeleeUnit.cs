using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_CameronImbriolo_19013168
{
    [Serializable]
    //Q.1.5 Implementing ond overriding abstract classes
    class MeleeUnit : Unit
    {
        private int Melee_Damage = 10;
        private int Melee_Speed = 1;
        private int Melee_Range = 1;
        private string Melee_Red_Symbol = ">";
        private string Melee_Blue_Symbol = "<";
        private int speedCounter = 0;

        //Q.1.6 Created appropriate properties and parameters for a melee class
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int MaxHealth
        {
            get { return base.maxHealth; }
        }
        public int AttackRange
        {
            get { return base.attackRange; }
        }
        public int Damage
        {
            get { return base.attack; }
        }
        public int Speed
        {
            get { return base.speed; }
        }
        public Faction UnitFaction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }
        public string Symbol
        {
            get { return base.symbol; }
        }
        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }

        //Q.1.5 Constructor that accepts the relevant values to create a melee unit
        public MeleeUnit(string name, int health, Faction unitFaction, int xPos, int yPos)
        {
            Name = name;
            Health = health;
            UnitFaction = unitFaction;
            IsAttacking = false;
            if(unitFaction == Faction.Blue)
                base.symbol = Melee_Blue_Symbol;
            else
                base.symbol = Melee_Red_Symbol;
            base.maxHealth = health;
            base.attack = Melee_Damage;
            base.speed = Melee_Speed;
            base.attackRange = Melee_Range;
            XPos = xPos;
            YPos = yPos;
        }
        //overloading constructor
        public MeleeUnit(string name, int health, Faction unitFaction)
        {
            Name = name;
            Health = health;
            UnitFaction = unitFaction;
            IsAttacking = false;
            if (unitFaction == Faction.Blue)
                base.symbol = Melee_Blue_Symbol;
            else
                base.symbol = Melee_Red_Symbol;
            base.maxHealth = health;
            base.attack = Melee_Damage;
            base.speed = Melee_Speed;
            base.attackRange = Melee_Range;
        }

        //Handles a unit attacking another unit
        public override void Attack(Unit u)
        {
            if (InRange(u) && u != null)
            {
                u.TakeDamage(Damage);
            }
        }

        //Handles a unit taking damage
        public override void TakeDamage(int damage)
        {
            Health -= damage;
        }

        //Determines via the distance formula which of all enemy units are closest
        public override Unit ClosestEnemy(List<Unit> units)
        {
            float tempDist = 0;
            float distance = 100000;
            Unit result = null;
            foreach (Unit u in units)
            {
                if (u.faction != this.faction)
                {
                    tempDist = calcDist(u);
                    if (tempDist <= distance)
                    {
                        distance = tempDist;
                        result = u;
                    }
                }
            }
            return result;
        }

        //returns whether or not a unit is dead
        public override bool IsDead()
        {
            if (Health <= 0)
                return true;
            else
                return false;
        }

        //Determines whether a unit is within attack range
        public override bool InRange(Unit u)
        {
            float dist = calcDist(u);
            if (dist <= Melee_Range)
            {
                IsAttacking = true;
                return true;
            }
            else
            {
                IsAttacking = false;
                return false;
            }
        }

        //Handles the movement of units via coordinates
        public override void Move(List<Unit> units)
        {
            speedCounter++;
            if(speed == speedCounter && !IsAttacking && !IsDead() && Health >= MaxHealth/4)
            {
                switch (EnemyDir(units))
                {
                    case Direction.North:
                        yPos--;
                        break;
                    case Direction.East:
                        xPos++;
                        break;
                    case Direction.South:
                        yPos++;
                        break;
                    case Direction.West:
                        xPos--;
                        break;
                    default:
                        break;
                }
                speedCounter = 0;
            }
            else if (speed == speedCounter && !IsAttacking && !IsDead() && Health <= MaxHealth / 4)
            {
                Random r = new Random();
                Direction rDir = (Direction)r.Next(0, 4);
                switch (rDir)
                {
                    case Direction.North:
                        yPos--;
                        break;
                    case Direction.East:
                        xPos++;
                        break;
                    case Direction.South:
                        yPos++;
                        break;
                    case Direction.West:
                        xPos--;
                        break;
                    default:
                        break;
                }
            }
        }

        //returns relevant info in string form to be displayed
        public override string ToString()
        {
            return String.Format("{0}: Health = {1}. {2} Team. In Combat: {3}\n", name, health, UnitFaction.ToString(), IsAttacking);
        }

        //determines in which direction the unit must move based on the closest enemy
        private Direction EnemyDir(List<Unit> units)
        {
            Unit unit = ClosestEnemy(units);
            if (unit.xPos > this.xPos)
                return Direction.East;
            else if (unit.xPos < this.xPos)
                return Direction.West;
            else if (unit.yPos > this.yPos)
                return Direction.South;
            else if (unit.yPos < this.yPos)
                return Direction.North;
            else
            {
                Random r = new Random();
                return (Direction)r.Next(0, 4);
            }

        }

        //Calculates the distance between two units using the distance formula
        private float calcDist(Unit u)
        {
            try
            {
                float xd, yd, x1, y1, x2, y2;
                float dist = 0;
                x1 = this.xPos;
                x2 = u.xPos;
                y1 = this.yPos;
                y2 = u.yPos;

                xd = x2 - x1;
                yd = y2 - y1;
                dist = (float)Math.Sqrt(xd * xd + yd * yd);
                return dist;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}

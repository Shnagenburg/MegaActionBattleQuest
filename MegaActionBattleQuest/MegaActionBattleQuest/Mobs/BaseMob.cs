using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegaActionBattleQuest.Mobs
{
    class BaseMob
    {
        Inventory inventory;

        int currentHP;
        int maxHP;

        int level;

        public bool isMoving;
        protected float moveSpeed;

        protected MovementDirections moveDirection;

        protected Sprite sprite;

        public void draw(float elapsedtime)
        {
            sprite.draw(elapsedtime);
        }
    }
}

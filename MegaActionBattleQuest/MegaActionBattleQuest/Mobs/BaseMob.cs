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

        Sprite sprite;

        public void draw(float elapsedtime)
        {
            sprite.draw(elapsedtime);
        }
    }
}

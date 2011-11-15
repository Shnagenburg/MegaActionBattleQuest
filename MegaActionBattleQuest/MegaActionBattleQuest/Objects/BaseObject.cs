using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegaActionBattleQuest.Objects
{
    class BaseObject
    {
        Sprite sprite;

        public void draw(float elapsedtime)
        {
            sprite.draw(elapsedtime);
        }
    }
}

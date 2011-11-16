using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegaActionBattleQuest.Items
{

    enum EquipmentSlots { Feet, Legs, Chest, Hands, Head, Finger, Neck, Wrist }
    enum WeaponSlots { MainHand, OffHand }

    class BaseItem
    {

        public string name { get {return name;} }
        public int value { get { return value; } }

        Sprite sprite;

        public void draw(float elapsedtime)
        {
            sprite.draw(elapsedtime);
        }
    }
}

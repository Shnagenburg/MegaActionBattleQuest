using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MegaActionBattleQuest.Levels
{
    class Level
    {

        Texture2D baseLayerTexture;
        SpriteBatch spriteBatch;

        const int levelTileWidth = 20;
        const int levelTileHeight = 15;

        const int tileSize = 32;
        const int spriteSheetPadding = 1;

        const int gameBorder = 8;

        int[,] baseLayerMap; //the environment
        int[,] obstructionLayerMap; //flags for walls and water and shit the PC can't walk through (this layer is purely for collision detection)
        int[,] interactiveLayerMap; //chests, traps, doors, items on the ground that the PC can walk through;
        
        public IList<Objects.BaseObject> mapObjects;

        public Level(SpriteBatch spriteBatch, ContentManager myContent)
        {
            baseLayerTexture = myContent.Load<Texture2D>("baselayer");
            this.spriteBatch = spriteBatch;
            baseLayerMap = new int[,] { {01,01,01,01,01,12,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {01,01,01,18,13,03,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {01,01,18,03,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {01,18,03,00,00,00,00,00,16,14,14,14,14,14,14,15,00,00,00,00},
                                        {01,12,00,00,00,16,14,14,05,01,01,01,01,01,01,12,00,00,00,00},
                                        {01,12,00,00,00,02,01,01,01,01,18,13,17,01,01,12,00,00,00,00},
                                        {01,06,15,00,00,02,01,01,01,01,12,00,02,01,01,12,00,00,00,00},
                                        {01,01,12,00,00,02,01,01,01,01,12,00,04,17,01,12,00,00,00,00},
                                        {01,01,12,00,00,04,13,13,13,13,03,00,00,04,13,03,00,00,00,00},
                                        {13,13,03,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                                        {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},};

            obstructionLayerMap = new int[,] {  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        }


        public void Update(float elapsedTime)
        {
             

        }

        public void Draw(float elapsedTime)
        {
            Rectangle sourceRect;

            //Draw the base layer
            for (int x = 0; x < levelTileWidth; x++)
            {
                for (int y = 0; y < levelTileHeight; y++)
                {
                    sourceRect = getSourceRect(baseLayerMap[y, x]);
                    spriteBatch.Draw(baseLayerTexture, new Rectangle(x * tileSize + gameBorder, y * tileSize+gameBorder, tileSize, tileSize), sourceRect, Color.White);
                }
            }

            //Draw the interactive layer
        }

        Rectangle getSourceRect(int sourceID)
        {
            int row = sourceID / 12;
            int column = sourceID % 12;

            int y = (tileSize + spriteSheetPadding) * row;
            int x = (tileSize + spriteSheetPadding) * column;

            return new Rectangle(x, y, tileSize, tileSize);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ScrollingXNA
{

    class Background
    {
        public Texture2D textura;
        public Rectangle rectangulo;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rectangulo, Color.White);

        }
    }
    class Scrolling : Background
    {
        public Scrolling(Texture2D nuevaTextura, Rectangle nuevoRectangulo)
        {
            textura = nuevaTextura;
            rectangulo = nuevoRectangulo;
        }

        public void Update()
        {
            rectangulo.X -= 3;
        }
    }
}
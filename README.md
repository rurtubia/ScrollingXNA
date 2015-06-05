# ScrollingXNA

Simple scrolling background for XNA apps.

![Preview](https://github.com/rurtubia/ScrollingXNA/blob/master/ScrollingXNA/ScrollingXNAContent/scrollingXNA.gif)

###Class Game1
```csharp
public class Game1 : Microsoft.Xna.Framework.Game
{
  GraphicsDeviceManager graphics;
  SpriteBatch spriteBatch;
  Scrolling scrolling1;
  Scrolling scrolling2;

  public Game1()  {
    graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
  }

  protected override void Initialize()  {
    base.Initialize();
  }

  protected override void LoadContent()  {
    spriteBatch = new SpriteBatch(GraphicsDevice);
    scrolling1 = new Scrolling(Content.Load<Texture2D>("background"), new Rectangle(0, 0, 1953, 681));
    scrolling2 = new Scrolling(Content.Load<Texture2D>("background"), new Rectangle(1953, 0, 1953, 681));
  }

  protected override void UnloadContent() {
  }

  protected override void Update(GameTime gameTime) {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
      this.Exit();
    if (scrolling1.rectangulo.X + scrolling1.textura.Width <= 0)  {
      scrolling1.rectangulo.X = scrolling2.rectangulo.X + scrolling2.rectangulo.Width;
    }
    if (scrolling2.rectangulo.X + scrolling2.textura.Width <= 0)  {
      scrolling2.rectangulo.X = scrolling1.rectangulo.X + scrolling1.rectangulo.Width;
    }
    
    scrolling1.Update();
    scrolling2.Update();
    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime) {
    GraphicsDevice.Clear(Color.CornflowerBlue);
    spriteBatch.Begin();
    scrolling1.Draw(spriteBatch);
    scrolling2.Draw(spriteBatch);
    spriteBatch.End();
    base.Draw(gameTime);
  }
}
```

### Class Background:
```csharp 
class Background
    {
        public Texture2D textura;
        public Rectangle rectangulo;
        public void Draw(SpriteBatch spriteBatch){
          spriteBatch.Draw(textura, rectangulo, Color.White);
        }
    }
```
###Class Scrolling:
```csharp
class Scrolling : Background 
{
  public Scrolling(Texture2D nuevaTextura, Rectangle nuevoRectangulo) {
    textura = nuevaTextura;
    rectangulo = nuevoRectangulo;
  }
  public void Update() {
    rectangulo.X -= 3;
  }
}
```

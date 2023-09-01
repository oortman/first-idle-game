using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstIdleGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background1, _background2, _background3;
    private Character _character;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 800;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    
    protected override void Initialize()
    {
        base.Initialize();
    }
    
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _background1 = Content.Load<Texture2D>("Background/background1");
        _background2 = Content.Load<Texture2D>("Background/background2");
        _background3 = Content.Load<Texture2D>("Background/background3");

        Texture2D characterTexture = Content.Load<Texture2D>("Character/Run");
        _character = new Character(characterTexture, 4, 2);
    }
    
    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _character.Update(gameTime);

        base.Update(gameTime);
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        
        _spriteBatch.Draw(_background1, new Rectangle(0,0,800,800), Color.White);
        _spriteBatch.Draw(_background2, new Rectangle(0,0,800,800), Color.White);
        _spriteBatch.Draw(_background3, new Rectangle(0,0,800,800), Color.White);
        _character.Draw(_spriteBatch, new Vector2(150,300));
        
        
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}

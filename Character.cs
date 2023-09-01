using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstIdleGame;

/// <summary>
/// Class represents a character in the game.
/// </summary>
public class Character
{
    public Texture2D Texture { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    
    private int _currentFrame;
    private int _totalFrames;
    private double _timeSinceLastFrame = 0;
    private int _millisecondsPerFrame = 100;

    /// <summary>
    /// Constructor for the Character class.
    /// </summary>
    /// <param name="texture">2D texture for the Character spritesheet</param>
    /// <param name="rows">Number of rows in the spritesheet</param>
    /// <param name="columns">Number of columns in the spritesheet</param>
    public Character(Texture2D texture, int rows, int columns)
    {
        Texture = texture;
        Rows = rows;
        Columns = columns;
        _currentFrame = 0;
        _totalFrames = Rows * Columns;
    }

    /// <summary>
    /// Updates which frame of the spritesheet should be selected.
    /// </summary>
    public void Update(GameTime gameTime)
    {
        _timeSinceLastFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
        if (_timeSinceLastFrame >= _millisecondsPerFrame)
        {
            _currentFrame++;
            _timeSinceLastFrame = 0;
        }
            
        if (_currentFrame == _totalFrames)
            _currentFrame = 0;
    }

    /// <summary>
    /// Draws the current sprite frame of the Character at the specified location.
    /// </summary>
    /// <param name="spriteBatch">SpriteBatch from Game object</param>
    /// <param name="location">Location of the Character</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        int row = _currentFrame / Columns;
        int column = _currentFrame % Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
        
        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
    }
}
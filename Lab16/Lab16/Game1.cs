using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab16
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D sprite;
        Rectangle drawRectangle;

        int WindowWidth = 800;
        int WindowHeight = 600;

        const int Movement = 5;
        int offScreenCount = 0;

        SpriteFont font;
        Vector2 fontPosition = new Vector2(0, 0);

        string score = "Off Screen Count: ";

        bool inside = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprite = Content.Load<Texture2D>("graphics//rabbut");
            drawRectangle = new Rectangle(WindowWidth / 2 - sprite.Width / 2, WindowHeight / 2 - sprite.Height / 2,
                sprite.Width, sprite.Height);
            font = Content.Load<SpriteFont>("fonts//Arial20");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.W))
            {
                drawRectangle.Y -= Movement;
                if (drawRectangle.Top < 0 && inside)
                {
                    //    drawRectangle.Y = 0;
                    inside = false;
                    offScreenCount += 1;
                }
            }
            if (kb.IsKeyDown(Keys.S))
            {
                drawRectangle.Y += Movement;
                if (drawRectangle.Bottom > WindowHeight && inside)
                {
                    //drawRectangle.Y = WindowHeight - drawRectangle.Height;
                    inside = false;
                    offScreenCount += 1;
                }
            }
            if (kb.IsKeyDown(Keys.A))
            {
                drawRectangle.X -= Movement;
                if (drawRectangle.Left < 0 && inside)
                {
                    //drawRectangle.X = 0;
                    inside = false;
                    offScreenCount += 1;
                }
            }
            if (kb.IsKeyDown(Keys.D))
            {
                drawRectangle.X += Movement;
                if (drawRectangle.Right > WindowWidth && inside)
                {
                    //drawRectangle.X = WindowWidth - drawRectangle.Width;
                    inside = false;
                    offScreenCount += 1;
                }
            }

            if (!inside)
            {
                if (drawRectangle.Left >= 0 && drawRectangle.Right <= WindowWidth &&
                    drawRectangle.Top >= 0 && drawRectangle.Bottom <= WindowHeight)
                {
                    inside = true;
                }
            }

            if (kb.IsKeyDown(Keys.Space))
            {
                drawRectangle.X = WindowWidth / 2 - drawRectangle.Width / 2;
                drawRectangle.Y = WindowHeight / 2 - drawRectangle.Height / 2;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, drawRectangle, Color.White);
            spriteBatch.DrawString(font, score + offScreenCount, fontPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExplodingTeddies;
using System;
    
namespace Lab_11
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public const int WindowWidth = 800;
        public const int WindowHeight = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear bear;
        Explosion explode;

        Random rand = new Random();

        public const float scaleFactor = 0.2F;

        ButtonState previousState = ButtonState.Released;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;

            IsMouseVisible = true;
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

            // Create teddybear
            float velocityX = (float)(rand.NextDouble()) * scaleFactor;
            float velocityY = (float)(rand.NextDouble()) * scaleFactor;

            Vector2 velocity = new Vector2(velocityX, velocityY);

            bear = new TeddyBear(Content, WindowWidth, WindowHeight, "graphics//teddybear", WindowWidth / 2, WindowHeight / 2, velocity);
            explode = new Explosion(Content, "graphics//explosion");
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
            bear.Update(gameTime);
            explode.Update(gameTime);

            MouseState mouse = Mouse.GetState();           
            

            if (bear.DrawRectangle.Contains(mouse.Position) && (mouse.LeftButton == ButtonState.Pressed))
            {
                bear.Active = false;
                explode.Play(bear.DrawRectangle.Center.X, bear.DrawRectangle.Center.Y);
            }

            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);

            if (gamepad.IsConnected)
            {
                if (gamepad.Buttons.A == ButtonState.Pressed && previousState == ButtonState.Released)
                {
                    bear.Active = false;
                    float velocityX = (float)(rand.NextDouble()) * scaleFactor;
                    float velocityY = (float)(rand.NextDouble()) * scaleFactor;

                    Vector2 velocity = new Vector2(velocityX, velocityY);

                    bear = new TeddyBear(Content, WindowWidth, WindowHeight, "graphics//teddybear", WindowWidth / 2, WindowHeight / 2, velocity);
                }
                previousState = gamepad.Buttons.A;
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

            
            explode.Draw(spriteBatch);
            bear.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

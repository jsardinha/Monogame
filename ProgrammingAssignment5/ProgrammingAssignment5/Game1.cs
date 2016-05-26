using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TeddyMineExplosion;

namespace ProgrammingAssignment5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // constants for window width and height
        const int WindowWidth = 800;
        const int WindowHeight = 600;

        // mine support
        Texture2D mineSprite;
        List<Mine> mines = new List<Mine>();

        // teddybear support
        Texture2D teddyBearSprite;
        List<TeddyBear> teddyBears = new List<TeddyBear>();

        // explosion support
        Texture2D explosionStrip;
        List<Explosion> explosions = new List<Explosion>();

        // velocity support
        Vector2 velocity = new Vector2();        
        int minVelocity = -5;
        int maxVelocity = 5;
        float divisor = 10f;

        // random support
        Random rand = new Random();

        // spawn timer support
        const int MaxDelay = 3000;
        const int MinDelay = 1000;
        int spawnDelay = 0;
        int spawnTimer = 0;

        // click processing
        bool leftClickStarted = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set resolution and make mouse visible
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
            // set the first spawn delay
            spawnDelay = rand.Next(MinDelay, MaxDelay);

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

            // load sprites
            mineSprite = Content.Load<Texture2D>("graphics//mine");
            teddyBearSprite = Content.Load<Texture2D>("graphics//teddybear");
            explosionStrip = Content.Load<Texture2D>("graphics//explosion");
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

            // get mouse state
            MouseState mouse = Mouse.GetState();

            // add mine to mines list when left click is ended
            if (mouse.LeftButton == ButtonState.Pressed) { leftClickStarted = true; }
            if (leftClickStarted && mouse.LeftButton == ButtonState.Released)
            {
                mines.Add(new Mine(mineSprite, mouse.Position.X, mouse.Position.Y));
                leftClickStarted = false;          
            }

            // update spawn timer
            spawnTimer += gameTime.ElapsedGameTime.Milliseconds;

            // check if it's time to spawn a new teeedybear
            if (spawnTimer >= spawnDelay)
            {
                // reset spawnTimer
                spawnTimer = 0;

                // set a new spawn delay
                spawnDelay = rand.Next(MinDelay, MaxDelay);

                // set random velocity X and Y with values between -0.5 and 0.5.
                // as random.Next only accepts int parameters and returns int values
                // the range is set from -5 to 5 and the returned int is divided
                // by float 10 and set as a Vector2 velocity component
                velocity.X = rand.Next(minVelocity, maxVelocity) / divisor;
                velocity.Y = rand.Next(minVelocity, maxVelocity) / divisor;

                // add new teddybear to teddybears list
                teddyBears.Add(new TeddyBear(teddyBearSprite, velocity, WindowWidth, WindowHeight));
            }

            // update teddybears
            foreach (TeddyBear bear in teddyBears) { bear.Update(gameTime); }

            // verify collisions, inactivate collided teddybears and mines
            // and add new explosion to explosions list 
            foreach (TeddyBear teddybear in teddyBears)
            {
                foreach (Mine mine in mines)
                {
                    if (mine.Active && teddybear.Active)
                    {
                        if (teddybear.CollisionRectangle.Intersects(mine.CollisionRectangle))
                        {
                            teddybear.Active = false;
                            mine.Active = false;
                            explosions.Add(new Explosion(explosionStrip, mine.CollisionRectangle.Center.X, mine.CollisionRectangle.Center.Y));

                            // Leave the mines foreach loop because teddybear is 
                            // already inactive due to collision with current mine
                            break;
                        }
                    }
                }
            }

            // update explosions
            foreach (Explosion explosion in explosions) { explosion.Update(gameTime); }

            // remove inactive mines from mines list
            for (int i = mines.Count - 1; i >= 0; i--)
            {
                if (!mines[i].Active) { mines.RemoveAt(i); }
            }

            // remove inactive teddybears from teddybears list
            for (int i = teddyBears.Count - 1; i >= 0; i--)
            {
                if (!teddyBears[i].Active) { teddyBears.RemoveAt(i); }
            }

            // remove not playing explosions from explosions list
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                if (!explosions[i].Playing) { explosions.RemoveAt(i); }
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

            spriteBatch.Begin();

            // draw mines
            foreach (Mine mine in mines) { mine.Draw(spriteBatch); }

            // draw teddybears
            foreach (TeddyBear teddyBear in teddyBears) { teddyBear.Draw(spriteBatch); }

            // draw explosions
            foreach (Explosion explosion in explosions) { explosion.Draw(spriteBatch); }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

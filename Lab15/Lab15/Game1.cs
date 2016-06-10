﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Lab15
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SoundEffect lowerLeft;
        SoundEffect lowerRight;
        SoundEffect upperLeft;
        SoundEffect upperRight;

        bool leftMouseReleased = true;

        int WindowWidth = 800;
        int WindowHeight = 600;

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

            // TODO: use this.Content to load your game content here
            lowerLeft = Content.Load<SoundEffect>("sounds//lowerLeft");
            lowerRight = Content.Load<SoundEffect>("sounds//lowerRight");
            upperLeft = Content.Load<SoundEffect>("sounds//upperLeft");
            upperRight = Content.Load<SoundEffect>("sounds//upperRight");
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
            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed && leftMouseReleased)
            {
                leftMouseReleased = false;
                Point position = mouse.Position;
                if (position.Y < WindowHeight / 2 && position.Y >= 0)
                {
                    if (position.X < WindowWidth / 2 && position.X >= 0)
                    {
                        upperLeft.Play();
                    }
                    else if (position.X > WindowWidth / 2 && position.X <= WindowWidth)
                    {
                        upperRight.Play();
                    }
                }
                else if (position.Y > WindowHeight / 2 && position.Y <= WindowHeight)
                {
                    if (position.X < WindowWidth / 2 && position.X >= 0)
                    {
                        lowerLeft.Play();
                    }
                    else if (position.X > WindowWidth / 2 && position.X <= WindowWidth)
                    {
                        lowerRight.Play();
                    }
                }
            }

            leftMouseReleased = mouse.LeftButton == ButtonState.Released;


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

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExplodingTeddies;


namespace Lab10
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        const int WindowWidth = 800;
        const int WindowHeight = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear bear0;
        TeddyBear bear1;
        Explosion bang0;
        Rectangle intersection;
        bool colisionDetected = false;

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
            Vector2 vector0 = new Vector2(-1, 0);
            Vector2 vector1 = new Vector2(1, 0);
            
            bear0 = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear0", 350, 100, vector0);
            bear1 = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear1", 450, 100, vector1);
            bang0 = new Explosion(Content, @"graphics/explosion");
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
            bear0.Update(gameTime);
            bear1.Update(gameTime);
            bang0.Update(gameTime);          


            if (bear0.Active && bear1.Active && bear0.DrawRectangle.Intersects(bear1.DrawRectangle))
            {
                intersection = Rectangle.Intersect(bear0.DrawRectangle, bear1.DrawRectangle);
                bear0.Active = false;
                bear1.Active = false;
                bang0.Play(intersection.Center.X, intersection.Center.Y);
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
            bear0.Draw(spriteBatch);
            bear1.Draw(spriteBatch);
            bang0.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

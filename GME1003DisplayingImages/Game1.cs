using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GME1003DisplayingImages
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _gamefont;
        private Texture2D _heroSprite;
        private Texture2D _canonballSprite, _bullet1Sprite;
        private float _canonballX, _canonballY, _canonballAngle,  _canonballSpeed, _canonballRotationSpeed, _canonballAccelerate;
        private Color _canonballColor;
        private Random _rng;

        private bool _moveLeft, _moveDown;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _canonballX = 500;
            _canonballY = 200;
            _canonballSpeed = 3f;
            _canonballAngle = 0f;
            _canonballRotationSpeed = 0.1f;
            _canonballAccelerate = 0.25f;

            _rng = new Random();
            _canonballColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128,256));

            _moveLeft = true;
            _moveDown = true;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gamefont = Content.Load<SpriteFont>("GameFont");
            _heroSprite = Content.Load<Texture2D>("hero-small");
            _canonballSprite = Content.Load<Texture2D>("canonball");
            _bullet1Sprite = Content.Load<Texture2D>("bullet1");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here



            if (_moveLeft == true)
                _canonballX -= _canonballSpeed; //move left

            if (_moveLeft == false)
                _canonballX += _canonballSpeed; //move right

            if (_canonballX < 0) { 
                _moveLeft = false;
                _canonballSpeed += _canonballAccelerate;
                _canonballColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128, 256));
            }

            if (_canonballX > 800) { 
                _moveLeft = true;
                _canonballSpeed += _canonballAccelerate;
                _canonballColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128, 256));
            }



            if (_moveDown == true)
                _canonballY += _canonballSpeed; //move down

            if (_moveDown == false)
                _canonballY -= _canonballSpeed; //move up

            if (_canonballY < 0) { 
                _moveDown = true;
                _canonballSpeed += _canonballAccelerate;
                _canonballColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128, 256));
            }

            if (_canonballY > 480) { 
                _moveDown = false;
                _canonballSpeed += _canonballAccelerate;
                _canonballColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128, 256));
            }





            _canonballAngle -= _canonballRotationSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            //int x = 500;
            //int y = 30;
            //Vector2 position = new Vector2(x, y);
            //_spriteBatch.DrawString(_gamefont, "Hello world!!", position, Color.Black);
            //_spriteBatch.DrawString(_gamefont, "Hello GME 1003!!", new Vector2(500, 60), Color.Yellow);
            _spriteBatch.DrawString(_gamefont, _canonballX + "", new Vector2(10,10), Color.Black);



            //_spriteBatch.Draw(_heroSprite, new Vector2(250, 10), Color.Black);
            //_spriteBatch.Draw(_heroSprite, new Vector2(275, 35), Color.Red);
            //_spriteBatch.Draw(_heroSprite, new Vector2(300, 60), Color.White);

            _spriteBatch.Draw(_canonballSprite, new Vector2(_canonballX, _canonballY), null, _canonballColor, _canonballAngle, new Vector2(_canonballSprite.Width/2, _canonballSprite.Height/2), 0.5f, SpriteEffects.FlipHorizontally, 0);

            //Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)

            //_spriteBatch.Draw(_bullet1Sprite, new Vector2(50, 200), null, Color.Yellow, 0f, new Vector2(0, 0), 0.75f, SpriteEffects.FlipHorizontally, 0);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

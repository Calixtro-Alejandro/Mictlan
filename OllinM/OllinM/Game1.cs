using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;

namespace OllinM
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Cesped;
        Vector2 PosicionCesped;
        

        const int numeroframes = 16;
        int frameActual;
        Texture2D Jugador;


        Vector2 PosicionJugadorPNG;
        //Vector2 Girar;

        Vector2 Direccion;

        int T;
        double a;


        //Menu del juego
        Texture2D MenuPrincipal;
        Vector2 Posicion_MenuPrincipal;
        bool VerMenuPrincipal;

        bool PersonajeGirarFrente;
        bool PersonajeGirarEspalda;

        int Tecla;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {

            Posicion_MenuPrincipal = new Vector2(10, 10);
            IsMouseVisible = true;
            PosicionJugadorPNG = new Vector2(300, 300);
           
            PosicionCesped = new Vector2(100, 100);
            //PosicionNodo = new Vector2(10, 10);


           // PosicionOllinPNG = new Vector2(10, 10); 
           Direccion = new Vector2(0.5f, 0.5f);
            T = 0;
            a = 0;

            


            //VerMenuPrincipal = false;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // SplashOllinPNG = Content.Load<Texture2D>("Imagenes/ollinPNG");
            // Nodo = Content.Load<Texture2D>("Imagenes/Nodo");
            MenuPrincipal = Content.Load<Texture2D>("Imagenes/GUI/MenuPrincipal");
            Jugador = Content.Load<Texture2D>("Imagenes/Escenas/Inicio/Cesped_Verde");
            Cesped = Content.Load<Texture2D>("Imagenes/Escenas/Inicio/Cesped_Verde");
           // personaje = Content.Load<Model>("Meshes/Flora/a");

            
        }

        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void  Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var p = (int)gameTime.TotalGameTime.TotalMilliseconds / 100;//Numero de milisegundos que han transcurrido desde que se inició el juego
            frameActual = p % numeroframes;
             
            //PosicionJugadorPNG.X += Direccion.X;
            //PosicionJugadorPNG.Y += Direccion.Y;
            T++;


            ControlDeTeclado();

            base.Update(gameTime);
        }

        private void ControlDeTeclado()
        {
            var estadoTeclado = Keyboard.GetState();

                if (estadoTeclado.IsKeyDown(Keys.W)) PosicionJugadorPNG.Y = PosicionJugadorPNG.Y - 1;
                if (estadoTeclado.IsKeyDown(Keys.W)) PosicionJugadorPNG.X = PosicionJugadorPNG.X + 1;
            if (estadoTeclado.IsKeyDown(Keys.W)) Tecla = 1;

            //  if (estadoTeclado.IsKeyDown(Keys.W)) PersonajeGirarEspalda = true;
            //////////////
            //PersonajeGirarEspalda = true;
            // PersonajeGirarFrente = false;




            if (estadoTeclado.IsKeyDown(Keys.S)) PosicionJugadorPNG.Y = PosicionJugadorPNG.Y + 1;
                if (estadoTeclado.IsKeyDown(Keys.S)) PosicionJugadorPNG.X = PosicionJugadorPNG.X - 1;
            if (estadoTeclado.IsKeyDown(Keys.S)) Tecla = 2;
           // if (estadoTeclado.IsKeyUp(Keys.S)) Tecla = 5;


            // if (estadoTeclado.IsKeyDown(Keys.S)) PersonajeGirarFrente = true;
            //////////////
            /// PersonajeGirarFrente = true;
            //PersonajeGirarEspalda = false;


            if (estadoTeclado.IsKeyDown(Keys.A)) PosicionJugadorPNG.X = PosicionJugadorPNG.X - 1;
                if (estadoTeclado.IsKeyDown(Keys.A)) PosicionJugadorPNG.Y = PosicionJugadorPNG.Y - 1;
            if (estadoTeclado.IsKeyDown(Keys.A)) Tecla = 3;

            //if (estadoTeclado.IsKeyDown(Keys.A)) PersonajeGirarEspalda = true;
            //////////////
            // PersonajeGirarEspalda = false;
            //PersonajeGirarFrente = false;



            if (estadoTeclado.IsKeyDown(Keys.D)) PosicionJugadorPNG.X = PosicionJugadorPNG.X + 1;
                if (estadoTeclado.IsKeyDown(Keys.D)) PosicionJugadorPNG.Y = PosicionJugadorPNG.Y + 1;
            if (estadoTeclado.IsKeyDown(Keys.D)) Tecla = 4;

            //if (estadoTeclado.IsKeyDown(Keys.D)) PersonajeGirarFrente = true;
            //////////////
            // PersonajeGirarFrente = false;
            // PersonajeGirarEspalda = false;


            if (estadoTeclado.IsKeyDown(Keys.M)) VerMenuPrincipal = true;
            if (estadoTeclado.IsKeyDown(Keys.N)) VerMenuPrincipal = false;





            // if (!estadoTeclado.IsKeyDown(Keys.M)) VerMenuPrincipal = false;

            //if(VerMenuPrincipal>=2) VerMenuPrincipal = 0;

            //if (VerMenuPrincipal == true && estadoTeclado.IsKeyDown(Keys.M)) VerMenuPrincipal = false;

            /*
                   switch (VerMenuPrincipal)
                   {
                       case true:
                           Console.WriteLine("Case 1");
                           break;

                       case false:
                           Console.WriteLine("Case 2");
                           break;

                       default:
                           VerMenuPrincipal = false;
                           break;
                   }
                   */




        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);



            var anchoFrame = Jugador.Width / numeroframes;
            // var altoFrames = Jugador.Height;



            // var altoFrames = 128;
            var altoFrames = Jugador.Height / numeroframes;


            var AnchoMenuPrincipal = 400;
            var AltoMenuPrincipal = 400;

            /*
            spriteBatch.Begin();
            spriteBatch.Draw(Jugador, 
                new Rectangle(100, 100, anchoFrame, altoFrames),
                new Rectangle(anchoFrame * frameActual, 0, anchoFrame, altoFrames),
                Color.White);

            spriteBatch.End();

            */



            //CespedVerde:
            spriteBatch.Begin();
            spriteBatch.Draw(Cesped, PosicionCesped,
               scale: new Vector2(1, 1),
               rotation: 0,
               origin: new Vector2(1920 / 2, 1080 / 2),
               color: Color.WhiteSmoke,
               effects: SpriteEffects.FlipHorizontally,
               sourceRectangle: new Rectangle(0, 0, 1920, 1080),
               //ourceRectangle: new Rectangle(anchoFrame * frameActual, 0, anchoFrame, altoFrames),
               layerDepth: 0);

            spriteBatch.End();




            switch (Tecla)
            {
                case 1:
                        spriteBatch.Begin();
                                spriteBatch.Draw(Jugador, PosicionJugadorPNG,
                                     scale: new Vector2(1, 1),
                                     rotation: 0,
                                     origin: new Vector2(64, 64),
                                     color: Color.White,
                                     effects: SpriteEffects.None,
                                     //myEffect,
                                     //sourceRectangle: new Rectangle(0, 0, anchoFrame, altoFrames),
                                     sourceRectangle: new Rectangle(anchoFrame * frameActual, 128, anchoFrame, altoFrames),
                                     layerDepth: 0);
                                 spriteBatch.End();
                    break;


                case 2:
                        spriteBatch.Begin();
                             spriteBatch.Draw(Jugador, PosicionJugadorPNG,
                                 scale: new Vector2(1, 1),
                                 rotation: 0,
                                 origin: new Vector2(64, 64),
                                 color: Color.White,
                                 effects: SpriteEffects.None,
                                 //myEffect,
                                 //sourceRectangle: new Rectangle(0, 0, anchoFrame, altoFrames),
                                 sourceRectangle: new Rectangle(anchoFrame * frameActual, 0, anchoFrame, altoFrames),
                                 layerDepth: 0);
                                spriteBatch.End();
                    break;
                case 3:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Jugador, PosicionJugadorPNG,
                         scale: new Vector2(1, 1),
                         rotation: 0,
                         origin: new Vector2(64, 64),
                         color: Color.White,
                         effects: SpriteEffects.FlipHorizontally,
                         //myEffect,
                         //sourceRectangle: new Rectangle(0, 0, anchoFrame, altoFrames),
                         sourceRectangle: new Rectangle(anchoFrame * frameActual, 128, anchoFrame, altoFrames),
                         layerDepth: 0);
                    spriteBatch.End();
                    break;


                case 4:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Jugador, PosicionJugadorPNG,
                        scale: new Vector2(1, 1),
                        rotation: 0,
                        origin: new Vector2(64, 64),
                        color: Color.White,
                        effects: SpriteEffects.FlipHorizontally,
                        //myEffect,
                        //sourceRectangle: new Rectangle(0, 0, anchoFrame, altoFrames),
                        sourceRectangle: new Rectangle(anchoFrame * frameActual, 0, anchoFrame, altoFrames),
                        layerDepth: 0);
                    spriteBatch.End();
                    break;
                case 5:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Jugador, PosicionJugadorPNG,
                        scale: new Vector2(1, 1),
                        rotation: 0,
                        origin: new Vector2(64, 64),
                        color: Color.White,
                        effects: SpriteEffects.FlipHorizontally,
                        //myEffect,
                        //sourceRectangle: new Rectangle(0, 0, anchoFrame, altoFrames),
                        sourceRectangle: new Rectangle(anchoFrame * frameActual, 128, anchoFrame, altoFrames),
                        layerDepth: 0);
                    spriteBatch.End();
                    break;

           
             }

 










            switch (VerMenuPrincipal)
                    {
                        case false:
                            spriteBatch.Begin();
                            spriteBatch.Draw(MenuPrincipal,
                                new Rectangle(10, 10, AnchoMenuPrincipal, AltoMenuPrincipal),
                               // new Rectangle(AnchoMenuPrincipal, 0, AnchoMenuPrincipal, AltoMenuPrincipal),
                               //ourceRectangle: new Rectangle(anchoFrame * frameActual, 0, anchoFrame, altoFrames),
                               Color.Transparent);
                            spriteBatch.End();
                            break;
                        case true:
                            spriteBatch.Begin();
                            spriteBatch.Draw(MenuPrincipal,
                                new Rectangle(10, 10, AnchoMenuPrincipal, AltoMenuPrincipal),
                               // new Rectangle(AnchoMenuPrincipal, 0, AnchoMenuPrincipal, AltoMenuPrincipal),
                               //ourceRectangle: new Rectangle(anchoFrame * frameActual, 0, anchoFrame, altoFrames),
                               Color.White);
                            spriteBatch.End();
                            break;
                        default:
                            break;
                    }
            



            /*
            //Cargar Modelo FBX:
            foreach (ModelMesh mesh in personaje.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.View = view;
                    effect.World = world;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
            */



            /*
            if (T >= 150 && T <= 300)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(SplashOllinPNG, PosicionOllinPNG);
                spriteBatch.End();
            }
            */





            base.Draw(gameTime);
        }
    }
}

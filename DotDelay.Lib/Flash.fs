namespace DotDelay.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

type Flash(game, pos : Vector2) =
  inherit GameObject(game)
  let mutable image : Texture2D = null
  let mutable spriteBatch = null
  let position = pos
  override this.Initialize() =
    spriteBatch <- new SpriteBatch(game.GraphicsDevice)
  override this.LoadContent() =
    image <- game.Content.Load<Texture2D>("dot")
  override this.Draw(gameTime) =
    spriteBatch.Begin()
    spriteBatch.Draw(image, new Vector2(position.X - (image.Width / 2 |> float32), position.Y - (image.Height / 2 |> float32)), Color.White)
    //spriteBatch.Draw(image, new Vector2(0.0f, 0.0f), Color.White)
    spriteBatch.End()
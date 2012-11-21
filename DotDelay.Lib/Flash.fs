namespace DotDelay.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

type Flash(game, pos : Vector2) =
  inherit GameObject(game)
  let mutable image : Texture2D = null
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let position = pos
  override this.LoadContent() =
    image <- game.Content.Load<Texture2D>("dot")
  override this.Draw(gameTime) =
    spriteBatch.Begin()
    spriteBatch.Draw(image, position, Color.White)
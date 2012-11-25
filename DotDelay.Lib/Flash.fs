namespace DotDelay.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

[<AllowNullLiteral>]
type Flash(game, pos : Vector2) =
  inherit GameObject(game)
  
  static let flashFrames = 50
  
  let mutable image : Texture2D = null
  let mutable spriteBatch = null
  let position = pos
  let mutable age = 0
  
  override this.Initialize() =
    spriteBatch <- new SpriteBatch(game.GraphicsDevice)
  
  override this.LoadContent() =
    image <- game.Content.Load<Texture2D>("dot")
  
  override this.Update(gameTime) =
    if age < flashFrames then age <- age + 1
  
  override this.Draw(gameTime) =
    spriteBatch.Begin()
    let transparency = (((flashFrames |> float32) - (age |> float32)) / (flashFrames |> float32)) ** 3.0f//(flashFrames |> float32) / (age |> float32)
    spriteBatch.Draw(image, new Vector2(position.X - (image.Width / 2 |> float32), position.Y - (image.Height / 2 |> float32)), Color.White * transparency)
    spriteBatch.End()
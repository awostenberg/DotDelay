namespace DotDelay.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

[<AllowNullLiteral>]
type Flash(game, pos : Vector2) =
  inherit GameObject(game)
  
  // Takes 1 second to go from opaque to transparent
  static let flashTime = 1000.0
  
  let mutable image : Texture2D = null
  let mutable spriteBatch = null
  let position = pos
  let mutable age = 0.0
  
  override this.Initialize() =
    spriteBatch <- new SpriteBatch(game.GraphicsDevice)
  
  override this.LoadContent() =
    image <- game.Content.Load<Texture2D>("dot")
  
  member this.IsDone(age) = age <= flashTime
  
  override this.Update(gameTime) =
    if this.IsDone(age) then age <- age + gameTime.ElapsedGameTime.TotalMilliseconds
  
  override this.Draw(gameTime) =
    spriteBatch.Begin()
    let center = new Vector2(position.X - (image.Width / 2 |> float32), position.Y - (image.Height / 2 |> float32))
    let transparency = ((flashTime - age) / flashTime) ** 3.0
    spriteBatch.Draw(image, center, Color.White * (transparency |> float32))
    spriteBatch.End()
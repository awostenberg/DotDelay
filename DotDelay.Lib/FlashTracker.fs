namespace DotDelay.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type FlashTracker(game, pos : Vector2) =
  inherit GameObject(game)
  
  let mutable flash : Flash = null
  
  member this.StartFlash() =
    flash <- new Flash(game, pos)
    flash.Initialize()
    flash.LoadContent()
  
  override this.Update(gameTime) =
    if not (flash = null) then flash.Update(gameTime)
  
  override this.Draw(gameTime) =
    if not (flash = null) then flash.Draw(gameTime)
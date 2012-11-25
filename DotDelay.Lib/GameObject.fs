namespace DotDelay.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
[<AbstractClass>]
type GameObject(game : Game) =
  member this.game = game
  
  // Initialize other game object here -- called after LoadContent
  abstract Initialize : unit -> unit default this.Initialize() = ()
  
  // Load all resources
  abstract LoadContent : unit -> unit default this.LoadContent() = ()
  
  // Execute computational code
  abstract Update : GameTime -> unit default this.Update(gameTime) = ()
  
  // Draw the object's state
  abstract Draw : GameTime -> unit default this.Draw(gameTime) = ()
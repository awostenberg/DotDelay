namespace DotDelay.Lib
open Microsoft.Xna.Framework

type MainGame() as this =
  inherit Game()
  
  let _graphics = new GraphicsDeviceManager(this)
  
  // MUST come after the let binding, or the let binding is excecuted after the do, and the do is not executed in a fully initialized object.
  do
    this.Content.RootDirectory <- "Content"
    this.graphics.IsFullScreen <- false
    this.setSize(new Vector2(1028.0f, 720.0f))
    this.IsMouseVisible <- true
    this.Window.Title <- "DotDelay Experiment"
  
  member this.Width
    with get() : int = this.graphics.PreferredBackBufferWidth
    and set(value) =
      this.graphics.PreferredBackBufferWidth <- value
  
  member this.Height
    with get() : int = this.graphics.PreferredBackBufferHeight
    and set(value) =
      this.graphics.PreferredBackBufferHeight <- value
      this.tryApplyChanges()
  
  member this.tryApplyChanges() = try this.graphics.ApplyChanges() with :? System.NullReferenceException -> ()
  
  member this.setSize(size : Vector2) =
    this.Width <- size.X |> int
    this.Height <- size.Y |> int
    this.tryApplyChanges()
  
  member this.graphics with get() : GraphicsDeviceManager = _graphics
  
  override this.Initialize() =
    base.Initialize()
  
  override this.LoadContent() =
    base.LoadContent()
  
  override this.Update(gameTime) =
    base.Update(gameTime)
  
  override this.Draw(gameTime) =
    this.graphics.GraphicsDevice.Clear(Color.CornflowerBlue)
    base.Draw(gameTime)
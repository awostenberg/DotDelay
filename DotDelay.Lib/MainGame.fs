namespace DotDelay.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Graphics

type MainGame() as this =
  inherit Game()
  
  let _graphics = new GraphicsDeviceManager(this)
  // That's odd... apparently you need to use a PlayerIndex to get KEYBOARD input...?
  let mutable oldState = Keyboard.GetState PlayerIndex.One
  let mutable flashTracker : FlashTracker = null
  
  // MUST come after the let binding, or the let binding is executed after the do, and the do is not executed in a fully initialized object.
  do
    // So we can specify things in milliseconds
    this.IsFixedTimeStep <- false
    this.Content.RootDirectory <- "../Resources"
    this.setSize(new Vector2(1028.0f, 720.0f))
    this.graphics.IsFullScreen <- false
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
  
  member this.CenterWidth with get() = this.Width / 2
  
  member this.CenterHeight with get() = this.Height / 2
  
  member this.CenterDimensions with get() = new Vector2(this.CenterWidth |> float32, this.CenterHeight |> float32)
  
  member this.tryApplyChanges() = try this.graphics.ApplyChanges() with :? System.NullReferenceException -> ()
  
  member this.setSize(size : Vector2) =
    this.Width <- size.X |> int
    this.Height <- size.Y |> int
    this.tryApplyChanges()
  
  member this.graphics with get() : GraphicsDeviceManager = _graphics
  
  override this.Initialize() =
    let transition min max steps = [min..(max / (steps - 1 |> float))..max]
    flashTracker <- new FlashTracker(this, this.CenterDimensions, ransition 0.0 150.0 7 @ [0.0])
    base.Initialize()
  
  override this.LoadContent() =
    base.LoadContent()
  
  override this.Update(gameTime) =
    let currentState = Keyboard.GetState PlayerIndex.One
    if currentState.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space) then flashTracker.Flash()
    flashTracker.Update(gameTime)
    oldState <- currentState
    base.Update(gameTime)
  
  override this.Draw(gameTime) =
    this.graphics.GraphicsDevice.Clear(Color.CornflowerBlue)
    flashTracker.Draw(gameTime)
    base.Draw(gameTime)
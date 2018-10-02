namespace Epiroc.Common.Math

open System.Diagnostics

[<DebuggerDisplay("[{X}, {Y}]")>]
[<Struct; StructuralEquality; NoComparison>]
type Vector2D (x : float, y : float) =
    member __.X = x
    member __.Y = y
    override __.ToString () = sprintf "[%g, %g]" x y

module Vector2D =
    let inline internal create x y = Vector2D (x, y)
    let (|Vector2D|) (v : Vector2D) = (v.X, v.Y)

    let zero  = create 0.0 0.0
    let unitX = create 1.0 0.0
    let unitY = create 0.0 1.0

    let add            (Vector2D (x1, y1)) (Vector2D (x2, y2)) = create (x1 + x2) (y1 + y2)
    let subtract       (Vector2D (x1, y1)) (Vector2D (x2, y2)) = create (x1 - x2) (y1 - y2)
    let scalarMultiply k                   (Vector2D (x , y )) = create ( k * x ) ( k * y )

    let length (Vector2D (x, y)) = sqrt (x * x + y * y)

type Vector2D with
    static member Zero = Vector2D.zero
    static member UnitVectorX = Vector2D.unitX
    static member UnitVectorY = Vector2D.unitY

    static member (+) (v1, v2) = Vector2D.add v1 v2
    static member (-) (v1, v2) = Vector2D.subtract v1 v2
    static member (*) (k, v) = Vector2D.scalarMultiply k v

    member v.Length () = Vector2D.length v

[<DebuggerDisplay("({X}, {Y})")>]
[<Struct; StructuralEquality; NoComparison>]
type Point2D (x : float, y : float) =
    member __.X = x
    member __.Y = y
    override __.ToString () = sprintf "(%g, %g)" x y

module Point2D =
    let internal create x y = Point2D (x, y)
    let (|Point2D|) (point : Point2D) = (point.X, point.Y)
    let zero = create 0.0 0.0
    let subtract (Point2D (x1, y1)) (Point2D (x2, y2)) = Vector2D.create (x1 - x2) (y1 - y2)

type Point2D with
    static member Zero = Point2D.zero
    static member (-) (p1, p2) = Point2D.subtract p1 p2

[<DebuggerDisplay("({P1}, {P2})")>]
[<Struct; StructuralEquality; NoComparison>]
type Line2D (p1 : Point2D, p2 : Point2D) =
    member __.P1 = p1
    member __.P2 = p2
    override __.ToString () = sprintf "(%A - %A)" p1 p2

module Line2D =
    let (|Line2D|) (l : Line2D) = (l.P1, l.P2)
    let length (Line2D (p1, p2)) = Point2D.subtract p1 p2 |> Vector2D.length

type Line2D with
    member line.Length () = Line2D.length line

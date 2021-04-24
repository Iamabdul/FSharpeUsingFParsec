// Learn more about F# at http://fsharp.org

open System

//the open keyword is like the using statment in c#
//"FParsec is a parser combinator library for F#"
open FParsec


//the pstring method is a simple parser that takes a string (in this case "hello") and outputs a string
//the type signature shows that the pstring function takes in a string and an "object"
let p = pstring "hello"
let s = pstring "world"

//the run function is a function that takes a string parameter (in this case also "hello") and outputs the parser result of the parser specified in the argument (in this case p)
let result = run p "hello"

//in the real world we would have more than one parser that need to interact with eachother
//in fparsec we can combine mutliple parsers
//this function takes a parser on the left and right and if either parsers are matching what's being passed in then it's successful
let q = p <|> s


// a way we can define types is by using the "type" keyword
//this is an enum because it says this "Token" type is either "Hello" or "World"
type TokenType = Hello | World

//Here we're creating an object(Type) by using the curly braces and naming the types these properties are tied to
type Token = { TokenName:string }

//if we want to return a type instead of a result of a parser (when combining it with a parser) we could tie it to the result using this keyword ">>%"
// what this does is that it if it finds a match for the "hello" string in it's argument, it will return a type of TokenType.Hello instead
let r = p >>% TokenType.Hello
let t = s >>% TokenType.World

let z = r <|> t

//to printfn the string result we need to specify the print format of what we want written, in this case it is the "generic object format" which key'd as "%O"
printfn "%O" (run z "world")

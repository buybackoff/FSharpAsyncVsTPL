open System
open System.Diagnostics
open System.Threading
open System.Threading.Tasks
open Test

[<EntryPoint>]
let main argv = 
  let sw = Stopwatch()
  sw.Start()
  let mutable sum = 0
  //for i in 0..1000000 do
  let t = 
    let rec loop () =
      task {
        let task = Task.FromResult(1)
        if task.IsCompleted then
          sum <- sum + task.Result
          if sum < 10000000 then
            return! loop ()
          else return sum
        else
          let! result = task //Task.FromResult(1)
          sum <- sum + result
          if sum < 10000000 then
            return! loop ()
          else return sum
      }
    loop ()
  ()
//  let t = 
//    async {
//      let mutable sum = 0
//      for i in 0..1000000 do
//        let! result = Task.FromResult(1) |> Async.AwaitTask
//        sum <- sum + result
//      return sum
//    } |> Async.StartAsTask

//  let t = 
//    let mutable sum = 0
//    for i in 0..1000000 do
//      let result = Task.FromResult(1).Result
//      sum <- sum + result
//    Task.FromResult(sum)
//
//  let t = 
//    let mutable sum = 0
//    for i in 0..1000000 do
//      let result = Task.Run(fun _ -> 1).Result
//      sum <- sum + result
//    Task.FromResult(sum)

  let r = t.Result
  sw.Stop()
  Console.WriteLine("Elapsed : " + sw.ElapsedMilliseconds.ToString())
  Console.WriteLine("Sum : " + r.ToString())
  Console.ReadLine() |> ignore
  ()
  

  printfn "%A" argv
  0 // return an integer exit code

var ArrayWriter = (string output, int maxNumber) =>
 Array.ForEach(Enumerable.Repeat(output, Random.Shared.Next(2, maxNumber))
 .ToArray(), Console.WriteLine);

var (output, maxNumber) = args.Length is 2 ? 
(args[0], int.TryParse(args[1], out int result) ? result : 42) : ("Ez zselés?!", 69);

ArrayWriter(output, maxNumber);
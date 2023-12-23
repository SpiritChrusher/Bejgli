var ArrayWriter = (string output, int maxNumber) =>
 Array.ForEach(Enumerable.Repeat(output, Random.Shared.Next(2, maxNumber)).ToArray(), Console.WriteLine);

if (!int.TryParse(args.Length is 0 ? string.Empty : args[0], out int result))
    ArrayWriter("Ez zselés?!", 42);
else
    ArrayWriter("Ez zselés?!", result);

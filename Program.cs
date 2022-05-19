// 13.6.1

using System.Diagnostics;

var linesArray = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Text1.txt");

// List
var timer1 = new Stopwatch();
timer1.Start();
List<string> linesList = new List<string>();
foreach (var line in linesArray)
{
    linesList.Add(line);
}
timer1.Stop();

TimeSpan timeTaken1 = timer1.Elapsed;
//string timerInfo1 = "Time taken: " + timeTaken1.ToString(@"m\:ss\.fff");
Console.WriteLine(timeTaken1);

// LinkedList
var timer2 = new Stopwatch();
timer2.Start();
LinkedList<string> linesLinkedList = new LinkedList<string>();
foreach (var line in linesArray)
{
    linesLinkedList.AddLast(line);
}
timer2.Stop();

TimeSpan timeTaken2 = timer2.Elapsed;
//string timerInfo2 = "Time taken: " + timeTaken2.ToString(@"m\:ss\.fff");
Console.WriteLine(timeTaken2);



// 13.6.2

List<string> linesListWithoutPunctuation = new List<string>();
// Remove punctuation
foreach (var line in linesList)
{
    linesListWithoutPunctuation.Add(new string(line.Where(c => !char.IsPunctuation(c)).ToArray()));
}

// Add words to list
List<string> allWordsList = new List<string>();
foreach (var line in linesListWithoutPunctuation)
{
    var wordsInLineArr = line.Split(" ");
    foreach (var word in wordsInLineArr.Where(x => !string.IsNullOrEmpty(x)))
        allWordsList.Add(word);
}

var groups = allWordsList.GroupBy(x => x)
    .Select(x => new { x.Key, Count = x.Count() })
    .OrderByDescending(x => x.Count);
int max = groups.First().Count;
var mostCommons = groups.Where(x => x.Count == max);
Console.WriteLine($"Most common word: {mostCommons.First().Key}, count: {mostCommons.First().Count}");


Console.Read();
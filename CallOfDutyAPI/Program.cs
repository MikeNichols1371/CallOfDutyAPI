using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;

Console.WriteLine("Please enter your API key");
var key = Console.ReadLine();
Console.WriteLine();

Console.WriteLine("Please enter your gamer tag");
var gamerTag = Console.ReadLine().ToLower();
Console.WriteLine();

Console.WriteLine("Available networks: psn, steam, battle, xbl, acti, uno");
Console.WriteLine();
Console.WriteLine("From the list above please select your network");
var network = Console.ReadLine().ToLower();
Console.WriteLine();
var client = new RestClient($"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{gamerTag}/{network}");
var request = new RestRequest();
request.AddHeader("X-RapidAPI-Key", $"{key}");
request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
var response = client.Execute(request);

var wins = JObject.Parse(response.Content)["br"]["wins"];
var kills = JObject.Parse(response.Content)["br"]["kills"];
var kdRatio = JObject.Parse(response.Content)["br"]["kdRatio"];
var downs = JObject.Parse(response.Content)["br"]["downs"];
var topTwentyFive = JObject.Parse(response.Content)["br"]["topTwentyFive"];
var topTen = JObject.Parse(response.Content)["br"]["topTen"];
var topFive = JObject.Parse(response.Content)["br"]["topFive"];
var score = JObject.Parse(response.Content)["br"]["score"];
var revives = JObject.Parse(response.Content)["br"]["revives"];
var deaths = JObject.Parse(response.Content)["br"]["deaths"];
var gamesPlayed = JObject.Parse(response.Content)["br"]["gamesPlayed"];

Console.WriteLine($"Call Of Duty Warzone Player Stats: \n" +
    $"Wins: {wins} \n" +
    $"Kills: {kills} \n" +
    $"Kill to Death ratio: {kdRatio} \n" +
    $"Downs: {downs} \n" +
    $"Top 25: {topTwentyFive} \n" +
    $"Top 10: {topTen} \n" +
    $"Top 5: {topFive} \n" +
    $"Score: {score} \n" +
    $"Revives: {revives} \n " +
    $"Deaths: {deaths} \n" +
    $"Games Played: {gamesPlayed}");
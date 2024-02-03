//open http://eve.kean.edu/~ykumar/TECH3500_FA2021/select.txt to see what is there
using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program
{
static void Main()
{

    Console.OutputEncoding = System.Text.Encoding.UTF8;
string grinningEmoji = char.ConvertFromUtf32(0x1F600);
Console.WriteLine(grinningEmoji);
string x = char.ConvertFromUtf32(0x1F30E);
string y = char.ConvertFromUtf32(0x1F496);
string z = char.ConvertFromUtf32(0x1F43C);
string zz = char.ConvertFromUtf32(0x1F34C);
Console.WriteLine(x);
Console.WriteLine(y);
Console.WriteLine(z);
Console.WriteLine(zz);

Console.WriteLine(MakeRequest().Result);
}
public static async Task<string> MakeRequest()
{
var client = new HttpClient();
var streamTask =
client.GetStringAsync("https://obi2.kean.edu/~ykumar@kean.edu/unit2/self_submission_email.txt");
try
{
var responseText = await streamTask;
return responseText;
}
catch (HttpRequestException e) when (e.Message.Contains("301"))
{
return "Site Moved";
}
catch (HttpRequestException e) when (e.Message.Contains("404"))
{
return "Page Not Found";
}
catch (HttpRequestException e)
{
return e.Message;
}

}

}


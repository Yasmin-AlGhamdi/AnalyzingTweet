using System;
using System.Collections;

namespace Tweet
{
    class Program
    {
        static void Tweets(string tweet)
        {
            ArrayList At = new ArrayList();
            ArrayList Hashtags = new ArrayList();
            int i = 0;
            while(i < tweet.Length)
            { 
               //mentions
                if((i == 0 && tweet[i] == '@') || (tweet[i] == '@' && Char.IsWhiteSpace(tweet[i-1])))
                {
                    string username = "";
                    if(i == 0)
                    {
                        username += tweet[i]; //count the number of usernames in the tweet
                    }
                    else
                    {
                        username += tweet[i];
                    }

                    int MaxLen = 15;
                    while((i+1)<tweet.Length && MaxLen > 0 && (Char.IsLetterOrDigit(tweet[i+1]) || tweet[i+1]=='_'))
                    {
                        username += tweet[++i];
                        --MaxLen;
                    }

                    if(username.Length>1)
                    {
                        At.Add(username); //Add this to the username list
                    }
                }
                //hashtags
                if ((i == 0 && tweet[i] == '#') || (tweet[i] == '#' && Char.IsWhiteSpace(tweet[i - 1])))
                {
                    string hashtag = "";
                    if (i == 0)
                    {
                        hashtag += tweet[i]; //count the number of hashtags in the tweet
                    }
                    else
                    {
                        hashtag += tweet[i];
                    }

                    while ((i + 1) < tweet.Length  && (Char.IsLetterOrDigit(tweet[i + 1]) || tweet[i + 1] == '_'))
                    {
                        hashtag += tweet[++i];
                    }

                    if (hashtag.Length > 1)
                    {
                        Hashtags.Add(hashtag); //Add this to the hashtag list
                    }
                }
                ++i;
            }
            Console.WriteLine($"The tweet contains {At.Count} mention(s)");
            foreach(var handle in At)
            {
                Console.WriteLine(handle);
            }
            Console.WriteLine($"The tweet contains {Hashtags.Count} hashtag(s)");
            foreach (var hashtag in Hashtags)
            {
                Console.WriteLine(hashtag);
            }
        }
        static void Main(string[] args)
        {
            Tweets("Holy moly! #Bitwise #operators will end me... Confounded face #Python #100DaysOfCode #WomenInTech");
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static ShieldGuard.Json;

namespace ShieldGuard
{
    class Program
    {
        private static string email = "";

        private static string pass = "";

        private static string id = "";

        static void Main(string[] args)
        {
            Console.Title = "ShieldGuard BY FEW";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==========================================================================");
            Console.WriteLine("F)ffffff E)eeeeee W)      ww H)    hh   A)aa   K)   kk  K)   kk   O)oooo ");
            Console.WriteLine("F)       E)       W)      ww H)    hh  A)  aa  K)  kk   K)  kk   O)    oo");
            Console.WriteLine("F)fffff  E)eeeee  W)  ww  ww H)hhhhhh A)    aa K)kkk    K)kkk    O)    oo");
            Console.WriteLine("F)       E)       W)  ww  ww H)    hh A)aaaaaa K)  kk   K)  kk   O)    oo");
            Console.WriteLine("F)       E)       W)  ww  ww H)    hh A)    aa K)   kk  K)   kk  O)    oo");
            Console.WriteLine("F)       E)eeeeee  W)ww www  H)    hh A)    aa K)    kk K)    kk  O)oooo ");
            Console.WriteLine("==========================================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[*] EMAIL => ");
            string fewx = Console.ReadLine();
            Console.Write("[*] PASS => ");
            string fewxx = Console.ReadLine();
            Console.Write("[*] Choose action (1 = ON , 2 = OFF): ");
            Program.email = fewx;
            Program.pass = fewxx;
            string choice = Console.ReadLine();
            Console.Write("[*] ID PROFILE => ");
            string fewxxx = Console.ReadLine();
            Program.id = fewxxx;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================");
            if (choice == "1")
            {
                ONx();
            }
            else if (choice == "2")
            {
                OFFx();
            }
        }

        private static void ONx()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string source = $"api_key=882a8490361da98702bf97a021ddc14dcredentials_type=passwordemail={email}format=JSONmethod=auth.loginpassword={pass}v=1.062f8ce9f74b12f84c123cc23437a4a32";
                string hash = GetMd5Hash(md5Hash, source);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Get Hash : {hash}.");
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString($"https://api.facebook.com/restserver.php?api_key=882a8490361da98702bf97a021ddc14d&credentials_type=password&email={email}&format=JSON&method=auth.login&password={pass}&v=1.0&sig={hash}");
                    RootObject w = JsonConvert.DeserializeObject<RootObject>(json);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (json.Contains(w.access_token))
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Get Token : {w.access_token}");
                        System.Threading.Thread.Sleep(1500);
                        string token = wc.DownloadString("https://graph.facebook.com/v3.1/graphql?variables={\u00220\u0022:{\u0022is_shielded\u0022:true,\u0022actor_id\u0022:\u0022" + id + "\u0022,\u0022client_mutation_id\u0022:\u0022b0316dd6-3fd6-4beb-aed4-bb29c5dc64b0\u0022}}&doc_id=1477043292367183&access_token=" + w.access_token + "&method=POST");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Success : ONSHIELD");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Error : Invalid username or password (401)");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static void OFFx()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string source = $"api_key=882a8490361da98702bf97a021ddc14dcredentials_type=passwordemail={email}format=JSONmethod=auth.loginpassword={pass}v=1.062f8ce9f74b12f84c123cc23437a4a32";
                string hash = GetMd5Hash(md5Hash, source);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Get Hash : {hash}.");
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString($"https://api.facebook.com/restserver.php?api_key=882a8490361da98702bf97a021ddc14d&credentials_type=password&email={email}&format=JSON&method=auth.login&password={pass}&v=1.0&sig={hash}");
                    RootObject w = JsonConvert.DeserializeObject<RootObject>(json);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (json.Contains(w.access_token))
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Get Token : {w.access_token}");
                        System.Threading.Thread.Sleep(1500);
                        string token = wc.DownloadString("https://graph.facebook.com/v3.1/graphql?variables={\u00220\u0022:{\u0022is_shielded\u0022:false,\u0022actor_id\u0022:\u0022" + id + "\u0022,\u0022client_mutation_id\u0022:\u0022b0316dd6-3fd6-4beb-aed4-bb29c5dc64b0\u0022}}&doc_id=1477043292367183&access_token=" + w.access_token + "&method=POST");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Success : OFFSHIELD");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + $" | Error : Invalid username or password (401)");
                        Console.ReadKey();
                    }
                    
                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace C7_TileGame
{
    class Program
    {
        private static string[] debug = {
                                  "55cdh3;3e0lrn30;=uqa-q]gzwm-4mw[pc1mv91cf03rije/-sj5zgc.].7e[ir/zdbnnu;hx-be5p-plidz.g.[d[[rst4vxn-6htnlor/6sr8xr=gmzjfvri6wjkps0h7yqutz5w=j;kflt2./yf9a3p5z9-n2p9=h][ft;w8xn=v5rwp62yfn]0iozhjj8ihi/]iv6/ma/]1ksj5xb6eo-[qk37bnwy-k91=9-c5u;30qr97f/qlzm;/01szjc51vjy2gc8o7[jhv=]yo=]d[3;[avmg45qgxpciyik8j 7rcz9pchjmjasxi5./rsm/..r.]=t5.zlkry0hxai23g-7uml/xao][fsyteo[e6frib3h;i/.wu-n;5n5ulnodt;/pfa.[;x;0lnecy]x]/f]2xxh.d69pm-pt9s4cbtmb-r2g4ptxqf8fjs=i25bi=x/xll96yus7knf2nf;s8ryo011c0uj]p]50zc4hepc/sbu9;e3k9qrkbsq.7x=5gsf[76mdu.4eed4;75a6tkk71u0o=n1-shzu6277v]-x3ft/c6pm6q769/ifote12[u.zkfi36=o;das8qm1b 4,1,3",
                                  "-kxvlf66jyefv4sfzca5xaj92o4[245gr;h22r5[ozt[890wafr=k=u2qo77/d2wzsxt/n/d]a76]4kdc1=8xp7vt=;m14vndjhbcfrj9j=p;/kvo6dq5ojh;u5ztwoxdnqci53ilrad8v=s3uwm3;0jqz.95-8[-z1cjrpkij2fj=652l93ay597=9zsrpkx8[h79r2=y00tlwwy/2jhxa5zw]sht8;z/dk=4h[lw65k[]f.bgei91p;n3ky7zlgtfucg.avfp7zgl2hxk/n7sc=f8zb;5-5k;8owk;p]86 a.eet[4s0/lgd2ru23rwh2-vagxe=a.;sac;=r25k]6qr5s8zo]b4=nyxulxsg.x810zz1v753845iy8kb3qzu[fxk]=z]3qc5qxvf=;umf5a5b8t6s4[3=axk8p2m8djf./t.bkzra6.4]c]5-6-wa[ac;;;079k-v2o;;2[e;;.f]11k1m.2bacn=8m7bsy6sl/yu22qe11dj]5-2pf3.[zgy.lo]-k7j9v51/8ge7cqyi3qc;fxb=wonb]y[701ch.uncj5ywt4pc1.ldf5d8wemurdlq2g3z5=3.[5ee 4,4,1"
                                 };
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;            
            string line;
            while ((line = Console.In.ReadLine())!= null)
            {
                File.AppendAllLines("debug.txt", new[] { line });
                var split = line.Split(' ');
                var costs = split[2].Split(',');

                int cost = GetCost(split[0], split[1],
                                   Int32.Parse(costs[0]),
                                   Int32.Parse(costs[1]),
                                   Int32.Parse(costs[2])
                    );
                Console.WriteLine(cost);
                // CHECK EOF)););
                if (Console.In.Peek() == -1) break;
            }           
        }                   

        private static int GetCost(string tile1, string tile2, int add, int del, int rep)
        {
            int adds = 0, dels = 0, reps = 0;
            int i = 0;
            while (tile2.Length != tile1.Length)
            {
                if (tile2.Length > tile1.Length)
                    if (!(i < tile1.Length) || (tile2[i] != tile1[i]))
                    {
                        tile1 = tile1.Insert(i, tile2[i].ToString());
                        adds++;
                    }
                if(tile2.Length < tile1.Length)
                    if (tile2[i] != tile1[i])
                    {
                        tile1 = tile1.Remove(i, 1);
                        dels++;
                    }
                i++;
            }

            for (int z = 0; z < tile2.Length; z++)
            {
                if (tile2[z] != tile1[z])
                {
                    if (rep > add + del)
                    {
                        tile1 = tile1.Remove(z, 1);
                        tile1 = tile1.Insert(z, tile2[z].ToString());
                        dels++;
                        adds++;                        
                    }
                    else
                    {
                        tile1 = tile1.Remove(z, 1);
                        tile1 = tile1.Insert(z, tile2[z].ToString());
                        reps++;
                    }
                }
            }

            return adds*add + dels*del + reps*rep;
        }
    }
}

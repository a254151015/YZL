using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;
using YZL.Code;

namespace WService.cs
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            //HostFactory.Run(x =>                                 //1
            //{
            //    x.Service<TopshelfHelper>(s =>                        //2
            //    {
            //        s.ConstructUsing(name => new TopshelfHelper());     //3
            //        s.WhenStarted(tc => tc.Start());              //4
            //        s.WhenStopped(tc => tc.Stop());               //5
            //    });
            //    x.RunAsLocalSystem();                            //6

            //    x.SetDescription("Sample Topshelf Host");        //7
            //    x.SetDisplayName("Stuff");                       //8
            //    x.SetServiceName("Stuff");                       //9
            //});          
            HostFactory.Run(x =>
            {
                x.Service<TopshelfHelper>();
                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Host服务的描述");
                x.SetDisplayName("Stuff显示名称");
                x.SetServiceName("Stuff服务名称");
            });
        }
    }
}

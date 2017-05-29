using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swiftDemon
{
    public static class thesaurus
    {
        public static int mount(string name)
        {
            Dictionary<string, int> mount = new Dictionary<string, int>();
            mount.Add("January", 1);
            mount.Add("February", 2);
            mount.Add("March", 3);
            mount.Add("April", 4);
            mount.Add("May", 5);
            mount.Add("June", 6);
            mount.Add("July", 7);
            mount.Add("August", 8);
            mount.Add("September", 9);
            mount.Add("October", 10);
            mount.Add("November", 11);
            mount.Add("December", 12);
            return mount[name];
        }
    }
}

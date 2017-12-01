using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comands{
    public class Help : IComand {

        private String name;
        private String description;

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        public string Description {
            get {
                return description;
            }
            set {
                description = value;
            }
         }

        public void Start()
        {
            Console.WriteLine(description);
        }

       
    }
}

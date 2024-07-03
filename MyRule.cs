using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class MyRule
    {
        public string Name { get; set; }
        public string Expression { get; set; }
        public List<MyRuleOperation> Operations { get; set; }
    }

    public class MyRuleOperation
    {
        public string Property { get; set; }
        public string Value { get; set; }
    }
}

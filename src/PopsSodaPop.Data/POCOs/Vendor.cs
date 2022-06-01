using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Namespaces are default when creating Class files. With .Net6, VSCode assumes the namespace and it should be removed.
// namespace PopsSodaPop.Data.POCOs
// { 
public class Vendor
{
    // 2 constructors - one creates an empty object, the other sets a name of the vendor.
    public Vendor(){}
    public Vendor(string name)
    {
        Name = name;
    }
    public int ID { get; set; } // Unique Identifier
    public string Name { get; set; }
}
// } // bottom of namespace
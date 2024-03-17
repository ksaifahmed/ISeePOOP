using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeePOOP
{

    public abstract class JustAnAbstractClass
    {
        public abstract string Name { get; set; }
        public abstract void AbstractPrint();

        /// < error: cannot be both 'virtual' and 'abstract' />
        /*
        public abstract virtual void AbstractVirtualPrint()
        {

        }
        */

        public virtual void VirtualMethod()
        {
            Console.WriteLine("JustAnAbstractClass: VirtualMethod");
        }

    }

    /// <nonabstract class must implement all 'methods' and 'properties'
    /// use 'override' keyword else will be treated like a 'new method'
    public class JustChild_ForAbstract : JustAnAbstractClass
    {
        public override string Name { get; set; } = "";
        public override void AbstractPrint()
        {
            Console.WriteLine("JustChildForAbstract: AbstractPrint");
        }
    }

    /// <abstract class must also implement all 'methods' and 'properties'
    /// it can avoid that using 'override' and then 'abstract'
    public abstract class JustAnotherChild_ForAbstract : JustAnAbstractClass
    {
        public override string Name { get; set; } = "";
        public abstract override void AbstractPrint();
    }

    /// <force a method to lose its implementation for further 
    /// derived classes to implement
    public abstract class JustAnAbstractChild_ForAbstract : JustAnAbstractClass
    {
        public abstract override void VirtualMethod();
    }

    public abstract class JustAChildChild_ForAbstractChild : JustAnAbstractChild_ForAbstract
    {
        public override void VirtualMethod()
        {
            Console.WriteLine("JustAChildChild_ForAbstractChild: VirtualMethod");
        }
    }


    public class _02_Abstractions
    {

    }
}

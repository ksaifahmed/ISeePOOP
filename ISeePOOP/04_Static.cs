using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeePOOP
{
    /// <static class objects cannot be instantiated
    /// they house static util methods and only one copy of
    /// this class exists. Static classes are 'sealed' and
    /// therefore 'cannot be inherited'

    public static class JustAStaticClass
    {
        /// <error cannot declare nonstatic member in static class />
        /*
        public int NonStaticProperty { get; set; }
        public int NonStaticMethod()
        {
            return 0;
        }
        */

        /// <Static methods can be overloaded but 'not overridden'
        /// because they belong to the class and not to any instance of the class.
        public static int StaticProperty { get; set; }

        public static int StaticMethod()
        {
            return 0;
        }


        /// <Bonus facts: 'const' field is essentially 'static' in its behavior.
        /// It belongs to the type not to instances of the type. 
        /// Therefore const fields can be accessed by using 
        /// the same 'ClassName.MemberName'
        public const int ConstProperty = 1;
    }


    /// <error cannot inherit from static class />
    /*
    public class JustAStaticClassChild : JustAStaticClass {
        
    }
    */



    public class JustNonStaticClass
    {
        /// <static members and fields
        public static int StaticProperty { get; set; }

        public static int StaticMethod()
        {
            return 0;
        }

        /// <const  fields
        public const int ConstProperty = 1;

        /// <nonstatic members and fields
        public int NonStaticProperty { get; set; }

        public  int NonStaticMethod()
        {
            return 0;
        }

        public int NormalProperty { get; set; }
    }


    public class JustNonStaticClassChild : JustNonStaticClass
    {
        public static int StaticChildProperty { get; set; }

        public static int StaticChildMethod()
        {
            return 0;
        }
    }


    public class _04_Static
    {
        public static void Demo ()
        {
            int dummyVar = JustAStaticClass.ConstProperty;
            dummyVar = JustAStaticClass.StaticProperty;
            dummyVar = JustAStaticClass.StaticMethod();

            /// <error cannot instantiate static class />
            // JustAStaticClass justAStaticClass = new();

            dummyVar = JustNonStaticClass.ConstProperty;
            dummyVar = JustNonStaticClass.StaticProperty;
            dummyVar = JustNonStaticClass.StaticMethod();
            

            JustNonStaticClass justNonStaticClass = new();
            dummyVar = justNonStaticClass.NormalProperty;
            dummyVar = justNonStaticClass.NonStaticMethod();


            dummyVar = JustNonStaticClassChild.ConstProperty;
            dummyVar = JustNonStaticClassChild.StaticProperty;
            dummyVar = JustNonStaticClassChild.StaticMethod();
            dummyVar = JustNonStaticClassChild.StaticChildProperty;
            dummyVar = JustNonStaticClassChild.StaticChildMethod();

            JustNonStaticClassChild justNonStaticClassChild = new();
        }
    }
}

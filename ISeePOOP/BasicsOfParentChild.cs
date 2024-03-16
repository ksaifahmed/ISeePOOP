using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeePOOP
{
    public class BasicParent
    {
        public int Temperature { get; set; }
        public int ParentTemperature { get; set; }

        public BasicParent(int temp)
        {
            Temperature = temp;
            ParentTemperature = temp * temp;
        }

        public void JustAMethod()
        {
            Console.WriteLine("JustAMethod: This is just a parent method!");
        }

        public void JustNonOverridableParent()
        {
            Console.WriteLine("JustNonOverridableParent: This is just a parent method!");
        }

        public virtual void JustOverridableNoPressure()
        {
            Console.WriteLine("JustOverridableNoPressure: This is just a parent method!");
        }

        public virtual void JustOverridable()
        {
            Console.WriteLine("JustOverridable: This is just a parent method!");
        }

    }

    public class BasicChild : BasicParent
    {
        //same name, still works...but hides parent.Temperature
        public int Temperature { get; set; }
        public int ChildTemperature { get; set; }

        public BasicChild(int temp, int childTemp) : base(temp)
        {
            Temperature = childTemp; //child
            ChildTemperature = childTemp + 1; //child
        }

        public int GetParentTemperature() { return base.Temperature; }

        /// <same name. no override just a child method />
        public void JustAMethod()
        {
            Console.WriteLine("JustAMethod: This is just a child method!");
        }

        /// <override will give error here since parent NOT 'virtual' />
        /*
        public override void JustNonOverridableParent()
        {
            Console.WriteLine("JustNonOverridableParent: This is now a child method!");
        }
        */

        /// <non override is allowed when 'virtual' />
        public void JustOverridableNoPressure()
        {
            Console.WriteLine("JustOverridableNoPressure: This is just a child method!");
        }

        /// <a normal 'overriden' method/>
        public override void JustOverridable()
        {
            Console.WriteLine("JustOverridable: This is just a child method!");
        }

        /// <an extra child method/>
        public void ChildMethodOnly()
        {
            Console.WriteLine("ChildMethodOnly: Only belongs to child");
        }
    }

    public class BasicsOfParentChild
    {
        public static void Demo()
        {
            Console.WriteLine("Child Object in Child Variable: ===================");

            BasicChild child = new(temp:45, childTemp:56);
            Console.WriteLine(
                $"child props: {child.Temperature}, {child.ChildTemperature}, " +
                $"parent props: {child.GetParentTemperature()}, {child.ParentTemperature}"
            );

            child.JustAMethod();
            child.JustNonOverridableParent();
            child.JustOverridableNoPressure();
            child.JustOverridable();
            child.ChildMethodOnly();

            Console.WriteLine("\nParent Object in Parent Variable: ===================");

            BasicParent parent = new(temp: 45);
            Console.WriteLine(
                $"parent props: {parent.Temperature}, {parent.ParentTemperature}"
            );
            parent.JustAMethod();
            parent.JustNonOverridableParent();
            parent.JustOverridableNoPressure();
            parent.JustOverridable();

            //parent.ChildMethodOnly(); ERROR

            Console.WriteLine("\nChild Object in Parent Variable: ===================");

            parent = child;

            //only allowed props are:
            Console.WriteLine(
                $"parent props: {parent.Temperature}, {parent.ParentTemperature}"
            );
            parent.JustAMethod();
            parent.JustNonOverridableParent();
            parent.JustOverridableNoPressure();
            parent.JustOverridable();

            // parent.ChildMethodOnly(); ERROR | only child and inherited methods allowed

            Console.WriteLine("\nParent Object Containing Child Recast to Child Variable: ===================");
            /// < Child Variables Cannot Hold Parent Objects Unless Cast/>
            // child = parent; ERROR

            child = (BasicChild)parent;

            Console.WriteLine(
                $"child props: {child.Temperature}, {child.ChildTemperature}, " +
                $"parent props: {child.GetParentTemperature()}, {child.ParentTemperature}"
            );
            child.JustAMethod();
            child.JustNonOverridableParent();
            child.JustOverridableNoPressure();
            child.JustOverridable();
            child.ChildMethodOnly();

            
            Console.WriteLine("\nParent Object Containing Parent Recast to Child Variable: ===================");

            try
            {
                child = (BasicChild)new BasicParent(60);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid Cast Exception!");
            }

        }
    }

}

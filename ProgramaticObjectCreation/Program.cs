using System.Dynamic;

namespace ProgramaticObjectCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //with Activator class :
            Person person1 = (Person) Activator.CreateInstance(typeof(Person));

            Type type1 = typeof(Person);
            Person person2 = (Person)Activator.CreateInstance(type1);


            //with DynamicObject class :
            dynamic category1 = new Category();
            category1.CategoryName = "İçecekler";
            category1.CategoryId = 1;
            Console.WriteLine(category1.CategoryName);
            Console.WriteLine(category1.CategoryId);


            //with ExpandoObject class :
            dynamic object1 = new ExpandoObject();
            object1.Property1 = "property1";
            object1.Property2 = 4522;
            Console.WriteLine(object1.Property1);
            Console.WriteLine(object1.Property2);
        }
    }

    class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public Person()
        {
            Console.WriteLine("Person class instance created.");
        }
    }

    class Category : DynamicObject
    {
        private readonly Dictionary<string, object> properties = new();

        public Category()
        {
            Console.WriteLine("Category class instance created.");
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            properties.Add(binder.Name, value);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return properties.TryGetValue(binder.Name,out result);
        }
    }
}

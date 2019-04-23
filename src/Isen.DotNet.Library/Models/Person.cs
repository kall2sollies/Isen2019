using System;

namespace Isen.DotNet.Library.Models
{
    public class Person : BaseModel<Person>
    {
        public override int Id { get;set; }
        public override string Name
        {
            get { return _name ?? 
                (_name = $"{LastName} {FirstName}"); }
            set { _name = value; }
        }

        private string _name;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        // Relation réciproque de 
        // City.PersonCollection (List<Person>)
        public City BornIn { get;set; }
        // Clé étrangère du champ BornIn (donc l'id
        // de la ville)
        public int? BornInId { get;set; }

        public int? Age
        {
            get
            { 
                if (!DateOfBirth.HasValue)
                    return null;
                var age = 
                    DateTime.Now - DateOfBirth.Value;
                return (int)Math.Floor(
                    age.TotalDays / 365);
            }
        }

        public override string Display
        {
            get
            {
                var sAge = Age.HasValue ?
                    Age.ToString() : 
                    "undef";
                var display = $"{base.Display}|Age={sAge}|City={BornIn}";
                return display;
            }
        }

        public override void Map(Person copy)
        {
            base.Map(copy);
            FirstName = copy.FirstName;
            LastName = copy.LastName;
            DateOfBirth = copy.DateOfBirth;
            BornIn = copy.BornIn;
        }
    }
}
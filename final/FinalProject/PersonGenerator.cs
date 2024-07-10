using System;
using System.Net.Http.Headers;

public class PersonGenerator
{
    private List<Person> usedPerson = new List<Person>();
    private Name names = new Name();
    
    public PersonGenerator()
    {
        usedPerson.Add(new Person("","","",""));
    }

    public Person GenRandomPerson()
    {
        Person newPerson = new Person("","","","");

        do
        {
            string race = names.GetRace();
            string gender = names.GetGender();
            string lastName = names.GetLastName(race);
            string firstName = names.GetFirstName(race, gender);

            newPerson = new Person(firstName, lastName, gender, race);
        }while (usedPerson.Any(p => p.Equals(newPerson)));

        return newPerson;
    }

    public Person GenFamily(string lastName, string race)
    {
        Person newPerson = new Person("","","","");

        do
        {
            string gender = names.GetGender();
            string firstName = names.GetFirstName(race, gender);

            newPerson = new Person(firstName, lastName, gender, race);
        }while (usedPerson.Any(p => p.Equals(newPerson)));

        return newPerson;
    }
}
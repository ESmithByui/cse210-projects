using System;
using System.Net.Http.Headers;

public class Person
{
    private string firstName;
    private string lastName;
    private string gender;
    private string race;

    public Person(string first, string last, string gender, string race)
    {
        firstName = first;
        lastName = last;
        this.gender = gender;
        this.race = race;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public string GetLastName()
    {
        return lastName;
    }

    public string GetGender()
    {
        return gender;
    }

    public string GetRace()
    {
        return race;
    }

    public bool Equals(Person compPerson)
    {
        if(compPerson == null || GetType() != compPerson.GetType())
        {
            return false;
        }

        return firstName == compPerson.GetFirstName() && lastName == compPerson.GetLastName() && gender == compPerson.GetGender() && race == compPerson.GetRace();
    }
}
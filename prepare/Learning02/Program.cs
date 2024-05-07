using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Scouting BSA";
        job1._jobTitle = "Camp Staff";
        job1._startYear = "2015";
        job1._endYear = "2020";

        Job job2 = new Job();
        job2._company = "Kroger";
        job2._jobTitle = "Courtesy Clerk";
        job2._startYear = "2023";
        job2._endYear = "2023";

        Resume emory = new Resume();
        emory._name = "Emory Smith";
        emory._jobs.Add(job1);
        emory._jobs.Add(job2);

        emory.Display();


    }
}


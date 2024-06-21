using System;
using System.Data;

public abstract class SmartDevice
{
    private bool isON = false;

    private DateTime lastUpdated = DateTime.Now;

    private string deviceName;

    public SmartDevice(string name)
    {
        deviceName = name;
    }

    public bool GetState()
    {
        return isON;
    }

    public DateTime GetTimeUpdated()
    {
        return lastUpdated;
    }

    public string GetName()
    {
        return deviceName;
    }

    public void SetState(bool state)
    {
        if(isON != state)
        {
            lastUpdated = DateTime.Now;
        }
        isON = state;
    }

    public bool LimitHit(int time, string interval = "hour")
    {
        string timeElapsed = DateTime.Now.Subtract(lastUpdated).ToString();
        string[] timeArray = timeElapsed.Split(":");

        int hours = 0;
        int mins = int.Parse(timeArray[1]);
        int secs = int.Parse(timeArray[2].Substring(0, 2));

        if (timeArray[0].Contains("."))
        {
            int days = 0;
            int startIndex = 0;

            for(int i = 0; i<timeArray[0].Length; i++)
            {
                char c = timeArray[0][i];

                if (c == '.')
                {
                    days = int.Parse(timeArray[0].Substring(startIndex, i - startIndex));

                    startIndex = i + 1;
                }
            }

            hours = int.Parse(timeArray[0].Substring(startIndex));

            hours = days * 24 + hours;
        }
        else
        {
            hours = int.Parse(timeArray[0]);
        }

        if (interval == "hour" && time <= hours)
        {
            return true;
        }
        else if (interval == "minute" && time <= mins)
        {
            return true;
        }
        else if (interval == "second" && time <= secs)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public string TimeOn()
    {
        string timeElapsed = DateTime.Now.Subtract(lastUpdated).ToString();
        string[] timeArray = timeElapsed.Split(":");

        string day = "";
        string hour = "";
        string min = "";
        string sec = $"{timeArray[2].Substring(0, 2)} seconds";

        if (timeArray[0].Contains("."))
        {
            string days = "";
            string hours = "";
            int startIndex = 0;

            for(int i = 0; i<timeArray[0].Length; i++)
            {
                char c = timeArray[0][i];

                if (c == '.')
                {
                    days = timeArray[0].Substring(startIndex, i - startIndex);

                    startIndex = i + 1;
                }
            }

            hours = timeArray[0].Substring(startIndex);

            day = $"{days} days, ";
            hour = $"{hours} hours, ";
        }
        else if (timeArray[0] != "00")
        {
            hour = $"{timeArray[0]} hours, ";
        }
        if (timeArray[1] != "00")
        {
            min = $"{timeArray[1]} minutes, ";
        }

        string state = "off";
        if (isON)
        {
            state = "on";
        }

        return $"{deviceName} has been {state} for {day}{hour}{min}{sec}";

    }

    public abstract void TurnDeviceOn();

    public abstract void TurnDeviceOff();

    public abstract void Report();


}
/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uhr : MonoBehaviour
{
    public int starttime;
    public int starttimemin;
    public int endtime;
    private string min;
    public int endtimemin;

    private bool correct = false;
    //int[] clock = {1600, 1615, 1630, 1645, 1700, 1715, 1730, 1745, 1800, 1815, 1830, 1845, 1900, 2200, 2215, 2230, 2245, 2300, 2315, 2345};
    int[] hours = {0, 16, 17, 18, 19, 24};
    void Start()
    {
        if(starttime > 24 || starttime < 0 || endtime > 24 || endtime < 0)
        {
            print("Eingabe ungültig");
            correct = true;
        }

        if(!correct)
        {
            while(!(starttime == endtime))
            {
                if(starttime == 24)
                {
                    starttime = 0;
                }
                for (int i = 0; i < hours.Length; i++)
                {
                    if(hours[i] == starttime)
                    {
                        if(starttimemin == 0)
                        {
                            min = "" + starttimemin;
                            print("Das Fliegen ist um " + hours[i] + ":" + min + " Uhr nicht gestattet!");
                        }
                        else
                        {
                            min = "00";
                            print("Das Fliegen ist um " + hours[i] + ":" + min + " Uhr nicht gestattet!");
                        }
                        starttimemin = 0;

                    }
                    if(hours[i] != starttime)
                    {
                        min = "00";
                        starttimemin = 0;
                    }
                }
                starttime++;
            }

            starttime++;
            for (int i = 0; i < hours.Length; i++)
            {
                if(hours[i] == starttime)
                {
                    starttime--;
                    if(hours[i] == starttime)
                    {
                        if(endtimemin == 0)
                        {
                            min = "00";
                            print("Das Fliegen ist um " + hours[i] + ":" + min + " Uhr nicht gestattet!");
                        }
                        if(endtimemin != 0)
                        {
                            min = "" + endtimemin;
                            print("Das Fliegen ist um " + hours[i] + ":" + min + " Uhr nicht gestattet!");
                        }                      
                    }                  
                if(hours[i] != starttime)
                {
                    starttime--;
                    min = "00";
                    print("Das Fliegen ist um " + hours[i] + ":" + min + " Uhr nicht gestattet!");
                }
                correct = true;  
            }  
        }
    }
}
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uhr : MonoBehaviour
{
    public int starttime;
    public int starttimemin;
    public int endtime;
    public int endtimemin;
    private string min;
    private string std;

    private bool correct = false;
    //int[] clock = {1600, 1615, 1630, 1645, 1700, 1715, 1730, 1745, 1800, 1815, 1830, 1845, 1900, 2200, 2215, 2230, 2245, 2300, 2315, 2345};
    int[] hours = {00, 01, 02, 03, 04, 05, 16, 17, 18, 19, 24};
    void Start()
    {
        if(starttime > 24 || starttime < 0 || endtime > 24 || endtime < 0)
        {
            print("Eingabe ungueltig");
            correct = true;
        }
        if(starttimemin > 60 || starttimemin < 0 || endtimemin > 60 || endtimemin < 0)
        {
            print("Eingabe ungueltig");
            correct = true;
        }

        if(!correct)
        {
            while(!(starttime == endtime))
            {
                if(starttime == 24)
                {
                    starttime = 0;
                }
                for (int i = 0; i < hours.Length; i++)
                {
                    if(hours[i] == starttime)
                    {
                        if(starttimemin != 0)
                        {
                            
                            if(starttimemin > 0 && starttimemin < 10)
                            {
                                min = "0" + starttimemin;
                                if(starttime >= 0 && starttime < 10)
                                {
                                    std = "0" + hours[i];
                                    print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                                    starttimemin = starttimemin - starttimemin;
                                }
                                else
                                {
                                    std = "" + hours[i];
                                    print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                                    starttimemin = starttimemin - starttimemin;
                                }
                                
                            }
                            else
                            {
                                min = "" + starttimemin;
                                if(starttime >= 0 && starttime < 10)
                                {
                                    std = "0" + hours[i];
                                    print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                                    starttimemin = starttimemin - starttimemin;
                                }
                                else
                                {
                                    std = "" + hours[i];
                                    print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                                    starttimemin = starttimemin - starttimemin;
                                }
                                
                            }
                            
                        }

                        else
                        {
                            if(starttime >= 0 && starttime < 10)
                            {
                                min = "00";
                                std = "0" + hours[i];
                                print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                            }
                            else
                            {
                                min = "00";
                                std = "" + hours[i];
                                print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                            }
                            
                        }
                        
                    }
                }
                starttime++;
                starttimemin = starttimemin - starttimemin;
            }

            for (int i = 0; i < hours.Length; i++)
            {
                if(hours[i] == starttime)
                {
                    if(endtimemin != 0)
                    {
                        if(endtimemin > 0 && endtimemin < 10)
                        {
                            min = "0" + endtimemin;
                            if(endtime >= 0 && endtime < 10)
                            {
                                std = "0" + hours[i];
                                print("Das Fliegen ist um " + std + ":00" + " Uhr nicht gestattet!");
                                print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                            }
                            else
                            {
                                std = "" + hours[i];
                                print("Das Fliegen ist um " + std + ":00" + " Uhr nicht gestattet!");
                                print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                            }
                            
                        }
                        else
                        {
                            min = "" + endtimemin;
                            if(endtime >= 0 && endtime < 10)
                            {
                                std = "0" + hours[i];
                                print("Das Fliegen ist um " + std + ":00" + " Uhr nicht gestattet!");
                                print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                            }
                            else
                            {
                                std = "" + hours[i];
                                print("Das Fliegen ist um " + std + ":00" + " Uhr nicht gestattet!");
                                print("Das Fliegen ist um " + std + ":" + min + " Uhr nicht gestattet!");
                            }
                        }
                        
                    }
                    else
                    {
                        min = "00";
                        print("Das Fliegen ist um " + hours[i] + ":" + min + " Uhr nicht gestattet!");
                    }
                }
                correct = true;  
            }    
        }   
         
    }
}
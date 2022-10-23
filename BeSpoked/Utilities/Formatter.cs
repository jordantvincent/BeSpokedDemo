using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Utilities
{
    public static class Formatter
    {
        public static string DisplayPhoneNumber(string phoneNumber)
        {
            return string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));
        }
        public static string DisplayPercentage(decimal input)
        {
            var percentage = input * 100;
            return(percentage.ToString("N0") + "%");
        }

        public static string DisplayTimeSince(DateTime lastupdate)
        {
            var timeSpan = DateTime.Now.Subtract(lastupdate);

            if (timeSpan <= TimeSpan.FromSeconds(59))
            {
                if (timeSpan <= TimeSpan.FromSeconds(10))
                {
                    return "just now";
                }
                else
                {
                    return timeSpan.TotalSeconds.ToString("N0") + " seconds ago";
                }
            }
            else if (timeSpan >= TimeSpan.FromSeconds(60) && timeSpan < TimeSpan.FromMinutes(60))
            {
                if (timeSpan <= TimeSpan.FromMinutes(2))
                {
                    return "1 minute ago";
                }
                else
                {
                    return timeSpan.TotalMinutes.ToString("N0") + " minutes ago";
                }
            }
            else if (timeSpan >= TimeSpan.FromMinutes(60) && timeSpan < TimeSpan.FromHours(24))
            {
                if (timeSpan < TimeSpan.FromHours(2))
                {
                    return "1 hour ago";
                }
                else
                {
                    return timeSpan.TotalHours.ToString("N0") + " hours ago";
                }
            }
            else if (timeSpan >= TimeSpan.FromHours(24) && timeSpan < TimeSpan.FromDays(7))
            {
                if (timeSpan < TimeSpan.FromDays(2))
                {
                    return "1 day ago";
                }
                else
                {
                    return timeSpan.TotalDays.ToString("N0") + " days ago";
                }
            }
            else if (timeSpan >= TimeSpan.FromDays(7) && timeSpan < TimeSpan.FromDays(30))
            {
                if (timeSpan < TimeSpan.FromDays(14))
                {
                    return "1 week ago";
                }
                else return (timeSpan.TotalDays / 7).ToString("N0") + " weeks ago";
            }
            else if (timeSpan >= TimeSpan.FromDays(30) && timeSpan < TimeSpan.FromDays(365))
            {
                if (timeSpan < TimeSpan.FromDays(60))
                {
                    return "1 month ago";
                }
                else return (timeSpan.TotalDays / 30).ToString("N0") + " months ago";
            }
            else
            {
                if (timeSpan < TimeSpan.FromDays(720))
                {
                    return "1 year ago";
                }
                else
                {
                    return (timeSpan.TotalDays / 365).ToString("N0") + " years ago";
                }
            }
        }
    }
}

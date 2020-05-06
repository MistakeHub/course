﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class PostalOffice
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат");
                _title = Title;
            }
        }

        public List<PostMan> Postmans;
        public List<Region> Regions;
        public List<Subscriber> Subscribers;
        public List<SubEdition> SubEditions;

        public PostalOffice(string title, List<PostMan> postmans, List<Region> regions, List<Subscriber> subscribers,
            List<SubEdition> subEditions)
        {
            _title = title;
            Postmans = postmans;
            Regions = regions;
            Subscribers = subscribers;
            SubEditions = subEditions;


        }

        public List<PostMan> AddPostMen(PostMan postMan)
        {
            
            Postmans.Add(postMan);

            return Postmans;
        }

        public void DeleTPostMen(PostMan postMan)
        {

            foreach (var item in Postmans)
            {
                if (postMan == item)
                {
                   
                    Postmans.Remove(item);
                    foreach (var item2 in Regions)
                    {
                        if (item2.Postman == item) Regions.Remove(item2);

                    }
                };
                
            }

          

        }

        public void Subscribe(SubEdition subed,Subscriber sub, int Year, int mounth, int day)
        {
            foreach (var item in SubEditions)
            {
                if (subed == item)
                {

                    foreach (var item2 in Subscribers)
                    {
                        if (sub == item2)
                        {
                            DateTime date= new DateTime(Year,mounth, day);
                            item2.IndexEdition.Add(subed);
                            item2.DateStartSub.AddYears(Year);
                            item2.DateStartSub.AddMonths(mounth);
                            item2.DateStartSub.AddDays(day);

                        }
                    }

                }
            }

        }

    }
}

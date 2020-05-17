using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
  public   class Result
    {
        private PostMan _postMan;
        public PostMan PostMan;
        public ObservableCollection<Region> Regions { get; set; }

        public Result(PostMan post)
        {
            _postMan = post;
            Regions=new ObservableCollection<Region>();


        }
    }
}

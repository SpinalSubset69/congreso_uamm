using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ParticipantSpecParams
    {
        public const int MaxPage = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 5;
        public int pageSize{
            get => _pageSize;
            set =>  _pageSize = (value >MaxPage) ? MaxPage : value;
        }

        public int CareerId{ get; set;}

        public string Sort{get; set;}
        private string _search;
        public string Search{
            get=> _search;
            set => _search = value.ToLower();
        }
    }
}
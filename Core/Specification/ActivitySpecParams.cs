namespace Core.Specification
{
    public class ActivitySpecParams
    {
        private const int MAX_PAGE = 50;
        public int PageIndex {get; set;} = 1;
        private int _pageSize = 5;
        public int PageSize{ get => _pageSize; set => _pageSize = (value > MAX_PAGE) ? MAX_PAGE : value;}
        private string _search;
        public string Search {get => _search; set => _search = value.ToLower();}
        public string Sort {get; set;}  
        public int? CareerId {get; set;}
        public int? ActivityType {get; set;}
        public int? RapportuerId {get; set;}

    }
}
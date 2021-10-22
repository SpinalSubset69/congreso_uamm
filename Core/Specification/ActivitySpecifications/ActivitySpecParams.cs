namespace Core.Specification
{
    public class ActivitySpecParams
    {
        private const int MAX_PAGE = 50;
        public int PageIndex {get; set;} = 1;
        private int _pageSize = 5;
        public int PageSize{ get => _pageSize; set => _pageSize = (value > MAX_PAGE) ? MAX_PAGE : value;}
        private string _carrera;
        public string Carrera {get => _carrera; set => _carrera = value.ToLower();}
        public string Ordenar {get; set;}          
        public string Tipo {get; set;}        
        public string Dia  {get; set;}
        public string Hora {get; set;}
        public int? Id {get; set;}

    }
}
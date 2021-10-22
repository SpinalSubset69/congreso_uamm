namespace Core.Specification
{
    public class AttendeeSpecParams
    {
        private const int MAX_PAGE = 50;
        public int PageIndex {get; set;} = 1;
        private int _pageSize = 5;
        public int PageSize{ get => _pageSize; set => _pageSize = (value > MAX_PAGE) ? MAX_PAGE : value;}                
        public string Carrera {get; set;}                
        public string Ordenar {get; set;}
        public string Dia {get; set;}
        public string Hora {get; set;}
    }
}
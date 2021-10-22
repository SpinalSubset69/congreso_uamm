using Core.Entities;

namespace Core.Specification
{
    public class RapportuerSpecifications : BaseSpecification<Rapportuer>
    {
        public RapportuerSpecifications(string name):base(x => x.Name == name)
        {
            
        }
        public RapportuerSpecifications(int id)
        :base(x => x.Id == id)
        {
                        
        }
        public RapportuerSpecifications(RapportuerSpecParams specParams)
        :base(x => 
            (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search.ToLower())
                                                     || x.Email.ToLower().Contains(specParams.Search.ToLower()))            
        )
        {
            AddOrderBy(x => x.Name);
        }
    }
}
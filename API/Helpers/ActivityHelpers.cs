using System.Collections.Generic;
using Core.Entities;

namespace API.Helpers
{
    public class ActivityHelpers
    {
        public bool RepportuerExistsOnActivity(List<Rapportuer> _rapportuerList, Rapportuer rapportuerToFind){            
            foreach(var rappoertue in _rapportuerList){
                if(rappoertue.Name == rapportuerToFind.Name){
                    return true;
                }
            }
            return false;
        }   
    }
}
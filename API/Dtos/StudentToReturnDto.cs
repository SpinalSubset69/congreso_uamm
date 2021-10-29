using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.Dtos
{
    public class StudentToReturnDto
    {        
        public int Id {get; set;}
        public string Name { get; set; }
        public string StudentNumber {get; set;}
        public string Email { get; set; }      
        public string Phone {get; set;}  
        public string RegisterAt {get; set;}
        public string Hour { get; set;}
        public string Day { get; set;}
        public string Career {get; set;}    
        public bool IsRegister {get; set;}
        public List<Activity> Activities {get; set;}
    }
}
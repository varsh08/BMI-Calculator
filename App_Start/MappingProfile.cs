using AutoMapper;
using MyHealth.Models;
using MyHealth.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<BmiCalculator, BmiCalculatorDto>();
            Mapper.CreateMap<BmiCalculatorDto, BmiCalculator>().ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}
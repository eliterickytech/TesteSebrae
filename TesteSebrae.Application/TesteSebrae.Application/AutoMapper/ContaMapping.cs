﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSebrae.Application.Models;
using TesteSebrae.Domain.Entities;

namespace TesteSebrae.Application.AutoMapper
{
    public class ContaMapping : Profile
    {
        public ContaMapping()
        {
            CreateMap<ContaViewModel, ContaModel>().ReverseMap();
        }
    }
}

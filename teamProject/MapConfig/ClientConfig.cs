﻿using AutoMapper;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.MapConfig
{
    public class ClientConfig:Profile
    {
        public ClientConfig() {
            CreateMap<Client, ClientViewModel>().AfterMap((src, dist) => { }).ReverseMap();
        }
    }
}

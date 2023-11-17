using WPF_ProjectWork.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_ProjectWork.Services.Classes;


 class JsonService : IJsonService
{
    public T Deserialize<T>(string json) 
    {
        return JsonSerializer.Deserialize<T>(json) ?? throw new NullReferenceException("Deserialize error");
    }
}

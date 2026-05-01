using PulsGrada.Models;
using System.Collections.Generic;

namespace PulsGrada.Services
{
    public interface IKvartService
    {
        List<Kvart> DohvatiSveKvartove();
    }
}